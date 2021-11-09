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
    [SerializeField, Tooltip(" ")] private ConversationTopicButton[] conversationOptions;
    [SerializeField, Tooltip(" ")] private int conversationTopicsPerMeeting = 1;
    [Tooltip(" ")] private int conversationTopicsRemaining = 1;

    [Tooltip(" ")] private DialogHandler dialogHandler;

    [Tooltip(" ")] private bool conversationTopicsDisplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogHandler = FindObjectOfType<DialogHandler>();
        conversationTopicsRemaining = conversationTopicsPerMeeting;
    }

    private void OnEnable()
    {
        NewMeetingSetup();
    }

    // Update is called once per frame
    void Update()
    {
        // Display conversation topics if dialog is not in progress and if there are conversation topics left in this meeting.
        if (!conversationTopicsDisplaying && !dialogHandler.GetRunDialogInProgress() && conversationTopicsRemaining > 0)
        {
            DisplayTopics(true);
        }
        // End current action if topics remaining is 0
        else if(!dialogHandler.GetRunDialogInProgress() && conversationTopicsRemaining <= 0)
        {
            // Play end dialog here

            GameManager._gameManager.SetCurrentActionComplete(true);
            NewMeetingSetup();
        }
    }

    private void NewMeetingSetup()
    {
        if (dialogHandler == null)
        {
            dialogHandler = FindObjectOfType<DialogHandler>();
        }

        conversationTopicsRemaining = conversationTopicsPerMeeting;
        DisplayTopics(false);
    }

    /// <summary>
    /// Enables or Disables conversation topic buttons
    /// </summary>
    /// <param name="displayStatus">Pass in True to enable conversation topics, false otherwise. </param>
    public void DisplayTopics(bool displayStatus)
    {
        // If conversation topic buttons should not be displayed, disable them
        if (!displayStatus)
        {
            foreach (ConversationTopicButton conversationTopics in conversationOptions)
            {
                conversationTopics.gameObject.SetActive(false);
            }

            conversationTopicsDisplaying = false;
        }
        else
        {
            conversationTopicsDisplaying = true;

            // Cycle through conversation topics and enable them.
            foreach (ConversationTopicButton conversationTopics in conversationOptions)
            {
                conversationTopics.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Sets the conversation topics remaining to the passed in amount.
    /// </summary>
    /// <param name="topicAmount">The new amount of topics this meeting.</param>
    public void SetTopicsPerMeeting(int topicAmount)
    {
        conversationTopicsRemaining = topicAmount;
    }

    /// <summary>
    /// Decrements the conversation topics remaining this meeting by the amount passed in. 
    /// </summary>
    /// <param name="changeAmount">The amount the conversation topics remaining should be decremented by. </param>
    public void ChangeTopicsPerMeeting(int changeAmount)
    {
        conversationTopicsRemaining -= changeAmount;
    }
}
