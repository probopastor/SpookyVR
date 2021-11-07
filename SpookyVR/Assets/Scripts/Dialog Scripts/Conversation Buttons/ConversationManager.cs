/* 
* Glory to the High Council
* William Nomikos
* ConversationManager.cs
* One ConversationManager script per location where conversations will occur. This will take in a list in editor of all the Conversation Topic Buttons possible. 
* Handles enabling, disabling, and ordering these Conversation Topic Buttons based on the game state. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private List<ConversationTopicButton> conversationOptions = new List<ConversationTopicButton>();

    // Start is called before the first frame update
    void Start()
    {
        RefreshButtons(true);
    }

    public void RefreshButtons(bool disableAll)
    {
        if(disableAll)
        {
            // Disables all Conversation Topic Buttons at game start. 
            foreach (ConversationTopicButton button in conversationOptions)
            {
                button.enabled = false;
            }
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
