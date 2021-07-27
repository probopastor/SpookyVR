using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ScheduleAction : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private bool objectHeldStatus = false;
    private GameObject heldObject;

    private void Awake()
    {
        controls = new InputMaster();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void FillActionParameters(int actionType, int buildingType, int npcType)
    {

    }

    private void Update()
    {
        if(objectHeldStatus)
        {
            heldObject.transform.position = Mouse.current.position.ReadValue();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //gameObject.transform.position = Mouse.current.position.ReadValue();
        //canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag ended");
        //canvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag started");
    }

    /// <summary>
    /// Sets the currently set object.
    /// </summary>
    /// <param name="objectToHold">The new Game Object to be held.</param>
    public void SetHeldObject(GameObject objectToHold)
    {
        heldObject = objectToHold;
    }

    /// <summary>
    /// Gets whether or not an object is currently being held.
    /// </summary>
    /// <returns>Returns true if an object is being held, false otherwise.</returns>
    public bool GetObjectHeldStatus()
    {
        return objectHeldStatus;
    }
}
