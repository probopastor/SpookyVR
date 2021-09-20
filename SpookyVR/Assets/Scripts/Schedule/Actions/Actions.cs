/* 
* Glory to the High Council
* William Nomikos
* Action.cs
* The action object class. These hold what an action is and are what get scheduled.
* Contains BeginAction() method, which hanldes running the action based on its parameters. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schedule
{
    public class Actions : MonoBehaviour
    {
        public int actionType = 0;
        public int buildingType = 0;
        public int npcType = 0;
        [Tooltip("0 is morning, 1 is day, 2 is night. REGARDLESS OF ACTIONS PER DAY, THESE VALUES WILL BE CORRECT.")] public int timeOfAction = 0;

        private bool actionInProgress = false;

        [Tooltip("The duration of this action, if it is an event. Normal actions will be created with a duration that is checked during the Schedule phase. ")] public int eventDuration;
        [Tooltip("Determines whether this action is optional or not. This is taken into account for events. If optional is True, this action can be skipped by the player. ")] public bool optional = false;
        [Tooltip("Determines whether this action will be scheduled or not. This is taken into account for events. If schedulable is True, this action needs to be scheduled by the player. Otherwise it will just happen, regardless of the current schedule. ")] public bool schedulable = false;
        
        public Actions(int actionID, int buildingID, int npcID, int timeID)
        {
            actionType = actionID;
            buildingType = buildingID;
            npcType = npcID;
            timeOfAction = timeID;
        }

        public Actions(int actionID, int buildingID, int npcID, int timeID, int actionDuration, bool isOptional, bool isScheduleable)
        {
            actionType = actionID;
            buildingType = buildingID;
            npcType = npcID;
            timeOfAction = timeID;
            eventDuration = actionDuration;
            optional = isOptional;
            schedulable = isScheduleable;
        }

        /// <summary>
        /// Begins this Actions action based on the actionType. 
        /// </summary>
        public void BeginAction()
        {
            actionInProgress = true;

            if (actionType == 100 || buildingType == 100 || npcType == 100)
            {
                actionInProgress = false;
            }
            else if(actionType == 0)
            {
                // Inspect(buildingType, timeOfAction);
            }
            else if(actionType == 1)
            {
                // TalkTo(npcType, timeOfAction);
            }
        }

        /// <summary>
        /// Sets whether this action is currently in progress.
        /// </summary>
        /// <returns>True if this action is in progress, false otherwise.</returns>
        public void SetActionInProgress(bool progressState)
        {
            actionInProgress = progressState;
        }

        /// <summary>
        /// Returns whether this action is in progress or not.
        /// </summary>
        /// <returns>True if this action is in progress, false otherwise.</returns>
        public bool GetActionInProgress()
        {
            return actionInProgress;
        }
    }
}

