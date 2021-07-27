using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerScheduler : MonoBehaviour
{
    [Tooltip("The Master Input Map. ")] private InputMaster controls;


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
        
    }

    /// <summary>
    /// Changes this schedule actions color when it is hovered over specific instances.
    /// </summary>
    private void HoverEffect()
    {
      
    }

    public void PickUpAction()
    {
       
    }

    /// <summary>
    /// Colors the schedule's slots so that it's clear where this schedule action can be placed.
    /// </summary>
    private void ViewPossibleSlots()
    {
        // If a spot is open for this action - color it green.
        // If a spot is currently taken by another action - but if it wasn't it could be taken by this action - color it purple & give it 1/2 of a cross hash pattern.
        // If a spot is completely unavailable - color it red & give cross hash pattern.
    }

}
