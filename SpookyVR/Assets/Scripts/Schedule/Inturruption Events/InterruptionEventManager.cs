using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Schedule;

public class InterruptionEventManager : MonoBehaviour
{
    private List<Days> eventOccurences = new List<Days>();
    [Tooltip("A list of all the actions in a day. Set to the number of actions in a day. ")] List<Actions> dailyActions = new List<Actions>();
    [Tooltip("The number of actions in a day. ")] private int numberOfActionsPerDay = 0;

    // Start is called before the first frame update
    void Start()
    {
        RefreshEventOccurences();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Refreshes the eventOccruences list so that a fresh list can be used for random events.
    /// </summary>
    public void RefreshEventOccurences()
    {
        ScheduleCreation thisSchedule = FindObjectOfType<ScheduleCreation>();

        // Find the amount of days in a week
        int daysInWeek = thisSchedule.GetDaysInWeek();

        // Set the eventOccurences list equal to a new list of size daysInWeek
        eventOccurences = new List<Days>(daysInWeek);

        // Sets the number of actions per day
        numberOfActionsPerDay = thisSchedule.GetActionsPerDay();

        // Add the correct amount of actions to each day in theDays.
        for (int i = 0; i < eventOccurences.Count; i++)
        {
            // Instantiates a new dailyActions list for each day
            dailyActions = new List<Actions>();

            // Adds default action objects to each dailyActions list.
            for (int x = 0; x < numberOfActionsPerDay; x++)
            {
                //Actions defaultAction = new Actions(100, 100, 100, 100);

                Actions defaultAction = gameObject.AddComponent<Actions>();
                defaultAction.actionType = 100;
                defaultAction.buildingType = 100;
                defaultAction.npcType = 100;
                defaultAction.timeOfAction = 100;

                dailyActions.Add(defaultAction);
            }

            // Set the actions today list equal to the daily actions.
            eventOccurences[i].actionsToday = dailyActions;
        }
    }

    public void AddEventAction(int dayNumber, int slotInDay, int actionLength, int actionID, int buildingID, int npcID, int timeID, int actionDuration, bool isOptional, bool isScheduleable)
    {
        

        //Actions interruptionAction = new Actions(actionID, buildingID, npcID, timeID, actionDuration, isOptional, isScheduleable);

        Actions interruptionAction = gameObject.AddComponent<Actions>();

        interruptionAction.actionType = actionID;
        interruptionAction.buildingType = buildingID;
        interruptionAction.npcType = npcID;
        interruptionAction.timeOfAction = timeID;
        interruptionAction.eventDuration = actionDuration;
        interruptionAction.optional = isOptional;
        interruptionAction.schedulable = isScheduleable;

        eventOccurences[dayNumber].actionsToday[slotInDay] = interruptionAction;

        // If isOptional is false, this action has to be scheduled. 
        // If isScheduleable, then player will be brought to the schedule to add the event at a given time.
        // If not isScheduleable, then a "this is occuring, attend? " message will occur the day of.
    }

    /// <summary>
    /// Gets a list of event occurences. 
    /// </summary>
    /// <returns>A List<Days> with every event scheduled. </Days></returns>
    public List<Days> GetEventOccurences()
    {
        return eventOccurences;
    }
}
