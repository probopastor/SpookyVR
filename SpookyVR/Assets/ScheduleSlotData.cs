using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScheduleSlotData : MonoBehaviour, IDropHandler
{
    [SerializeField, Tooltip("The position of the day this slot will occur at. This is its position in the schedule, not the time of day. ")] private int slotPos;
    [SerializeField] private GameObject actionHeld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Returns if an action is currently held by this schedule slot.
    /// </summary>
    /// <returns>The action currently held by this schedule slot. </returns>
    public GameObject GetActionHeld()
    {
        return actionHeld;
    }

    /// <summary>
    /// Sets the action this schedule slot is holding.
    /// </summary>
    /// <param name="newAction">The new action this schedule slot is holding. Set to null if it is not holding anything. </param>
    public void SetActionHeld(GameObject newAction)
    {
        actionHeld = newAction;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");
        
        if(eventData.pointerDrag != null && actionHeld == null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.position = gameObject.transform.position;

            actionHeld = eventData.pointerDrag;
            actionHeld.GetComponent<ScheduleAction>().SetScheduleSlotData(this);
        }
    }
}
