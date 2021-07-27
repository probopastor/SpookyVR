using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerScheduler : MonoBehaviour
{
    [SerializeField] private LayerMask scheduleActionLayers;

    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    private bool objectHeld = false;
    private GameObject scheduleActionObject;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    private void Awake()
    {
        controls = new InputMaster();

        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectHeld)
        {
            ViewPossibleSlots();
            HoverEffect();

            scheduleActionObject.transform.position = Mouse.current.position.ReadValue();

            if (controls.Scheduler.Delete.triggered)
            {
                Destroy(scheduleActionObject);
                objectHeld = false;
            }
            else if (controls.Scheduler.Place.triggered)
            {
                //objectHeld = false;
            }
        }
        else if (!objectHeld)
        {
            PickUpAction();
        }
    }

    /// <summary>
    /// Changes this schedule actions color when it is hovered over specific instances.
    /// </summary>
    private void HoverEffect()
    {
        // Turn transparent if it is over something that will delete it.
        // Turn grey if it is over something that it cannot be placed onto.
        // Turn normal color (white?) if it is over something it can be placed onto. 

        //Ray ray = Camera.main.ScreenPointToRay(scheduleActionObject.transform.position);
        //RaycastHit hit;

        ScheduleAction scheduleAction = scheduleActionObject.GetComponent<ScheduleAction>();

        if(scheduleAction != null)
        {
            if (scheduleAction.IsSmallAction())
            {
                if (scheduleAction.GetClosestSlotObject() != null)
                {
                    ScheduleSlotData scheduleSlotData = scheduleAction.GetClosestSlotObject().GetComponent<ScheduleSlotData>();

                    if (scheduleSlotData.GetActionHeld() == null)
                    {
                        // Turn color to "Can Place Color" here.
                        if (controls.Scheduler.Place.triggered)
                        {
                            //scheduleSlotData.SetActionHeld(scheduleActionObject);
                            scheduleAction.SetScheduleSlotData(scheduleSlotData);

                            objectHeld = false;

                            scheduleActionObject.transform.parent = scheduleAction.GetClosestSlotObject().transform;
                            scheduleActionObject.transform.localScale = scheduleAction.GetClosestSlotObject().transform.localScale;
                            scheduleActionObject.transform.position = scheduleAction.GetClosestSlotObject().transform.position;

                            scheduleAction.RefreshClosestSlotObject();
                        }
                    }
                    else
                    {
                        // Cannot place color here.
                    }
                }
            }
        }
    }

    public void PickUpAction()
    {
        if (controls.Scheduler.Place.triggered)
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Mouse.current.position.ReadValue();

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                //Debug.Log("Hit " + result.gameObject.name);

                if(result.gameObject.CompareTag("ScheduleAction"))
                {
                    scheduleActionObject = result.gameObject;
                    scheduleActionObject.transform.parent = gameObject.transform;

                    ScheduleAction scheduleAction = scheduleActionObject.GetComponent<ScheduleAction>();

                    scheduleAction.RefreshSlotData();
                    scheduleAction.RefreshClosestSlotObject();

                    objectHeld = true;
                }
            }
        }
    }

    /// <summary>
    /// Colors the schedule's slots so that it's clear where this schedule action can be placed.
    /// </summary>
    private void ViewPossibleSlots()
    {
        // If a spot is open for this action - color it green.
        // If a spot is currently taken by another action - but if it wasn't it could be taken by this action - color it purple & give it 1/2 of a cross hash pattern.
        // If a spot is completely unavailable - color it red & give cross hash pattern.
    }

    /// <summary>
    /// Sets the action object held to the passed in object.
    /// </summary>
    /// <param name="heldObject">The action object to be held. </param>
    public void SetHeldObject(GameObject heldObject)
    {
        scheduleActionObject = heldObject;
    }

    /// <summary>
    /// Returns whether or not a schedule action object is currently being held.
    /// </summary>
    /// <returns>True if a schedule action object is held, false otherwise.</returns>
    public bool IsObjectHeld()
    {
        return objectHeld;
    }

    /// <summary>
    /// Setter for the held status of the objectHeld. 
    /// </summary>
    /// <param name="heldStatus">True if scheduleAction is held, false otherwise. </param>
    public void SetHeldStatus(bool heldStatus)
    {
        objectHeld = heldStatus;
    }
}
