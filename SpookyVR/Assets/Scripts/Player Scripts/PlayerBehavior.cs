using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("The player's movement speed.")] private float playerSpeed = 1f;

    [Tooltip("The Master Input Map. ")] private InputMaster controls;
    [Tooltip("The movement vector that will be altered based on player input. ")] private Vector3 move;
    [Tooltip("The player's Rigidbody. ")] private Rigidbody rb;

    private void Awake()
    {
        controls = new InputMaster();

        controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => move = Vector3.zero;

        rb = GetComponent<Rigidbody>();
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
}
