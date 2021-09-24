/* 
* Glory to the High Council
* CJ Green
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
    public List<Image> characterDialogueImages = new List<Image>();
    public List<Interactions> characterDialogueInteractions = new List<Interactions>(1);
}

[System.Serializable]
public class TextState
{
    public string text;

    public Image characterState;


}

[System.Serializable]
public class Interactions
{

    #region Character Interaction Dialogue Containers
    [System.Serializable]
    private class IntroInteractions
    {
        [SerializeField]
        private int index = 0;

        [SerializeField,TextArea(minLines: 5, maxLines: 20)]
        public List<TextState> introDialogue = new List<TextState>(1);



        public int GetCurrentListIndex()
        {
            return index;
        }

        //public void SetIndex()
        //{

        //}

    }

    [System.Serializable]
    private class MainDialogue
    {
        [SerializeField]
        private int index = 0;

        [SerializeField, TextArea(minLines: 5, maxLines: 20)]
        public List<string> mainDialogue = new List<string>(1);

        public int GetCurrentListIndex()
        {
            return index;
        }

    }

    [System.Serializable]
    private class Responses
    {
        [SerializeField]
        private int index = 0;

        [TextArea(minLines: 1, maxLines: 5)]
        public List<string> responses = new List<string>(1);

        public int GetCurrentListIndex()
        {
            return index;
        }

    }
    #endregion

    [SerializeField]
    private List<IntroInteractions> intro_Interactions = new List<IntroInteractions>(1);
    
    [SerializeField]
    private List<MainDialogue> mainDialogue_Interactions = new List<MainDialogue>(1);
    
    [SerializeField]
    private List<Responses> responses_interactions = new List<Responses>(1);
}