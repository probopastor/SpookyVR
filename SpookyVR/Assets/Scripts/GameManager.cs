using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private int levelID;
    [SerializeField, Tooltip("The resource manager for every world location.")] private ResourceManager[] resourceManagers;


    [Tooltip(" ")] private ResourceManager resourceManager;

    public static GameManager _gameManager;

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
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelData(int thisLevelID)
    {
        levelID = thisLevelID;

        resourceManager = resourceManagers[levelID];

        if (resourceManager.GetCurrentWeek() == -1)
        {
            // Reset OtloResourceManager information here
        }
        // else if(!gameManager.WeekInProgress()) { 
        // resourceManager.ResetCurrentWeek();
        // } 
    }
}
