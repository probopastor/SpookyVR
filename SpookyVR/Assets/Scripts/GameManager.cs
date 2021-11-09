/* 
* Glory to the High Council
* William Nomikos
* GameManager.cs
* Handles game states across the entire game. Figures out when levels need to be reset, what state the levels are in, 
* and what actions are being performed.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Schedule;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    #region Variables
    [Tooltip("The ID of the current level. ")] private int levelID;
    [SerializeField, Tooltip("The resource manager for every world location.")] private ResourceManager[] resourceManagers;
    [Tooltip("The current level's Resource Manager. ")] private ResourceManager resourceManager;

    [Tooltip("A list of Days, with each day having a list of Actions that have been scheduled. Used to progress through the level. ")] private List<Days> theDays;

    [Tooltip("The current Level's level manager. ")] private LevelManager levelManager;
    [Tooltip("Maintains whether the scheduling phase is in progress or not. ")] private bool schedulePhase = false;

    // [Tooltip(" ")] private List<Days> scheduleDays = new List<Days>();

    [Tooltip(" ")] private GameObject[] levelLocations;
    [Tooltip(" ")] private GameObject[] meetingLocations;


    [Tooltip(" ")] private GameObject[] scheduleCanvasObjsToHide;
    [Tooltip(" ")] private List<GameObject> scheduleActionsCreated = new List<GameObject>();
    [Tooltip(" ")] private bool actionComplete = false;
    public static GameManager _gameManager;
    #endregion

    #region Cheat Code Variables
    [Tooltip("The Master Input Map. ")] private InputMaster controls;
    bool cheatEntered = false;
    #endregion

    #region Start Up Methods
    private void Awake()
    {
        if (_gameManager != null && _gameManager != this)
        {
            Destroy(_gameManager.gameObject);
        }
        else
        {
            _gameManager = this;
            DontDestroyOnLoad(_gameManager.gameObject);
        }

        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    //Call to disable controls
    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        scheduleCanvasObjsToHide = GameObject.FindGameObjectsWithTag("ScheduleToHide");
        SetLevelData();
        schedulePhase = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.CheatCodes.Cheats.triggered)
        {
            Debug.Log("Cheat entered");
            cheatEntered = true;
            //theDays[i].actionsToday[x].SetActionInProgress(false);
        }

        if (controls.CheatCodes.ResetGame.triggered)
        {
            Debug.Log("Cheat entered");

            resourceManager.SetCurrentWeek(0);
            SetLevelData();
            Debug.Log("Current Week: " + resourceManager.GetCurrentWeek());
        }
    }

    #endregion

    #region Run Week Methods

    /// <summary>
    /// Begins the current week, cycling the player through all scheduled actions passed in via a list of Days.
    /// </summary>
    /// <param name="theDays">The entire scheduled week to cycle through.</param>
    /// <returns></returns>
    public IEnumerator BeginWeek(List<Days> theDays)
    {
        Debug.Log("This occurs");

        // Set the schedule phase of the game to false, as actions are now progressing
        schedulePhase = false;


        // Cycle through theDays
        for (int i = 0; i < theDays.Count; i++)
        {
            cheatEntered = false;

            // Cycle through the actiosn scheduled per day
            for (int x = 0; x < theDays[i].actionsToday.Count; x++)
            {
                // If there is not currently an action in progress
                if (!theDays[i].actionsToday[x].GetActionInProgress())
                {
                    // Set the action in progress
                    theDays[i].actionsToday[x].SetActionInProgress(true);

                    // Cycle through objects to hide in the schedule and disable them
                    foreach (GameObject obj in scheduleCanvasObjsToHide)
                    {
                        obj.SetActive(false);
                    }

                    // Begin the action
                    theDays[i].actionsToday[x].BeginAction();

                    Debug.Log("Current Action Type: " + theDays[i].actionsToday[x].actionType);
                    Debug.Log("Current Building Type: " + theDays[i].actionsToday[x].buildingType);
                    Debug.Log("Current NPC Type: " + theDays[i].actionsToday[x].npcType);
                }

                // Continue to stay on this action until the action is no longer in progress
                while (theDays[i].actionsToday[x].GetActionInProgress())
                {
                    if (cheatEntered || actionComplete)
                    {
                        cheatEntered = false;
                        actionComplete = false;
                        Debug.Log("Cheat entered");
                        theDays[i].actionsToday[x].SetActionInProgress(false);
                    }
                    else
                    {
                        yield return null;
                    }
                }

                // yield return new WaitUntil(() => (theDays[i].actionsToday[x].GetActionInProgress() == false) || cheatEntered);
            }
        }

        yield return new WaitForEndOfFrame();

        resourceManager.UpdateCurrentWeek(1);


        // Cycle through objects to hide in the schedule and reenable them
        foreach (GameObject obj in scheduleCanvasObjsToHide)
        {
            obj.SetActive(true);
        }

        // Refresh the schedule and update the display resources
        FindObjectOfType<ScheduleCreation>().RefreshSchedule();
        FindObjectOfType<DisplayResources>().UpdateDisplayedResources();

        // Ensure that all action location and meeting objects are disabled.
        SetAllActionsInactive();

        // As the week has ended, set the schedule phase to true.
        schedulePhase = true;

        Debug.Log("Current Week: " + resourceManager.GetCurrentWeek());

        // Clear old schedule action objects
        ClearScheduleButtons();
    }

    /// <summary>
    /// Clears all old schedule action objects from the previous week
    /// </summary>
    private void ClearScheduleButtons()
    {
        GameObject empty = new GameObject("Empty");

        GameObject[] scheduleActionObjsCreated = GameObject.FindGameObjectsWithTag("ScheduleAction");

        foreach (GameObject obj in scheduleActionObjsCreated)
        {
            // Unschedule any of the Schedule Actions that are currently scheduled
            if(obj.GetComponent<ScheduleAction>() != null)
            {
                obj.GetComponent<ScheduleAction>().ForceClearFromSchedule();
            }

            // If this object is active
            if(obj.GetComponent<CanvasGroup>().alpha != 0)
            {
                // Sets the parent of the schedule action to the empty Game Object
                obj.transform.SetParent(empty.transform);
            }
        }

        // Destroys the empty object with all of the old actions childed to it (destroying them regularly breaks the canvas buttons)
        Destroy(empty.gameObject);

        CreateAction[] allCreateActionsSources = FindObjectsOfType<CreateAction>();

        // Recreates action objects on any buttons that had their invisible ones removed
        foreach (CreateAction theActionSource in allCreateActionsSources)
        {
            theActionSource.CreateActionObject();
        }

        GameObject[] actionsPanels = GameObject.FindGameObjectsWithTag("ActionsPanel");

        // Cycle through actions panels to disable them on reload start
        foreach (GameObject obj in actionsPanels)
        {
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Sets the current action to be complete or incomplete. 
    /// </summary>
    /// <param name="progressState">True if action is complete, false otherwise. </param>
    public void SetCurrentActionComplete(bool progressState)
    {
        actionComplete = progressState;
    }

    #endregion

    #region Start Week Methods

    /// <summary>
    /// Sets the proper Action Location to be active when the action is ready. To be called from Actions.
    /// </summary>
    /// <param name="index">The location index. </param>
    /// <param name="characterMeeting">Set to true if this action should take place in a meeting, false if its a location overview. </param>
    public void SetActionActive(int index, bool characterMeeting)
    {
        // If this is a Location Action (such as inspect)
        if (!characterMeeting)
        {
            // Set the correct location based on the index to be active, and other locations to be inactive.
            for (int i = 0; i < levelLocations.Length; i++)
            {
                levelLocations[i].SetActive(false);

                if (i == index)
                {
                    // TODO: Schedule animation plays here?... maybe turn this into coroutine later
                    levelLocations[i].SetActive(true);
                }
            }
        }
        // If this is a Character Action (such as talk to)
        else
        {
            // Set the correct character meeting based on the index to be active, and other locations to be inactive.
            for (int i = 0; i < meetingLocations.Length; i++)
            {
                if (i == index)
                {
                    meetingLocations[i].SetActive(true);
                }
                else
                {
                    meetingLocations[i].SetActive(false);
                }
            }
        }
    }

    private void SetAllActionsInactive()
    {
        for (int i = 0; i < levelLocations.Length; i++)
        {
            levelLocations[i].SetActive(false);
        }

        for (int i = 0; i < meetingLocations.Length; i++)
        {
            meetingLocations[i].SetActive(false);
        }
    }

    #endregion 

    #region Set Level Methods
    /// <summary>
    /// Sets the level manager data, resource, data, etc., for a given level.
    /// </summary>
    public void SetLevelData()
    {
        // Obtain the levelID of the loaded level manager.
        levelID = levelManager.GetLevelID();

        // Set the proper resource manager based on the levelID.
        resourceManager = resourceManagers[levelID];

        // If the current week is 0, then reset run information. 
        if (resourceManager.GetCurrentWeek() == 0)
        {
            // Set this level manager's resource manager to the one used.
            levelManager.SetResourceManager(resourceManager);

            // Reset level data.
            levelManager.ResetLevelData();

            // Update all display resources shown to the player.
            FindObjectOfType<DisplayResources>().UpdateDisplayedResources();

            // Switch statement handles setting individual location and character data for all levels from the Level Manager. Use nested Switch statements for individual divergence levels.
            //switch (levelID)
            //{
            //    case 0:
            //        // Get Otlo Location List from OtloLevelManager
            //        // Get Otlo Character List from OtloLevelManager
            //        break;
            //    case 1:
            //        // Get Atlantis Location List from AtlantisLevelManager
            //        // Get Atlantis Character List from AtlantisLevelManager
            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    case 4:
            //        break;
            //    case 5:
            //        break;
            //    case 6:
            //        break;
            //    case 7:
            //        break;
            //    case 8:
            //        break;
            //}

            // Cycle through objects to hide in the schedule and reenable them
            foreach (GameObject obj in scheduleCanvasObjsToHide)
            {
                obj.SetActive(true);
            }

            GameObject[] actionsPanels = GameObject.FindGameObjectsWithTag("ActionsPanel");

            // Cycle through actions panels to disable them on game start
            foreach (GameObject obj in actionsPanels)
            {
                obj.SetActive(false);
            }

            #region Set Up Location Objects
            levelLocations = FindObjectOfType<LevelManager>().GetLevelLocationObjects();

            // Cycle through all the level locations to ensure all are inactive.
            for (int i = 0; i < levelLocations.Length; i++)
            {
                levelLocations[i].SetActive(false);
            }

            #endregion

            #region Set Up Meeting Objects

            meetingLocations = FindObjectOfType<LevelManager>().GetCharacterLocationObjects();

            // Cycle through all the character meeting locations to ensure all are inactive.
            for (int i = 0; i < meetingLocations.Length; i++)
            {
                meetingLocations[i].SetActive(false);
            }

            #endregion 
        }
    }

    #endregion 
}
