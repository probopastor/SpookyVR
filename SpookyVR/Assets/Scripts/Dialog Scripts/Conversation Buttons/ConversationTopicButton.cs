using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTopicButton : MonoBehaviour
{
    // Order:
    // 1. Conversation Button contains List<Interactions> to use if selected
    // 2. Conversation Button appears only during timelines the array narrativeBranchesIncludedIn match with. This is checked via a manager. 
    // 3. When selected, the correct interaction is chosen from the List<Interactions> via the TopicParser class. This parse will mainly check Trust. 
    // 4. Dialog will be ran from the TopicParser. 
    // 5. When this is started, all buttons vanish as text is in session. 


    [SerializeField, Tooltip("An array of narrative branches this conversation option should appear in. ")] private int[] narrativeBranchesIncludedIn;
    [SerializeField, Tooltip("A list of the possible interactions this conversation option will contain. ")] private List<Interactions> dialogConversations;

    [Tooltip("TopicParser reference, which is used to determine which Interaction to use when this conversation option is selected. ")] private TopicParser topicParser;

    // Start is called before the first frame update
    void Start()
    {
        topicParser = FindObjectOfType<TopicParser>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectConversation()
    {

    }
}
