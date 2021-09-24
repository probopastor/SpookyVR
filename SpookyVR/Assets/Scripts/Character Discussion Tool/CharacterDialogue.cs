/* 
* Glory to the High Council
* CJ Green, William Nomikos
* CharacterDialogue.cs
* ...Description of the script...
* ...
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character Dialogue", menuName = "Character Dialogue", order = 10)]
public class CharacterDialogue : ScriptableObject
{
    [SerializeField]
    private List<Interactions> introDialog = new List<Interactions>(1);

    [SerializeField]
    private List<Interactions> mainDialog = new List<Interactions>(1);
}

[System.Serializable]
public class Interactions
{
    [SerializeField] private List<TextState> introDialogue = new List<TextState>(1);
}

[System.Serializable]
public class TextState
{
    [SerializeField, TextArea(minLines: 5, maxLines: 20)] private string text;
    [SerializeField] private Image characterState;
}