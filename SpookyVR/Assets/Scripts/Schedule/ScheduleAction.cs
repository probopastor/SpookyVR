/* 
* Glory to the High Council
* William Nomikos
* ScheduleAction.cs
* Handles the stickers of the schedule buttons. These each hold the action to be scheduled, and will be scheduled once they
* are placed onto a schedule slot (which will then schedule them into ScheduleCreation).
* 
* Also handles the changes and effects the stickers receive while being placed. (Transparency, enlargment, animations, etc).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Schedule
{
    public class ScheduleAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler
    {
        #region Color variables
        [Header("Color Settings")]
        [SerializeField, Tooltip("The alpha of this schedule action object while it is being dragged. "), Range(0, 1)] private float alphaDragging = 1f;
        [SerializeField, Tooltip("The alpha of this schedule action object when it's placed. "), Range(0, 1)] private float alphaPlaced = 1f;
        #endregion

        [Tooltip("The Master Input Map. ")] private InputMaster controls;

        [Tooltip("The spawn source of this Schedule Action. Will be null if it was not spawned by a CreateAction source. ")] private CreateAction creationSource;

        [SerializeField, Tooltip("Reference to the scripts that makes the object follow the Route/Bezier curve")]
        private BezierFollow bezierFollow;

        #region Canvas variables
        [Tooltip("The Rect Transform of this object. ")] private RectTransform rectTransform;
        [Tooltip("The Canvas Group of this object. ")] private CanvasGroup canvasGroup;
        #endregion

        #region Schedule variables
        [Tooltip("The schedule slot data this schedule action is dropped onto. Null if it is not currently dropped onto one. ")] private ScheduleSlotData slotDroppedOn;

        [Tooltip("The ID of this Schedule Action's action. ")] private int action = 0;
        [Tooltip("The ID of this Schedule Action's building. ")] private int building = 0;
        [Tooltip("The ID of this Schedule Action's npc. ")] private int npc = 0;
        [Tooltip("The duration of this action. 0 is small action, 1 is medium action, 2 is long action.")] private int duration = 0;

        [Tooltip("If true, this object will continuously fall until it is off the screen. False otherwise. ")] private bool enableSwayFall = false;
        #endregion

        #region Setup Methods
        private void Awake()
        {
            controls = new InputMaster();
            bezierFollow = GetComponent<BezierFollow>();
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Disable();
        }

        private void FixedUpdate()
        {
            if (enableSwayFall)
            {
                Debug.Log(gameObject.name + " is sway falling.");
                SwayFall(true);
            }
            else if (!enableSwayFall)
            {
                SwayFall(false);
            }
        }

        #endregion

        #region Schedule Methods
        /// <summary>
        /// Fills in this actions parameters.
        /// </summary>
        /// <param name="actionType">The ID of this Schedule Action's action type.</param>
        /// <param name="buildingType">The ID of this Schedule Action's building type.</param>
        /// <param name="npcType">The ID of this Schedule Action's npc type.</param>
        public void FillActionParameters(int actionType, int buildingType, int npcType, int actionDuration)
        {
            action = actionType;
            building = buildingType;
            npc = npcType;
            duration = actionDuration;
        }

        /// <summary>
        /// Gets the action type of this Schedule Action.
        /// </summary>
        /// <returns>The ID of the action. </returns>
        public int GetActionType()
        {
            return action;
        }

        /// <summary>
        /// Gets the building type of this Schedule Action.
        /// </summary>
        /// <returns>The ID of this building.</returns>
        public int GetBuildingType()
        {
            return building;
        }

        /// <summary>
        /// Gets the NPC type of this Schedule Action.
        /// </summary>
        /// <returns>The ID of this NPC.</returns>
        public int GetNPCType()
        {
            return npc;
        }

        /// <summary>
        /// Gets the Action Duration of this Schedule Action.
        /// </summary>
        /// <returns>The duration of the action. 0 is short action, 1 is medium action, 2 is long action.</returns>
        public int GetActionDuration()
        {
            return duration;
        }

        /// <summary>
        /// Sets the schedule slot dropped on to the passed in schedule slot.
        /// </summary>
        /// <param name="thisSlot">Sets this action's schedule slot to the passed in slot parameter.</param>
        public void SetScheduleSlotData(ScheduleSlotData thisSlot)
        {
            slotDroppedOn = thisSlot;
        }

        /// <summary>
        /// Sets this ScheduleAction's creation source to the passed in source. This lets the action track where it was created.
        /// </summary>
        /// <param name="source">The CreationSource that created this object.</param>
        public void SetCreationSource(CreateAction source)
        {
            creationSource = source;
        }

        #endregion

        #region UI Effects Methods

        private void SwayFall(bool swayFallStatus)
        {
            // If this object should sway fall
            if (swayFallStatus)
            {
                // If bezier movement is not in progress
                if (!bezierFollow.GetBezierMovementInProgress())
                {
                    StartCoroutine(bezierFollow.GoByRoute());
                }
            }
            // If this object should stop sway falling...
            else if (!swayFallStatus)
            {
                // Check to see if movement is in progress.
                if (bezierFollow.GetBezierMovementInProgress())
                {
                    // If movement is in progress, stop it.
                    bezierFollow.SetBezierMovementInProgress(false);
                }
            }
        }

        #endregion 

        #region Drag & Drop Methods
        public void OnPointerDown(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;

            // Set the parent of the object to the canvas.
            if (gameObject.transform.parent != GameObject.FindGameObjectWithTag("ScheduleCanvas").transform)
            {
                gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("ScheduleCanvas").transform);
            }

            canvasGroup.alpha = alphaDragging;

            // When this ScheduleAction is grabbed, have it's source create a new action object in its stead.
            if (creationSource != null)
            {
                creationSource.CreateActionObject();
                creationSource = null;
            }

            enableSwayFall = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = alphaPlaced;

            StartCoroutine(CheckSlotDroppedOnNextFrame());
        }

        /// <summary>
        /// Waits a frame before checking if this ScheduleAction is dropped onto a slot before enabling sway falling. 
        /// This is to allow the ScheduleSlotData script to run before this is checked (Since EventSystem methods (i.e. OnPointerUp)
        /// will naturally run before slotDroppedOn can be updated.
        /// </summary>
        /// <returns></returns>
        private IEnumerator CheckSlotDroppedOnNextFrame()
        {
            yield return new WaitForEndOfFrame();

            // If this ScheduleAction is not dropped onto a ScheduleSlot, enable sway fall.
            if (slotDroppedOn == null)
            {
                enableSwayFall = true;
            }
            else
            {
                enableSwayFall = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            gameObject.transform.position = Mouse.current.position.ReadValue();
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("THIS FUCKING OCCURS HAHAA");

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            ForceClearFromSchedule();
        }

        /// <summary>
        /// Force clears this action from the schedule.
        /// </summary>
        public void ForceClearFromSchedule()
        {
            if (slotDroppedOn != null)
            {
                GameObject currentScheduleSlotActionHeld = slotDroppedOn.GetActionHeld();

                // Get this action's slot data to remove from the schedule
                Actions actionToBeRemoved = currentScheduleSlotActionHeld.GetComponent<Actions>();

                int dayOfAction = slotDroppedOn.GetScheduleDay();
                int slotPosOfAction = slotDroppedOn.GetSlotPos();

                // Unschedule this action
                slotDroppedOn.UnscheduleAction(actionToBeRemoved, dayOfAction, slotPosOfAction, duration);

                // Set slotDroppedOn variables to null
                slotDroppedOn.SetActionHeld(null);
                slotDroppedOn = null;
            }
        }
        #endregion
    }
}