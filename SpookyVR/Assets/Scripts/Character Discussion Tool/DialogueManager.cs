using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField]
    private GameManager gamenManager;

    [SerializeField]
    private List<Character> character = new List<Character>();

    [SerializeField] 
    private TextMeshProUGUI dialogueBoxText;


    private void Awake()
    {
        InitializeVariables();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("The current Level Manager is: " + gamenManager.GetLevelManager().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeVariables()
    {

        Debug.Log("This method was called");
        gamenManager = FindObjectOfType<GameManager>();
        //dialogueBoxText = 
    }

    private void FillCharactersList(List<Character> characters)
    {

    }

}
