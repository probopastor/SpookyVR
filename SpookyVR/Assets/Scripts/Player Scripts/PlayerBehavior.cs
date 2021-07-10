﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("The player's movement speed.")] private float playerSpeed = 1f;

    #region Interaction Controls
    [SerializeField, Tooltip("The range in which the player can interact with objects. ")] private float interactionRange = 1f;
    [SerializeField, Tooltip("All layers that the player can interact with. ")] private LayerMask interactionLayers;

    [SerializeField, Tooltip("The crosshair. ")] private Image crosshair;
    [SerializeField, Tooltip("The crosshair sprite used when hovering over an interactable object. ")] private Sprite crosshairCanSelectSprite;
    [Tooltip("The default crosshair sprite. ")] private Sprite crosshairDefaultSprite;
    [SerializeField, Tooltip("The crosshair sprite color used when hovering over an interactable object. ")] private Color crosshairCanSelectColor;
    [Tooltip("The default crosshair sprite color. ")] private Color crosshairDefaultColor;
    [Tooltip("The bool to determine if the player is hovering over an object that is interactable. ")] private bool canInteract = false;
    #endregion 

    [Tooltip("The Master Input Map. ")] private InputMaster controls;
    [Tooltip("The movement vector that will be altered based on player input. ")] private Vector3 move;
    [Tooltip("The player's Rigidbody. ")] private Rigidbody rb;
    

    private void Awake()
    {
        controls = new InputMaster();

        controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => move = Vector3.zero;

        rb = GetComponent<Rigidbody>();
        crosshairDefaultSprite = crosshair.sprite;
        crosshairDefaultColor = crosshair.color;
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
        Movement(move);
        HoverObject();

        if(canInteract)
        {
            if(controls.Player.Interact.triggered)
            {
                SelectObject();
            }
        }
    }

    /// <summary>
    /// Handles player movement. 
    /// </summary>
    /// <param name="direction">The Vector3 direction the player should move in. </param>
    private void Movement(Vector3 direction)
    {
        //Vector3 movement = new Vector3(direction.x * playerSpeed, 0, direction.y * playerSpeed);

        Vector3 movement = (direction.y * transform.forward) + (direction.x * transform.right);
        rb.velocity = movement * playerSpeed;
    }

    private void HoverObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange, interactionLayers))
        {
            if(!canInteract)
            {
                canInteract = true;
                crosshair.sprite = crosshairCanSelectSprite;
                crosshair.color = crosshairCanSelectColor;
            }
        }
        else
        {
            if(canInteract)
            {
                canInteract = false;
                crosshair.sprite = crosshairDefaultSprite;
                crosshair.color = crosshairDefaultColor;
            }
        }
    }

    private void SelectObject()
    {
        Debug.Log("Object Selected"); 
    }

}
