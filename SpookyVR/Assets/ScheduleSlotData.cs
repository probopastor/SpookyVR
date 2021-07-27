using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScheduleSlotData : MonoBehaviour, IDropHandler
{
    [SerializeField, Tooltip("The position of the day this slot will occur at. This is its position in the schedule, not the time of day. ")] private int slotPos;
    [SerializeField, Tooltip("The day this slot is on. 0 is Sunday, 6 is Saturday. ")] private int scheduleDay;

    [SerializeField] private GameObject actionHeld;
    [Tooltip("The current action being created. Once it is created, an instance of thisAction should be added to the action list. ")] private Actions actionObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Returns if an action is currently held by this schedule slot.
    /// </summary>
    /// <returns>The action currently held by this schedule slot. </returns>
    public GameObject GetActionHeld()
    {
        return actionHeld;
    }

    /// <summary>
    /// Sets the action this schedule slot is holding.
    /// </summary>
    /// <param name="newAction">The new action this schedule slot is holding. Set to null if it is not holding anything. </param>
    public void SetActionHeld(GameObject newAction)
    {
        actionHeld = newAction;
    }

    /// <summary>
    /// Returns the slot position this schedule slot is on.
    /// </summary>
    /// <returns>The slot position of this schedule slot. </returns>
    public int GetSlotPos()
    {
        return slotPos;
    }

    /// <summary>
    /// Returns the day this schedule slot is on.
    /// </summary>
    /// <returns>The day this schedule slot is on. 0 is Sunday, 6 is Saturday. </returns>
    public int GetScheduleDay()
    {
        return scheduleDay;
    }

    public void OnDrop(PointerEventData eventData)
    {        
        if(eventData.pointerDrag != null)
        {
            if(actionHeld == null)
            {
                // Updates the action held information
                actionHeld = eventData.pointerDrag;
                ScheduleAction thisAction = actionHeld.GetComponent<ScheduleAction>();

                if (thisAction.GetActionDuration() == 0)
                {
                    thisAction.SetScheduleSlotData(this);

                    actionObj = new Actions(thisAction.GetActionType(), thisAction.GetBuildingType(), thisAction.GetNPCType(), 100, thisAction.GetActionDuration());

                    // Schedules this action
                    ScheduleCreation scheduleCreation = FindObjectOfType<ScheduleCreation>();
                    scheduleCreation.SetAction(actionObj, scheduleDay, slotPos);

                    //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                    // Snaps action to schedule slot position
                    eventData.pointerDrag.transform.position = gameObject.transform.position;
                }
                else if(thisAction.GetActionDuration() == 1)
                {
                    // TODO
                }
                else if(thisAction.GetActionDuration() == 2)
                {
                    // TODO
                }
                

            }
        }
    }

    public void UnscheduleAction(Actions actionToRemove, int day, int slotPos)
    {
        ScheduleCreation scheduleCreation = FindObjectOfType<ScheduleCreation>();
        scheduleCreation.RemoveAction(actionToRemove, day, slotPos);
        actionObj = null;
    }
}
