using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleCreation : MonoBehaviour
{
    [SerializeField, Tooltip("The number of actions in a day. ")] private int numberOfActionsPerDay = 0;

    [SerializeField, Tooltip("A list of days. Set equal to the number of days in a week. ")] List<Days> theDays = new List<Days>();
    [SerializeField, Tooltip("A list of all the actions in a day. Set to the number of actions in a day. ")] List<Actions> dailyActions = new List<Actions>();

    [System.Serializable]
    public class Days
    {
        public List<Actions> actionsToday;
    }

    private void Awake()
    {

    }

    private void Start()
    {
        // Add the correct amount of actions to each day in theDays.
        for (int i = 0; i < theDays.Count; i++)
        {
            // Instantiates a new dailyActions list for each day
            dailyActions = new List<Actions>();

            // Adds default action objects to each dailyActions list.
            for (int x = 0; x < numberOfActionsPerDay; x++)
            {
                Actions defaultAction = new Actions(100, 100, 100, 100);
                dailyActions.Add(defaultAction);
            }

            // Set the actions today list equal to the daily actions.
            theDays[i].actionsToday = dailyActions;
        }

        for (int i = 0; i < theDays.Count; i++)
        {
            for (int x = 0; x < theDays[i].actionsToday.Count; x++)
            {
                Debug.Log("theDays: " + i + " actionsToday: " + x + " contains the following action: " + "\n" +
                       " Action Type: " + theDays[i].actionsToday[x].actionType + "\n" +
                       " Building Type: " + theDays[i].actionsToday[x].buildingType + "\n" +
                       " NPC Type: " + theDays[i].actionsToday[x].npcType + "\n" +
                       " Time of Day: " + theDays[i].actionsToday[x].timeOfAction + "\n");
            }
        }
    }

    /// <summary>
    /// Schedules a passed in action.
    /// </summary>
    /// <param name="actionToBeScheduled">The action to be scheduled. </param>
    /// <param name="actionNumber">The position in the day that this action will occur at. This is not the time.</param>
    /// <param name="scheduleDay">The day this action occurs on. 0 is Sunday, 6 is Saturday. </param>
    public void SetAction(Actions actionToBeScheduled, int actionNumber, int scheduleDay)
    {
        // Gets the time of this action
        actionToBeScheduled.timeOfAction = SetTime(actionNumber, numberOfActionsPerDay);

        // Add this action to the appropriate spot of the action list. 
        theDays[scheduleDay].actionsToday[actionNumber] = actionToBeScheduled;

        for (int i = 0; i < theDays.Count; i++)
        {
            for (int x = 0; x < theDays[i].actionsToday.Count; x++)
            {
                Debug.Log("theDays: " + i + " actionsToday: " + x + " contains the following action: " + "\n" +
                       " Action Type: " + theDays[i].actionsToday[x].actionType + "\n" +
                       " Building Type: " + theDays[i].actionsToday[x].buildingType + "\n" +
                       " NPC Type: " + theDays[i].actionsToday[x].npcType + "\n" +
                       " Time of Day: " + theDays[i].actionsToday[x].timeOfAction + "\n");
            }
        }
    }

    public void RemoveAction(Actions actionToBeRemoved)
    {
        foreach(Days theDay in theDays)
        {
            if(theDay.actionsToday.Contains(actionToBeRemoved))
            {
                Actions dummyAction = new Actions(100, 100, 100, 100);
                int index = theDay.actionsToday.IndexOf(actionToBeRemoved);
                theDay.actionsToday[index] = dummyAction;
            }
        }

        for (int i = 0; i < theDays.Count; i++)
        {
            for (int x = 0; x < theDays[i].actionsToday.Count; x++)
            {
                Debug.Log("theDays: " + i + " actionsToday: " + x + " contains the following action: " + "\n" +
                       " Action Type: " + theDays[i].actionsToday[x].actionType + "\n" +
                       " Building Type: " + theDays[i].actionsToday[x].buildingType + "\n" +
                       " NPC Type: " + theDays[i].actionsToday[x].npcType + "\n" +
                       " Time of Day: " + theDays[i].actionsToday[x].timeOfAction + "\n");
            }
        }
    }

    /// <summary>
    /// Sets longer actions than the standard short action.
    /// </summary>
    /// <param name="actionNumbers">An array of the positions if the day the action will occur at. (these are the slots in the day, not the time, these values will instead be used to calculate time.)</param>
    public void SetActionLonger(int[] actionNumbers)
    {
        
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
}
