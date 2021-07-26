using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScheduleAction : MonoBehaviour
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
        gameObject.transform.position = Mouse.current.position.ReadValue();
    }

    public void FillActionParameters(int actionType, int buildingType, int npcType)
    {

    }
}
