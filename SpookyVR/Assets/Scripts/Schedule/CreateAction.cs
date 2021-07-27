using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateAction : MonoBehaviour
{
    [SerializeField] private GameObject scheduleActionObject;

    [Tooltip("The Master Input Map. ")] private InputMaster controls;
    [Tooltip("The player controller for schedule creation. ")] private PlayerScheduler playerScheduler;


    private int actionType = 0;
    private int buildingType = 0;
    private int npcType = 0;
    [Tooltip("0 is morning, 1 is day, 2 is night. REGARDLESS OF ACTIONS PER DAY, THESE VALUES WILL BE CORRECT.")] private int timeOfAction = 0;

    // Instantiate object with "ScheduleAction.cs" on it
    // Fill in parameters of ScheduleAction.cs
    // ScheduleAction.cs handles the movement of the action, whether its placed or deleted, etc.

    private void Awake()
    {
        controls = new InputMaster();
        playerScheduler = FindObjectOfType<PlayerScheduler>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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

    public void CreateActionObject()
    {
        //// If an object is not currently held, create an action object.
        //if (!playerScheduler.IsObjectHeld())
        //{

        //    playerScheduler.SetHeldStatus(true);

        //    // Instantiates this action object and child it to the canvas (since it will be a button)
        //    GameObject scheduleActionObjectClone = Instantiate<GameObject>(scheduleActionObject, controls.Player.Look.ReadValue<Vector2>(), Quaternion.identity);
        //    scheduleActionObjectClone.transform.parent = playerScheduler.gameObject.transform;

        //    // Fills in action object's action parameters
        //    scheduleActionObjectClone.GetComponent<ScheduleAction>().FillActionParameters(actionType, buildingType, npcType);

        //    // Sets the player's currently held object to this action object.
        //    playerScheduler.SetHeldObject(scheduleActionObjectClone);
        //}

        // Instantiates this action object and child it to the canvas (since it will be an image)
        GameObject scheduleActionObjectClone = Instantiate<GameObject>(scheduleActionObject, Mouse.current.position.ReadValue(), Quaternion.identity);
        scheduleActionObjectClone.transform.parent = playerScheduler.gameObject.transform;

        // Fills in action object's action parameters
        scheduleActionObjectClone.GetComponent<ScheduleAction>().FillActionParameters(actionType, buildingType, npcType);
    }
}
