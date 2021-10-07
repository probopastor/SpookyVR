using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Interactions
{
    [SerializeField, Tooltip("Container that hold what will be said and the character Image for each piece of dialoge.")] private List<TextState> dialogue = new List<TextState>(1);

    /// <summary>
    /// Returns a List of TextState for this interaction.
    /// </summary>
    /// <returns>A List of TextState. </returns>
    public List<TextState> GetTextStates()
    {
        return dialogue;
    }

    public string GetTextAtIndex(int index)
    {
        return dialogue[index].GetDialogueText();
    }

    public Image GetImageAtIndex(int index)
    {
        return dialogue[index].GetCharacterImage();
    }
}
