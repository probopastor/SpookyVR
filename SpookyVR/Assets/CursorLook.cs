using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorLook : MonoBehaviour
{
    private InputMaster playerControlls;

    [SerializeField, Tooltip("The default look sensitivity. ")] private float mouseSensitivity = 100f;
    [Tooltip("Stores the mouse direction from the Input Manager. ")] private Vector2 mouseLook;
    [Tooltip("The rotation of the camera based on the mouse direction. Clamps should occur directly on this variable. ")] private float xRotation = 0f;

    [Tooltip("The player's transform. ")] private Transform playerBody;

    private void Awake()
    {
        playerControlls = new InputMaster();
        playerBody = FindObjectOfType<PlayerBehavior>().transform;

        Cursor.lockState = CursorLockMode.Locked;
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
        Look();
    }

    /// <summary>
    /// Handles the player looking around when moving their mouse. 
    /// </summary>
    private void Look()
    {
        // Gets the mouse direction from Input. 
        mouseLook = playerControlls.Player.Look.ReadValue<Vector2>();

        // Rotates the camera over time to where the mouse is looking.
        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        // Clamps the xRotation on the Y axis to prevent a full 360 view on Y. 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
