/* 
* Glory to the High Council
* CJ Green
* DialogueHandler.cs
* 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using Febucci.UI;

public class DialogueHandler : MonoBehaviour
{
    /// <summary>
    /// Is a Singleton...
    /// </summary>
    //private DialogueManager dialogueManager;

    [SerializeField]
    private LocationDialogue locationsDialogue;


    [SerializeField]
    private TextMeshProUGUI locationDialogueBoxText;

    [SerializeField]
    private TextMeshProUGUI clickToContinueObj;

    private int currentIntroDialogueIndex = 0;
    private int currentIntroDialogueTextIndex = 0;

    private int currentMainDialogueIndex = 0;
    private int currentMainDialogueTextIndex = 0;



    [SerializeField, Tooltip("")]
    private TextAnimatorPlayer textAnimPlayer_Ref;


    private void OnEnable()
    {
        SetActiveDialigueState();
        PlayDialogue();

        //textAnimPlayer_Ref = gameObject.GetComponent<TextAnimatorPlayer>();

        //StartDialogue()
    }

    private void OnDisable()
    {
        SetActiveDialigueState();
    }

    // Handles loading the correct Text based off of the Character(s) being spoken to.

    public void ClickToContinue(bool isWaitingForInput)
    {
        if(isWaitingForInput == true)
        {
            clickToContinueObj.gameObject.SetActive(true);
        }
        else
        {
            clickToContinueObj.gameObject.SetActive(false);
        }
    }

    private void PlayDialogue()
    {
        //We will assume this is the first time you meet this character/or characters.

        StartIntroDialogue(currentIntroDialogueIndex, currentIntroDialogueTextIndex);
        //StartMainDialogue();

        currentIntroDialogueIndex = 1;
        currentIntroDialogueTextIndex = 0;

        locationDialogueBoxText.text = locationsDialogue.GetIntroDialogueList()[currentIntroDialogueIndex].GetTextAtIndex(currentIntroDialogueTextIndex);


    }

    public void StartIntroDialogue(int dialogueListIndex, int dialogueTextIndex)
    {
        locationDialogueBoxText.text = locationsDialogue.GetIntroDialogueList()[dialogueListIndex].GetTextAtIndex(dialogueTextIndex);
    }

    public void StartMainDialogue(int dialogueListIndex, int dialogueTextIndex)
    {
        locationDialogueBoxText.text = locationsDialogue.GetIntroDialogueList()[dialogueListIndex].GetTextAtIndex(dialogueTextIndex);
    }

    /// <summary>
    /// Sets the currently active DialogueHandler to be the Active one.
    /// </summary>
    public void SetActiveDialigueState()
    {
        if (gameObject.activeInHierarchy == true)
        {
            DialogueManager.Instance.SetActiveDialogue(gameObject.GetComponent<DialogueHandler>());
        }
        else if (gameObject.activeInHierarchy == false)
        {
            DialogueManager.Instance.SetActiveDialogue(null);
        }
    }


    #region Getters and Setters

    public LocationDialogue GetLocationDialogue()
    {
        return locationsDialogue;
    }

    public int GetCurrentIntroDialogueIndex()
    {
        return 0;
    }

    public int GetCurrentMainDialogueIndex()
    {
        return 0;
    }

    public TextAnimatorPlayer GetTextAnimatorPlayer()
    {
        return textAnimPlayer_Ref;
    }


    #endregion

}
