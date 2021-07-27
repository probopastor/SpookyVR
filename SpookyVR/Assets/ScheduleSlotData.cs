using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScheduleSlotData : MonoBehaviour, IDropHandler
{
    [SerializeField, Tooltip("The position of the day this slot will occur at. This is its position in the schedule, not the time of day. ")] private int slotPos;
    private GameObject actionHeld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActionHeld(GameObject action)
    {
        actionHeld = action;
    }

    public GameObject GetActionHeld()
    {
        return actionHeld;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");
        
        if(eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.position = gameObject.transform.position;
        }
    }
}
