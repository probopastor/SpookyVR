/* 
* Glory to the High Council
* CJ Green
* DialogueManager.cs
* This class is Singleton so reference as: DialogueManager.Instance (See Singleton.cs for more details).
* 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Febucci.UI; // Makes it so that I can reference TextAnimatorPlayer or other Scripts associated with the Febucci namespace.  


public class DialogueManager : Singleton<DialogueManager>
{
   
    // Game Manager is a Singleton. Reference as: GameManager._gameManager


    [SerializeField]
    private List<Character> charactersToSpeakTo = new List<Character>();

    [SerializeField]
    private List<GameObject> dialogueLocations = new List<GameObject>();

    [SerializeField, Tooltip("")]
    private DialogueHandler activeDialogue = null;

    //[SerializeField, Tooltip("")]
    //private TextAnimatorPlayer textAnimPlayer_Ref;


    private void Awake()
    {
        //textAnimPlayer_Ref = activeDialogue.GetComponent<TextAnimatorPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("The current Level Manager is: " + gamenManager.GetLevelManager().name);

    }

    // Update is called once per frame
    void Update()
    {
        activeDialogue.ClickToContinue();
    }

    private void ContinueDialogue()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //activeDialogue
        }
    }

    public void StartDialogue(DialogueHandler dialogueToStart)
    {
        
    }

    #region Getters and Setters

    /// <summary>
    /// Gets the reference to the List of Characters to be spoken to
    /// </summary>
    /// <returns></returns>
    public List<Character> GetCharactersToSpeakTo()
    {
        return charactersToSpeakTo;
    }

    /// <summary>
    /// Gets the reference to the List of Locations "Canvases" to be utlized.
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetDialogueLocations()
    {
        return dialogueLocations;
    }

    public DialogueHandler GetActiveDialogue()
    {
        return activeDialogue;
    }

    public void SetActiveDialogue(DialogueHandler dialogueHandler)
    {
        activeDialogue = dialogueHandler;
    }

    #endregion
}
