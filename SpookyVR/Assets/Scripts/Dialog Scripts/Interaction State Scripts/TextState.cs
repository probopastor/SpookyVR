using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextState
{
    [SerializeField, Tooltip("What the character will say."), TextArea(minLines: 5, maxLines: 20)] private string text;


    [SerializeField, Tooltip("What sprite will be displayed based on what is being said.")] private Image characterState;


    [SerializeField, Tooltip("")] private bool continueAutomatically = false;


    public string GetDialogueText()
    {
        return text;
    }

    public Image GetCharacterImage()
    {
        return characterState;
    }

    public bool GetContinueAutomaticallyStatus()
    {
        return continueAutomatically;
    }

}
