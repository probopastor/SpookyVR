using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleCreation : MonoBehaviour
{
    [Tooltip("The number of actions in a day. ")] private int numberOfActionsPerDay = 0;

    [SerializeField, Tooltip("A list of days. Set equal to the number of days in a week. ")] List<Days> theDays = new List<Days>();
    [SerializeField, Tooltip("A list all the actions in a day. Set to the number of actions in a day. ")] List<Actions> dailyActions = new List<Actions>();

    [Tooltip("The current day being scheduled for. ")] private int currentScheduleDay = 0;
    [Tooltip("The current action being created. Once it is created, an instance of thisAction should be added to the action list. ")] private Actions thisAction;

    private int actionType = 0;
    private int buildingType = 0;
    private int npcType = 0;

    [System.Serializable]
    public class Days
    {
        public List<Actions> actionsToday;
    }

    private void Awake()
    {
        // Add the correct amount of actions to each day in theDays.
        for (int i = 0; i < theDays.Count; i++)
        {
            // Set the actions today list equal to the daily actions.
            theDays[i].actionsToday = dailyActions;
        }

        numberOfActionsPerDay = dailyActions.Count;
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
    /// Sets the current building type to the building represented by thisBuildingType.
    /// </summary>
    /// <param name="thisBuildingType"></param>
    public void SetBuildingType(int thisBuildingType)
    {
        buildingType = thisBuildingType;
    }

    // <summary>
    /// Sets the current action type to the action represented thisActionType.
    /// </summary>
    /// <param name="thisActionType">The current action type. 0 is GetReport, 1 is Collect, 2 is Assess, 3 is Talk To. All other numbers are unique to the given scenario. </param>
    public void SetActionType(int thisActionType)
    {
        actionType = thisActionType;
    }

    /// <summary>
    /// Sets the current NPC type to the NPC represented by thisNPCType.
    /// </summary>
    /// <param name="thisNPCType"></param>
    public void SetNPCType(int thisNPCType)
    {
        npcType = thisNPCType;
    }


    /// <summary>
    /// Sets the action to the designated spot on the designated day.
    /// </summary>
    /// <param name="actionNumber">The position of the day the action will occur at. (This is the slot in the day, not the time, this value will instead be used to calculate time). </param>
    public void SetAction(int actionNumber)
    {
        // Updates this individual action.
        thisAction.actionType = actionType;
        thisAction.buildingType = buildingType;
        thisAction.npcType = npcType;

        // If this is an NPC action
        if (actionNumber == 3)
        {
            //if(!GetComponent<Storage>().CheckNPCScheduleCompatibility(npcType, actionNumber)) 
            //{
            //Send feedback saying NPC name is not free at this time.
            // Break. 
            //}
        }

        thisAction.timeOfAction = SetTime(actionNumber, numberOfActionsPerDay);

        // Add this action to the appropriate spot of the action list. 
        theDays[currentScheduleDay].actionsToday[actionNumber] = thisAction;
    }

    /// <summary>
    /// Sets longer actions than the standard short action.
    /// </summary>
    /// <param name="actionNumbers">An array of the positions if the day the action will occur at. (these are the slots in the day, not the time, these values will instead be used to calculate time.)</param>
    public void SetActionLonger(int[] actionNumbers)
    {
        bool incompatibileSchedule = false;

        for (int i = 0; i < actionNumbers.Length; i++)
        {
            if(theDays[currentScheduleDay].actionsToday[actionNumbers[i]] == null)
            {
                incompatibileSchedule = true;
            }
        }

        if(!incompatibileSchedule)
        {
            // Updates this individual action.
            thisAction.actionType = actionType;
            thisAction.buildingType = buildingType;
            thisAction.npcType = npcType;

            thisAction.timeOfAction = SetTime(actionNumbers[0], numberOfActionsPerDay);
            theDays[currentScheduleDay].actionsToday[actionNumbers[0]] = thisAction;

            for (int i = 0; i < actionNumbers.Length; i++)
            {
                // Set action types to 100. This indicates that the action should be skipped.
                thisAction.actionType = 100;
                thisAction.npcType = 100;

                // Add this action to the appropriate spot of the action list. 
                theDays[currentScheduleDay].actionsToday[actionNumbers[i]] = thisAction;
            }
        }
        else
        {
            // Make the UI Indicator red.
        }
    }

    /// <summary>
    /// Sets the time of day of each action based on what time actions are occuring on a day, and on the amount of actions per day. (The time of an action will be read differently depending on the amount of actions per day). 
    /// </summary>
    /// <param name="actionSlot">The slot in the day the action is occuring at.</param>
    /// <param name="actionsPerDay">The number of actions per day. Used to calculate the time of day actions will occur at. </param>
    private int SetTime(int actionSlot, int actionsPerDay)
    {
        int timeOfAction = 0;

        // If there is only 1 action per day, time of day is Afternoon.
        if (actionsPerDay == 1)
        {
            timeOfAction = 1;
        }
        // If there are 2 actions per day, a slot in 0th position is morning, a slot in 1th position is night.
        else if (actionsPerDay == 2)
        {
            if (actionSlot == 0)
            {
                timeOfAction = 0;
            }
            else if (actionSlot == 1)
            {
                timeOfAction = 2;
            }
        }
        // If there are 3 actions per day, a slot in the 0th position is morning, a slot in the 1th position is afternoon, a slot in the 2nd position is night.
        else if (actionsPerDay == 3)
        {
            if (actionSlot == 0)
            {
                timeOfAction = 0;
            }
            else if (actionSlot == 1)
            {
                timeOfAction = 1;

            }
            else if (actionSlot == 2)
            {
                timeOfAction = 2;
            }
        }

        return timeOfAction;
    }

    /// <summary>
    /// Updates the schedule day based on the selected schedule day.
    /// </summary>
    /// <param name="dayNumber">The current day, Sunday is 0, Saturday is 6. </param>
    public void UpdateScheduleDay(int dayNumber)
    {
        currentScheduleDay = dayNumber;
        Debug.Log("Day is " + currentScheduleDay);
    }
}
