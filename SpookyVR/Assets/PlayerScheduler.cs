using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScheduler : MonoBehaviour
{
    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    private bool objectHeld = false;
    private GameObject scheduleActionObject;

    private void Awake()
    {
        controls = new InputMaster();
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

        if (scheduleAction.IsSmallAction())
        {
            if(scheduleAction.GetClosestSlotObject() != null)
            {
                ScheduleSlotData scheduleSlotData = scheduleAction.GetClosestSlotObject().GetComponent<ScheduleSlotData>();

                if (scheduleSlotData.GetActionHeld() == null)
                {
                    // Turn color to "Can Place Color" here.
                    if (controls.Scheduler.Place.triggered)
                    {
                        scheduleSlotData.SetActionHeld(scheduleActionObject);

                        objectHeld = false;

                        scheduleActionObject.transform.localScale = scheduleAction.GetClosestSlotObject().transform.localScale;
                        scheduleActionObject.transform.position = scheduleAction.GetClosestSlotObject().transform.position;
                    }
                }
                else
                {
                    // Cannot place color here.
                }
            }
        }

        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, scheduleSlotLayers))
        //{
        //    GameObject hitObj = hit.transform.gameObject;

        //    if (hitObj.GetComponent<ScheduleSlotData>() != null)
        //    {
        //        ScheduleSlotData scheduleSlotData = hitObj.GetComponent<ScheduleSlotData>();

        //        if (scheduleSlotData.GetActionHeld() == null)
        //        {
        //            // Turn color to "Can Place Color" here.
        //            if (controls.Scheduler.Place.triggered)
        //            {
        //                scheduleSlotData.SetActionHeld(scheduleActionObject);
        //                scheduleActionObject.transform.position = hitObj.transform.position;
        //                objectHeld = false;
        //            }
        //        }
        //        else
        //        {
        //            // Turn color to Cannot Place color here
        //        }
        //    }
        //    else if (Physics.Raycast(ray, out hit, Mathf.Infinity, deleteActionLayers))
        //    {
        //        // Turn color to "Deletion Color" here
        //    }
        //    else
        //    {
        //        // Turn color to Cannot Place color here.
        //    }
        //}
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
