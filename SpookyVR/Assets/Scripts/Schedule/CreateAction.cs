/* 
* Glory to the High Council
* William Nomikos
* CreateAction.cs
* Creates an action with a set actionType, buildingType, and npcType to then be scheduled. 
* Generally should be called from action buttons in scene.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Schedule
{
    public class CreateAction : MonoBehaviour
    {
        [SerializeField, Tooltip("The schedule action object to be dragged by the player to the schedule. ")] private GameObject scheduleActionObject;

        enum ActionDuration { shortAction, mediumAction, longAction };
        [SerializeField, Tooltip("The amount of slots on the schedule this action will take up. Short action = 1 slot, medium action = 2 slots, long action = 3 slots.")] private ActionDuration actionDuration;

        [SerializeField, Tooltip("The action ID of the spawned schedule action object. ")] private int actionType = 0;
        [SerializeField, Tooltip("The building ID of the spawned schedule action object. ")] private int buildingType = 0;
        [SerializeField, Tooltip("The NPC ID of the spawned schedule action object. ")] private int npcType = 0;

        private void Awake()
        {
            CreateActionObject();
        }

        /// <summary>
        /// Instantiates a schedule action object and fills in its parameters so that it's ready to be scheduled by the player. 
        /// </summary>
        public void CreateActionObject()
        {
            // Instantiates this action object and child it to the canvas (since it will be an image)
            Vector3 actionObjSpawnLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 10f);

            GameObject scheduleActionObjectClone = Instantiate<GameObject>(scheduleActionObject, actionObjSpawnLocation, Quaternion.identity);

            scheduleActionObjectClone.GetComponent<ScheduleAction>().SetCreationSource(this);

            //scheduleActionObjectClone.transform.parent = GameObject.FindGameObjectWithTag("ScheduleCanvas").transform;

            scheduleActionObjectClone.transform.SetParent(this.gameObject.transform);
            scheduleActionObjectClone.GetComponent<CanvasGroup>().alpha = 0;

            // Fills in action object's action parameters
            scheduleActionObjectClone.GetComponent<ScheduleAction>().FillActionParameters(actionType, buildingType, npcType, (int)actionDuration);
        }


        private void OnTriggerExit(Collider other)
        {
            // Spawns a new schedule action object if the previous one is dragged off of the object CreateAction is on.
            if (other.CompareTag("ScheduleAction"))
            {
                //CreateActionObject();
            }
        }
    }
}