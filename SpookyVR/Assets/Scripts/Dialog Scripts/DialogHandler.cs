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
public class DialogHandler : MonoBehaviour
{
    [Tooltip("The Master Input Map. ")] private InputMaster controls;

    #region Febucci References & TMPro use
    [Tooltip("The Text Animator this TMP will use. ")] private TextAnimator textAnimator;
    [Tooltip("The Text Animator Player this TMP will use. ")] private TextAnimatorPlayer textAnimatorPlayer;
    #endregion 

    #region Text State Maintence Variables
    [Tooltip("Maintains whether or not continue was pressed. ")] private bool continuePressed = false;
    [Tooltip("Maintains whether RunDialog is currently in progress. True if it is, false otherwise. ")] private bool runDialogInProgress = false;
    #endregion

    #region Text Startup Methods

    private void Awake()
    {
        //if (_dialogHandler != null && _dialogHandler != this)
        //{
        //    Destroy(_dialogHandler.gameObject);
        //}
        //else
        //{
        //    _dialogHandler = this;
        //    DontDestroyOnLoad(_dialogHandler.gameObject);
        //}

        controls = new InputMaster();
    }

    private void OnEnable()
    {
        controls.Enable();
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

    #endregion

    /// <summary>
    /// Cycles through the passed in dialog branch (TextState) and handles setting images, audio, etc., based on the TextState's instructions.
    /// </summary>
    /// <param name="textStates"></param>
    /// <returns></returns>
    public IEnumerator RunDialog(List<TextState> textStates)
    {
        runDialogInProgress = true;

        for (int i = 0; i < textStates.Count; i++)
        {
            textAnimatorPlayer.ShowText(textStates[i].GetDialogueText());

            // Set character images
            // Set character dialog audio
            // Set other important stuff

            // Pause here until all letters are shown
            while (!textAnimator.allLettersShown)
            {
                Debug.Log("waiting");
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
        runDialogInProgress = false;
    }

    public void SetTextAnimator(TextAnimator tAnim)
    {
        textAnimator = tAnim;
    }

    public void SetTextAnimatorPlayer(TextAnimatorPlayer tAnimPlayer)
    {
        textAnimatorPlayer = tAnimPlayer;
    }

    /// <summary>
    /// Returns true if dialog is running, false otherwise.
    /// </summary>
    /// <returns></returns>
    public bool GetRunDialogInProgress()
    {
        return runDialogInProgress;
    }
}
