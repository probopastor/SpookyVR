using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Tooltip(" ")] private int levelID;
    [SerializeField, Tooltip("The resource manager for every world location.")] private ResourceManager[] resourceManagers;

    [Tooltip(" ")] private List<Days> theDays;

    [Tooltip(" ")] private LevelManager levelManager;
    [Tooltip(" ")] private bool schedulePhase = false;


    [Tooltip(" ")] private ResourceManager resourceManager;

    public static GameManager _gameManager;

    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    bool cheatEntered = false;

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

        if(controls.CheatCodes.ResetGame.triggered)
        {
            Debug.Log("Cheat entered");

            resourceManager.SetCurrentWeek(0);
            SetLevelData();
            Debug.Log("Current Week: " + resourceManager.GetCurrentWeek());
        }
    }

    public IEnumerator BeginWeek(List<Days> theDays)
    {
        Debug.Log("This occurs");

        schedulePhase = false;

        for (int i = 0; i < theDays.Count; i++)
        {
            cheatEntered = false;

            for (int x = 0; x < theDays[i].actionsToday.Count; x++)
            {
                if (!theDays[i].actionsToday[x].GetActionInProgress())
                {
                    theDays[i].actionsToday[x].SetActionInProgress(true);
                    theDays[i].actionsToday[x].BeginAction();
                }
                while (theDays[i].actionsToday[x].GetActionInProgress())
                {
                    if (cheatEntered)
                    {
                        cheatEntered = false;
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
        FindObjectOfType<ScheduleCreation>().RefreshSchedule();

        schedulePhase = true;

        Debug.Log("Current Week: " + resourceManager.GetCurrentWeek());
    }

    public void SetLevelData()
    {
        levelID = levelManager.GetLevelID();

        resourceManager = resourceManagers[levelID];

        if (resourceManager.GetCurrentWeek() == 0)
        {
            levelManager.ResetLevelData(resourceManager);
        }

    }
}
