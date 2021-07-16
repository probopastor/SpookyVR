using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public int actionType = 0;
    public int buildingType = 0;
    public int npcType = 0;
    [Tooltip("0 is morning, 1 is day, 2 is night. REGARDLESS OF ACTIONS PER DAY, THESE VALUES WILL BE CORRECT.")] public int timeOfAction = 0;

    /// <summary>
    /// Begins this Actions action based on the actionType. 
    /// </summary>
    public void BeginAction()
    {
        if (actionType == 3)
        {
            // GetComponentOfType<Storage>().BeginNPCTalk(npcType, timeOfAction);
        }
        else
        {
            // GetComponentOfType<Storage>().BeginBuildingAction(buildingType, actionType, timeOfAction);
        }
    }
}


