using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorLook : MonoBehaviour
{
    private InputMaster playerControlls;

    private float mouseSensitivity = 100f;
    private Vector2 mouseLook;
    private float xRotation = 0f;

    [SerializeField] private Transform playerBody;

    private void Awake()
    {
        playerControlls = new InputMaster();
        playerBody = FindObjectOfType<PlayerBehavior>().transform;

        Cursor.lockState = CursorLockMode.Locked;
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
        Look();
    }

    private void Look()
    {
        mouseLook = playerControlls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
