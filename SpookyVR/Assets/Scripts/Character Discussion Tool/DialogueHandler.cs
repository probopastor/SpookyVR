/* 
* Glory to the High Council
* CJ Green, William Nomikos
* DialogueHandler.cs
* 
*/

using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class DialogueHandler : MonoBehaviour
{
    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    #region Text Reference & SO Setup Variables

    [Space(10)]
    [Header("Text / Scriptable Object References")]
    [Space(10)]

    [SerializeField, Tooltip("The LocationDialogue Scriptable Object this location will reference its dialog from.")] private LocationDialogue locationsDialog;
    [SerializeField, Tooltip("The TMP this location will display its text to. ")] private TextMeshProUGUI locationDialogBoxText;
    [Tooltip("The Text Animator this TMP will use. ")] private TextAnimator textAnimator;

    #endregion

    #region Character Variables

    [SerializeField, Tooltip(" ")] private Character characterLeft;
    [SerializeField, Tooltip(" ")] private Character characterCenter;
    [SerializeField, Tooltip(" ")] private Character characterRight;

    #endregion 

    #region Image Variables
    [Space(10)]
    [Header("Character References")]
    [Space(10)]
    [SerializeField, Tooltip("Left most character image Leave blank if non-applicable.")] private Image characterImageLeft;
    [SerializeField, Tooltip("Center most character image. Leave blank if non-applicable.")] private Image characterImageCenter;
    [SerializeField, Tooltip("Right most character image. Leave blank if non-applicable.")] private Image characterImageRight;

    [SerializeField, Tooltip("The location image. ")] private Image locationImage;
    #endregion

    #region Character Audio Variables
    // LEFT MOST CHARACTER SOUND
    // CENTER MOST CHARACTER SOUND
    // RIGHT MOST CHARACTER SOUND
    #endregion

    #region Text State Maintence Variables

    [Tooltip("Maintains whether or not continue was pressed. ")] private bool continuePressed = false;
    [Tooltip("True if the introduction is complete, false otherwise. ")] private bool introductionComplete = false;

    #endregion

    #region Text To Display
    [Tooltip("The list of all Intro Dialog in this location. ")] private List<Interactions> introDialogInteractions;
    [Tooltip("The list of all Main Dialog in this location. ")] private List<Interactions> mainDialogInteractions;
    #endregion 

    [SerializeField] private TextMeshProUGUI clickToContinueObj;

    private bool coroutineStarted = false;





    #region Text Startup Methods

    private void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.Enable();

        DialogSetup();
        BeginDialog();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (controls.Player.Continue.triggered)
        {
            continuePressed = true;
        }
    }

    /// <summary>
    /// Handles setting up necessary variables for dialog to be properly performed. 
    /// </summary>
    public void DialogSetup()
    {
        if (locationDialogBoxText.TryGetComponent(out TextAnimator animator))
        {
            textAnimator = animator;
        }

        // Obtains the intro dialog data
        introDialogInteractions = locationsDialog.GetIntroDialogueList();

        // Obtains the main dialog data
        mainDialogInteractions = locationsDialog.GetMainDialogueList();

        introductionComplete = false;
    }


    #endregion

    /// <summary>
    /// Begins the dialog and decides which dialog branch (TextState) should run.
    /// </summary>
    private void BeginDialog()
    {
        if(!introductionComplete)
        {
            introductionComplete = true;

            if (!characterCenter.GetMetStatus())
            {
                // Set this character to Met
                characterCenter.SetMetStatus(true);
                StartCoroutine(RunDialog(introDialogInteractions[0].GetTextStates()));
            }
            else
            {
                // Run intro text based on character trust here.
                // if(characterCenter.trust or whatever >= amount of low trust)... etc. 
            }
        }
        else
        {
            // Run Main Dialog here
        }
        
    }

    /// <summary>
    /// Cycles through the passed in dialog branch (TextState) and handles setting images, audio, etc., based on the TextState's instructions.
    /// </summary>
    /// <param name="textStates"></param>
    /// <returns></returns>
    private IEnumerator RunDialog(List<TextState> textStates)
    {
        for (int i = 0; i < textStates.Count; i++)
        {
            locationDialogBoxText.text = textStates[i].GetDialogueText();

            // Set character images
            // Set character dialog audio
            // Set other important stuff

            // Pause here until all letters are shown
            while (!textAnimator.allLettersShown)
            {
                yield return null;
            }

            // If text states do not automatically advance
            if (!textStates[i].GetContinueAutomaticallyStatus())
            {
                continuePressed = false;

                // Pause here until continue is pressed
                while (!continuePressed)
                {
                    yield return null;
                }
            }
        }

        yield return new WaitForEndOfFrame();

        BeginDialog();
    }



    public void ClickToContinue()
    {
        if (textAnimator.allLettersShown && !coroutineStarted)
        {
            //clickToContinueObj.gameObject.SetActive(true);
            StartCoroutine(ClickToContinueBlink());

            //if(true)
            //{
            //    StartMainDialogue(0, 1);
            //}
        }
        else if (!textAnimator.allLettersShown)
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


}
