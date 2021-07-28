using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScheduleAction : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    #region Color variables
    [Header("Color Settings")]
    [SerializeField, Tooltip("The alpha of this schedule action object while it is being dragged. "), Range(0, 1)] private float alphaDragging = 1f;
    [SerializeField, Tooltip("The alpha of this schedule action object when it's placed. "), Range(0, 1)] private float alphaPlaced = 1f;
    #endregion

    [Tooltip("The Master Input Map. ")] private InputMaster controls;

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

    #endregion

    #region Setup Methods
    private void Awake()
    {
        controls = new InputMaster();
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

    public void SetScheduleSlotData(ScheduleSlotData thisSlot)
    {
        slotDroppedOn = thisSlot;
    }
    #endregion

    #region Drag & Drop Methods
    public void OnPointerDown(PointerEventData eventData)
    {
        canvasGroup.alpha = alphaDragging;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Mouse.current.position.ReadValue();
        canvasGroup.blocksRaycasts = false;
        //canvasGroup.alpha = alphaDragging;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = alphaPlaced;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(slotDroppedOn != null)
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
