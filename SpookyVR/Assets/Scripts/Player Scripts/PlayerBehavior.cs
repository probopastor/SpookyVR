/* 
* Glory to the High Council
* William Nomikos
* PlayerBehavior.cs
* Implements player actions, including general movement, for a 3D space.
* 
* This is no longer used, as the game concept has transitioned.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("The player's movement speed.")] private float playerSpeed = 1f;

    #region Interaction Controls
    [SerializeField, Tooltip("The hand that held objects will appear at. ")] private GameObject hand;
    [SerializeField, Tooltip("The range in which the player can interact with objects. ")] private float interactionRange = 1f;
    [SerializeField, Tooltip("All layers that the player can interact with. ")] private LayerMask interactionLayers;

    [SerializeField, Tooltip("The crosshair. ")] private Image crosshair;
    [SerializeField, Tooltip("The crosshair sprite used when hovering over an interactable object. ")] private Sprite crosshairCanSelectSprite;
    [Tooltip("The default crosshair sprite. ")] private Sprite crosshairDefaultSprite;
    [SerializeField, Tooltip("The crosshair sprite color used when hovering over an interactable object. ")] private Color crosshairCanSelectColor;
    [Tooltip("The default crosshair sprite color. ")] private Color crosshairDefaultColor;
    [Tooltip("The bool to determine if the player is hovering over an object that is interactable. ")] private bool canInteract = false;
    [Tooltip("Bool to determine if an object is currently being held. ")] private bool objectHeld = false;
    [Tooltip("The current object hovered over. ")] private GameObject hoveredObject;
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

    //Call to enable controls
    private void OnEnable()
    {
        controls.Enable();
    }

    //Call to disable controls
    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(move);

        if(!objectHeld)
        {
            HoverObject();
        }

        if (canInteract || objectHeld)
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
                hoveredObject = hit.transform.gameObject;
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

    /// <summary>
    /// Handles selecting the interactable object.
    /// </summary>
    private void SelectObject()
    {
        hoveredObject.GetComponent<InteractableObject>().Interact();
    }

    /// <summary>
    /// Sets whether an object is being held.
    /// </summary>
    /// <param name="heldStatus">The new held status. </param>
    public void SetHoldingStatus(bool heldStatus)
    {
        objectHeld = heldStatus;
    }

    /// <summary>
    /// Returns whether an object is currently being held or not.
    /// </summary>
    /// <returns>Returns true if an object is held, false otherwise. </returns>
    public bool GetHoldingStatus()
    {
        return objectHeld;
    }

    /// <summary>
    /// Returns the hand object. 
    /// </summary>
    /// <returns></returns>
    public GameObject GetHand()
    {
        return hand;
    }
}
