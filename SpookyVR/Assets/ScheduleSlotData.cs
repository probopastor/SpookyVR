using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScheduleSlotData : MonoBehaviour, IDropHandler
{
    [SerializeField, Tooltip("The order of actions in this day. Pass in the given day's DailyActionOrder object. ")] private DailyScheduleSlotOrder dailyActions;

    [SerializeField, Tooltip("The position of the day this slot will occur at. This is its position in the schedule, not the time of day. ")] private int slotPos;
    [SerializeField, Tooltip("The day this slot is on. 0 is Sunday, 6 is Saturday. ")] private int scheduleDay;

    [SerializeField] private GameObject actionHeld;
    [Tooltip("The current action being created. Once it is created, an instance of thisAction should be added to the action list. ")] private Actions actionObj;

    private void Awake()
    {
        dailyActions = GetComponentInParent<DailyScheduleSlotOrder>();
    }

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
        if (eventData.pointerDrag != null)
        {
            if (actionHeld == null)
            {
                // Set to true if this data can be scheduled. 
                bool canSchedule = false;

                // Updates the action held information
                actionHeld = eventData.pointerDrag;
                ScheduleAction thisAction = actionHeld.GetComponent<ScheduleAction>();

                // If the action is a short action, it can be scheduled so long as actionHeld is null
                if (thisAction.GetActionDuration() == 0)
                {
                    canSchedule = true;
                }
                else
                {
                    // Gets the order of the Schedule Slots on this day
                    List<ScheduleSlotData> scheduleSlotOrderList = dailyActions.GetDailySlotOrder();

                    // If the action is a medium action, checks must be done to make sure the two slots this medium action takes up aren't currently filled
                    if (thisAction.GetActionDuration() == 1)
                    {
                        // Cannot schedule if medium action starts on the last slot of the day
                        if (slotPos != 2)
                        {
                            // If the medium action is in slot 0, check to make sure slot 1 does not currently hold an action
                            if (slotPos == 0)
                            {
                                if (scheduleSlotOrderList[1].GetActionHeld() == null)
                                {
                                    // If it doesn't, this action can be scheduled.
                                    canSchedule = true;
                                    
                                    // Fills Slot 1 with an empty gameobject to represent it being filled
                                    scheduleSlotOrderList[1].SetActionHeld(new GameObject("DummyAction"));
                                }
                            }
                            // If the medium action is in slot 1, check to make sure slot 2 does not currently hold an action
                            else if (slotPos == 1)
                            {
                                if (scheduleSlotOrderList[2].GetActionHeld() == null)
                                {
                                    // If it doesn't, this action can be scheduled.
                                    canSchedule = true;

                                    // Fills Slot 2 with an empty gameobject to represent it being filled
                                    scheduleSlotOrderList[2].SetActionHeld(new GameObject("DummyAction"));
                                }
                            }
                        }
                    }
                    else if (thisAction.GetActionDuration() == 2)
                    {
                        // If long action, can only be scheduled from slot 0
                        if (slotPos == 0)
                        {
                            // Check to make sure slots 1 and 2 are not currently holding an action
                            if (scheduleSlotOrderList[1].GetActionHeld() == null && scheduleSlotOrderList[2].GetActionHeld() == null)
                            {
                                // If they aren't, this action can be scheduled
                                canSchedule = true;

                                // Fills Slot 1 and Slot 2 with an empty gameobject to represet them being filled
                                scheduleSlotOrderList[1].SetActionHeld(new GameObject("DummyAction"));
                                scheduleSlotOrderList[2].SetActionHeld(new GameObject("DummyAction"));
                            }
                        }
                    }
                }

                // If canSchedule, schedule this action object
                if (canSchedule)
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
                // Otherwise reset schedule slot data parameters
                else
                {
                    actionHeld = null;
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
