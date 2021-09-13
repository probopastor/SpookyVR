﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private int levelID;
    [SerializeField, Tooltip("The resource manager for every world location.")] private ResourceManager[] resourceManagers;
    [Tooltip(" ")] private LevelManager levelManager;
    [Tooltip(" ")] private bool schedulePhase = false;


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
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelData()
    {
        levelID = levelManager.GetLevelID();

        resourceManager = resourceManagers[levelID];

        if (resourceManager.GetCurrentWeek() == -1)
        {
            levelManager.ResetLevelData(resourceManager);
        }

    }
}