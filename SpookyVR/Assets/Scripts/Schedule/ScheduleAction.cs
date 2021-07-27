using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScheduleAction : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField, Tooltip("The alpha of this schedule action object while it is being dragged. "), Range(0, 1)] private float alphaDragging = 1f;
    [SerializeField, Tooltip("The alpha of this schedule action object when it's placed. "), Range(0, 1)] private float alphaPlaced = 1f;

    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private bool objectHeldStatus = false;
    private GameObject heldObject;

    private ScheduleSlotData slotDroppedOn;

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

    public void SetScheduleSlotData(ScheduleSlotData thisSlot)
    {
        slotDroppedOn = thisSlot;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
        canvasGroup.alpha = alphaDragging;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Mouse.current.position.ReadValue();
        canvasGroup.blocksRaycasts = false;
        //canvasGroup.alpha = alphaDragging;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = alphaPlaced;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(slotDroppedOn != null)
        {
            slotDroppedOn.SetActionHeld(null);
            slotDroppedOn = null;
        }
    }
}
