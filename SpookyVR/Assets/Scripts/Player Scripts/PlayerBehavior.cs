using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("The player's movement speed.")] private float playerSpeed = 1f;

    private InputMaster playerControlls;
    private Vector3 move;
    private Rigidbody rb;

    private void Awake()
    {
        playerControlls = new InputMaster();

        playerControlls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerControlls.Player.Movement.canceled += ctx => move = Vector3.zero;

        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(move);
    }

    private void Movement(Vector3 direction)
    {
        Vector3 movement = new Vector3(direction.x * playerSpeed, 0, direction.y * playerSpeed);
        rb.velocity = movement;
    }
}
