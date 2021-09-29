/* 
* Glory to the High Council
* CJ Green
* DialogueHandler.cs
* 
*/

using Febucci.UI;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
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

    private bool coroutineStarted = false;



    [SerializeField, Tooltip("")]
    private TextAnimatorPlayer textAnimPlayer_Ref;
    [SerializeField, Tooltip("")]
    private TextAnimator textAnim_Ref;


    private void OnEnable()
    {
        SetActiveDialigueState();
        PlayDialogue();
    }

    private void OnDisable()
    {
        SetActiveDialigueState();
    }

    // Handles loading the correct Text based off of the Character(s) being spoken to.

    public void ClickToContinue()
    {
        if (textAnim_Ref.allLettersShown && !coroutineStarted)
        {
            //clickToContinueObj.gameObject.SetActive(true);
            StartCoroutine(ClickToContinueBlink());
            
            //if(true)
            //{
            //    StartMainDialogue(0, 1);
            //}


        }
        else if (!textAnim_Ref.allLettersShown)
        {
            clickToContinueObj.gameObject.SetActive(false);
            coroutineStarted = false;
            StopCoroutine(ClickToContinueBlink());
        }
    }

    public IEnumerator ClickToContinueBlink()
    {
        coroutineStarted = true;

        clickToContinueObj.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        clickToContinueObj.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        StartCoroutine(ClickToContinueBlink());
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
        locationDialogueBoxText.text = locationsDialogue.GetMainDialogueList()[dialogueListIndex].GetTextAtIndex(dialogueTextIndex);
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

    public TextAnimator GetTextAnimator()
    {
        return textAnim_Ref;
    }


    #endregion

}
