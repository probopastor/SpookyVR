/* 
* Glory to the High Council
* CJ Green, William Nomikos
* LocationDialogue.cs
* ...Description of the script...
* ...
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Location Dialogue", menuName = "Location Dialogue", order = 10)]
public class LocationDialogue : ScriptableObject
{
    [SerializeField, Tooltip("A list containing all of a locations spoken Intro Dialogue")]
    private List<Interactions> introDialog = new List<Interactions>(1);

    [SerializeField, Tooltip("A list containing all of a locations spoken Main Dialogue")]
    private List<Interactions> mainDialog = new List<Interactions>(1);


    public List<Interactions> GetIntroDialogueList()
    {

        return introDialog;

    }

    public List<Interactions> GetMainDialogueList()
    {
        return mainDialog;
    }

}

[System.Serializable]
public class Interactions
{
    [SerializeField, Tooltip("Container that hold what will be said and the character Image for each piece of dialoge.")] private List<TextState> dialogue = new List<TextState>(1);

    public string GetTextAtIndex(int index)
    {
        return dialogue[index].GetDialogueText();
    }

    public Image GetImageAtIndex(int index)
    {
        return dialogue[index].GetCharacterImage();
    }

}

[System.Serializable]
public class TextState
{
    [SerializeField, Tooltip("What the character will say.") ,TextArea(minLines: 5, maxLines: 20)] private string text;
    
    
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

}