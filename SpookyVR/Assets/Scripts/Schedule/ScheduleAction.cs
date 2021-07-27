using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScheduleAction : MonoBehaviour
{
    private List<GameObject> slotsTriggered = new List<GameObject>();
    private GameObject closestSlotObj;

    private float closestSlotObjDist = Mathf.Infinity;
    private bool smallAction = true;
    private ScheduleSlotData thisScheduleSlot;

    public void FillActionParameters(int actionType, int buildingType, int npcType)
    {

    }

    private void Update()
    {
        if (slotsTriggered.Count > 0)
        {
            foreach (GameObject obj in slotsTriggered)
            {
                Debug.Log("Obj: " + obj.name);
            }
        }
        else
        {
            Debug.Log("Nothing in slotsTriggered");
        }
    }

    public void SetScheduleSlotData(ScheduleSlotData newSlotData)
    {
        thisScheduleSlot = newSlotData;
        thisScheduleSlot.SetActionHeld(gameObject);
    }

    public void RefreshSlotData()
    {
        thisScheduleSlot.SetActionHeld(null);
        //thisScheduleSlot = null;
    }

    /// <summary>
    /// Returns if this Schedule Action is a small action.
    /// </summary>
    /// <returns>Returns true if small action, false otherwise. </returns>
    public bool IsSmallAction()
    {
        return smallAction;
    }

    /// <summary>
    /// Returns the closest Slot Object to the Schedule Action Object.
    /// </summary>
    /// <returns></returns>
    public GameObject GetClosestSlotObject()
    {
        FindClosestSlotObj();
        return closestSlotObj;
    }

    /// <summary>
    /// Finds the closest Slot Object to the Schedule Action Object.
    /// </summary>
    private void FindClosestSlotObj()
    {
        float thisObjDist;

        // Cycles through all objects triggered by the Schedule Action Object.
        for (int i = 0; i < slotsTriggered.Count; i++)
        {
            // Compare this Slot Object's distance to the current closest Slot Object's distance.
            thisObjDist = (slotsTriggered[i].transform.position - gameObject.transform.position).magnitude;

            if (thisObjDist < closestSlotObjDist)
            {
                // If it's closer, update the closest Slot Object information.
                closestSlotObjDist = thisObjDist;
                closestSlotObj = slotsTriggered[i];
            }
        }
    }

    public void RefreshClosestSlotObject()
    {
        closestSlotObj = null;
        closestSlotObjDist = Mathf.Infinity;

        foreach(GameObject obj in slotsTriggered)
        {
            slotsTriggered.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ActionSlot"))
        {
            slotsTriggered.Add(other.gameObject);

            if (closestSlotObj == null)
            {
                closestSlotObj = other.gameObject;
                closestSlotObjDist = (other.gameObject.transform.position - gameObject.transform.position).magnitude;
            }
        }
        else if(other.CompareTag("DeleteAction"))
        {
            // Delete color here.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ActionSlot"))
        {
            if (slotsTriggered.Contains(other.gameObject))
            {
                slotsTriggered.Remove(other.gameObject);
                FindClosestSlotObj();
            }
        }
    }
}
