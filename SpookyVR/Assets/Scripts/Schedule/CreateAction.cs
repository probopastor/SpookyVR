using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateAction : MonoBehaviour
{
    [SerializeField] private GameObject scheduleActionObject;

    [SerializeField] private int actionType = 0;
    [SerializeField] private int buildingType = 0;
    [SerializeField] private int npcType = 0;

    //[Tooltip("0 is morning, 1 is day, 2 is night. REGARDLESS OF ACTIONS PER DAY, THESE VALUES WILL BE CORRECT.")] private int timeOfAction = 0;
    private void Awake()
    {
        CreateActionObject();
    }

    public void CreateActionObject()
    {
        // Instantiates this action object and child it to the canvas (since it will be an image)
        Vector3 actionObjSpawnLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 10f);

        GameObject scheduleActionObjectClone = Instantiate<GameObject>(scheduleActionObject, actionObjSpawnLocation, Quaternion.identity);
        scheduleActionObjectClone.transform.parent = GameObject.FindGameObjectWithTag("ScheduleCanvas").transform;
        scheduleActionObjectClone.GetComponent<CanvasGroup>().alpha = 0;

        // Fills in action object's action parameters
        scheduleActionObjectClone.GetComponent<ScheduleAction>().FillActionParameters(actionType, buildingType, npcType);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ScheduleAction"))
        {
            CreateActionObject();
        }
    }
}
