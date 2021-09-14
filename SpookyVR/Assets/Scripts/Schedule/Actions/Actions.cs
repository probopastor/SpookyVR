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

public class Actions : MonoBehaviour
{
    public int actionType = 0;
    public int buildingType = 0;
    public int npcType = 0;
    [Tooltip("0 is morning, 1 is day, 2 is night. REGARDLESS OF ACTIONS PER DAY, THESE VALUES WILL BE CORRECT.")] public int timeOfAction = 0;

    private bool actionInProgress = false;

    public Actions(int actionID, int buildingID, int npcID, int timeID)
    {
        actionType = actionID;
        buildingType = buildingID;
        npcType = npcID;
        timeOfAction = timeID;
    }

    /// <summary>
    /// Begins this Actions action based on the actionType. 
    /// </summary>
    public void BeginAction()
    {
        actionInProgress = true;

        if(actionType == 100 || buildingType == 100 || npcType == 100)
        {
            actionInProgress = false;
        }

        if (actionType == 3)
        {
            // GetComponentOfType<Storage>().BeginNPCTalk(npcType, timeOfAction);
        }
        else
        {
            // GetComponentOfType<Storage>().BeginBuildingAction(buildingType, actionType, timeOfAction);
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


