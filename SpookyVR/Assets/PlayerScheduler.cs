using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScheduler : MonoBehaviour
{
    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    private bool objectHeld = false;
    private GameObject scheduleActionObject;

    private void Awake()
    {
        controls = new InputMaster();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectHeld)
        {
            scheduleActionObject.transform.position = Mouse.current.position.ReadValue();
            
            if(controls.Scheduler.Delete.triggered)
            {
                Destroy(scheduleActionObject);
                objectHeld = false;
            }
            else if(controls.Scheduler.Place.triggered)
            {
                objectHeld = false;
            }
        }
    }

    /// <summary>
    /// Sets the action object held to the passed in object.
    /// </summary>
    /// <param name="heldObject">The action object to be held. </param>
    public void SetHeldObject(GameObject heldObject)
    {
        scheduleActionObject = heldObject;
    }

    /// <summary>
    /// Returns whether or not a schedule action object is currently being held.
    /// </summary>
    /// <returns>True if a schedule action object is held, false otherwise.</returns>
    public bool IsObjectHeld()
    {
        return objectHeld;
    }

    /// <summary>
    /// Setter for the held status of the objectHeld. 
    /// </summary>
    /// <param name="heldStatus">True if scheduleAction is held, false otherwise. </param>
    public void SetHeldStatus(bool heldStatus)
    {
        objectHeld = heldStatus;
    }
}
