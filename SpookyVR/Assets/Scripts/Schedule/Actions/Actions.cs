﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public int actionType = 0;
    public int buildingType = 0;
    public int npcType = 0;
    [Tooltip("0 is morning, 1 is day, 2 is night. REGARDLESS OF ACTIONS PER DAY, THESE VALUES WILL BE CORRECT.")] public int timeOfAction = 0;
    public int actionDuration = 0;

    private bool actionInProgress = false;

    public Actions(int actionID, int buildingID, int npcID, int timeID, int duration)
    {
        actionType = actionID;
        buildingType = buildingID;
        npcType = npcID;
        timeOfAction = timeID;
        actionDuration = duration;
    }

    /// <summary>
    /// Begins this Actions action based on the actionType. 
    /// </summary>
    public void BeginAction()
    {
        actionInProgress = true;

        //Check burner action here

        Debug.Log("Action Type: " + actionType + "\n"
            + "Building Type: " + buildingType + "\n" +
            "NPC Type: " + npcType + "\n" +  
            "Time of Action: " + timeOfAction + "\n" + 
            "Action Duration: " + actionDuration + "\n");

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


