/* 
* Glory to the High Council
* CJ Green, William Nomikos
* LocationIntroDialogue.cs
* ...Description of the script...
* ...
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Febucci.UI;

public class LocationIntroDialogue : MonoBehaviour
{
    [SerializeField, Tooltip("A list containing all of a locations spoken Intro Dialogue. ")] private List<Interactions> introDialog = new List<Interactions>(1);
    [Tooltip(" ")] private TopicParser topicParser;

    #region Character Image & Location Images
    [Space(10)]
    [Header("Character & Location Image References")]
    [Space(10)]
    [SerializeField, Tooltip("Left most character image. Leave blank if non-applicable.")] private Image characterImageLeft;
    [SerializeField, Tooltip("Center most character image. Leave blank if non-applicable.")] private Image characterImageCenter;
    [SerializeField, Tooltip("Right most character image. Leave blank if non-applicable.")] private Image characterImageRight;

    [SerializeField, Tooltip("The location image. ")] private Image locationImage;
    #endregion

    #region Character Variables

    [SerializeField, Tooltip(" ")] private Character characterLeft;
    [SerializeField, Tooltip(" ")] private Character characterCenter;
    [SerializeField, Tooltip(" ")] private Character characterRight;

    #endregion

    #region Text Reference & SO Setup Variables

    [Space(10)]
    [Header("Text / Scriptable Object References")]
    [Space(10)]

    [SerializeField, Tooltip("The TMP this location will display its text to. ")] private TextMeshProUGUI locationDialogBoxText;
    [Tooltip("The Text Animator this TMP will use. ")] private TextAnimator textAnimator;
    [Tooltip("The Text Animator Player this TMP will use. ")] private TextAnimatorPlayer textAnimatorPlayer;

    #endregion

    #region Text State Maintence Variables
    [Tooltip("True if the introduction is complete, false otherwise. ")] private bool introductionComplete = false;
    #endregion 

    [Tooltip(" ")] private DialogHandler dialogHandler;

    private void Start()
    {
        dialogHandler = FindObjectOfType<DialogHandler>();
        topicParser = FindObjectOfType<TopicParser>();
    }

    private void OnEnable()
    {
        DialogSetup();
        BeginDialog();
    }

    private void OnDisable()
    {
        introductionComplete = false;
    }

    /// <summary>
    /// Handles setting up necessary variables for dialog to be properly performed. 
    /// </summary>
    private void DialogSetup()
    {
        if(dialogHandler == null)
        {
            dialogHandler = FindObjectOfType<DialogHandler>();
        }

        textAnimator = locationDialogBoxText.GetComponent<TextAnimator>();
        textAnimatorPlayer = locationDialogBoxText.GetComponent<TextAnimatorPlayer>();

        dialogHandler.SetTextAnimator(textAnimator);
        dialogHandler.SetTextAnimatorPlayer(textAnimatorPlayer);

        introductionComplete = false;
    }

    private void BeginDialog()
    {
        if (!introductionComplete)
        {
            introductionComplete = true;

            // If the right character has not been met, set to met
            //if (!characterRight.GetMetStatus())
            //{
            //    characterRight.SetMetStatus(true);
            //}

            //// If the left character has not been met, set to met.
            //if (!characterLeft.GetMetStatus())
            //{
            //    characterLeft.SetMetStatus(true);
            //}

            // If this character has not been met, run their first interaction dialog
            if (!characterCenter.GetMetStatus())
            {
                // Set this character to Met
                characterCenter.SetMetStatus(true);
                StartCoroutine(dialogHandler.RunDialog(introDialog[0].GetTextStates()));
            }
            // If this character is met, run dialog based on character trust
            else
            {
                //List<TextState> parsedTopic = topicParser.ParseInteractions(introDialog, characterCenter);
                //topicParser.SubmitDialog(parsedTopic, dialogHandler);

                StartCoroutine(dialogHandler.RunDialog(introDialog[1].GetTextStates()));
            }
        }
        else
        {
            // Run Main Dialog here

            if (!dialogHandler.GetRunDialogInProgress())
            {
                
            }
            else
            {
                BeginDialog();
            }
        }
    }


    /// <summary>
    /// Returns an Interactions List of intro dialog for a location.
    /// </summary>
    /// <returns>A List of Interactions. </returns>
    public List<Interactions> GetIntroDialogueList()
    {
        return introDialog;
    }
}
