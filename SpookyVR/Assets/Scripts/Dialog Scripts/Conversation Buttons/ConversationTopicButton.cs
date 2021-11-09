/* 
* Glory to the High Council
* William Nomikos
* ConversationManager.cs
* Handles behavior for Conversation Topic Buttons. 
* Includes method to parse topics from a given button when selected to begin playing the correct topic.
* Handles determining when Conversation Topics should / shouldn't appear. 
*/

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


    #region Include Topic Variables

    [Space(10)]
    [Header("Show Option Settings (Determines when this conversation option is available) ")]
    [Space(40)]

    [SerializeField, Tooltip("An array of narrative branches this conversation option should appear in. ")] private int[] narrativeBranchesIncludedIn;

    [SerializeField, Tooltip(" ")] private bool checkWeek;
    [SerializeField, Tooltip("If checkWeek is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] weekRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkPopulation;
    [SerializeField, Tooltip("If checkPopulation is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] populationRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkMoney;
    [SerializeField, Tooltip("If checkMoney is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] moneyRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkProsperity;
    [SerializeField, Tooltip("If checkProsperity is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] prosperityRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkTrust;
    [SerializeField, Tooltip("If checkTrust is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] trustRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkMilitia;
    [SerializeField, Tooltip("If checkMilitia is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] militiaRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkCrime;
    [SerializeField, Tooltip("If checkCrime is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] crimeRange = new int[2];

    [SerializeField, Tooltip(" ")] private bool checkCult;
    [SerializeField, Tooltip("If checkCult is true - Enables this conversation option if amount is between value 0 and value 1 of array. ")] private int[] cultRange = new int[2];

    #endregion

    #region Character & Location Variables 

    [SerializeField, Tooltip(" ")] private Character character;
    [SerializeField, Tooltip(" ")] private Location location;

    #endregion 

    [SerializeField, Tooltip("A list of the possible interactions this conversation option will contain. ")] private List<Interactions> dialogConversations;

    [Tooltip("Determines whether this topic is selectable or not. ")] private bool isSelectable = false;
    
    private ResourceManager thisResourceManager;
    private DialogHandler dialogHandler;
    private TopicParser topicParser;

    // Start is called before the first frame update
    void Start()
    {
        thisResourceManager = FindObjectOfType<LevelManager>().GetLevelResourceManager();
        dialogHandler = FindObjectOfType<DialogHandler>();
        topicParser = FindObjectOfType<TopicParser>();

        DetermineAvailability();
    }

    private void OnEnable()
    {
        DetermineAvailability();
    }

    public void DetermineAvailability()
    {
        if (thisResourceManager == null)
        {
            thisResourceManager = FindObjectOfType<LevelManager>().GetLevelResourceManager();
        }

        // The value selectionAmount will need to be in order to ensure that all checks have passed. Is incremented for each check required.
        int valueNeeded = 0;

        // The amount of checks passed. In order for this conversation option to appear, needs to equal the valueNeeded int.
        int selectionAmount = 0;

        // Will be set to true if the current narrative branch matches any of the branches this ConversationTopicButton can appear in. 
        bool correctNarrativeBranch = false;

        // TODO: GET THIS VALUE FROM THE RESOURCEMANAGER
        int tempTimeline = 1;

        // Cycle through all branchNumbers this Conversation Topic can appear in
        foreach (int branchNumber in narrativeBranchesIncludedIn)
        {
            // If the current narrative branch is equal to a branch number of the Conversation Topic
            if (tempTimeline == branchNumber)
            {
                // Set the Correct Narrative Branch to true
                if (!correctNarrativeBranch)
                {
                    correctNarrativeBranch = true;
                }
            }
        }

        // If this conversation can appear in this narrative branch, then check more specific requirements for this conversation
        if (correctNarrativeBranch)
        {
            #region Resource Specific Checks
            // Checks the week
            if (checkWeek)
            {
                valueNeeded++;

                if ((thisResourceManager.GetCurrentWeek() > weekRange[0]) && (thisResourceManager.GetCurrentWeek() <= weekRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks the population
            if (checkPopulation)
            {
                valueNeeded++;

                if ((thisResourceManager.GetPopulation() > populationRange[0]) && (thisResourceManager.GetPopulation() <= populationRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks money
            if (checkMoney)
            {
                valueNeeded++;

                if ((thisResourceManager.GetMoney() > moneyRange[0]) && (thisResourceManager.GetMoney() <= moneyRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks prosperity in the given location
            if (checkProsperity)
            {
                valueNeeded++;

                if ((location.GetProsperity() > prosperityRange[0]) && (location.GetProsperity() <= prosperityRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks character trust with the given character
            if (checkTrust)
            {
                valueNeeded++;

                if ((character.GetTrust() > trustRange[0]) && (character.GetTrust() <= trustRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks militia
            if (checkMilitia)
            {
                valueNeeded++;

                if ((thisResourceManager.GetMilitiaUnits() > militiaRange[0]) && (thisResourceManager.GetMilitiaUnits() <= militiaRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks crime
            if (checkCrime)
            {
                valueNeeded++;

                if ((thisResourceManager.GetCrimeRate() > crimeRange[0]) && (thisResourceManager.GetCrimeRate() <= crimeRange[1]))
                {
                    selectionAmount++;
                }
            }

            // Checks the cult presence
            if (checkCult)
            {
                valueNeeded++;

                if ((thisResourceManager.GetCultPresence() > cultRange[0]) && (thisResourceManager.GetCultPresence() <= cultRange[1]))
                {
                    selectionAmount++;
                }
            }

            #endregion 

            // If the selectionAmount equals the value needed, then requirements have been met for this conversation topic to be possible.
            if (selectionAmount == valueNeeded)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectConversation()
    {
        List<TextState> parsedTopic = topicParser.ParseInteractions(dialogConversations, character);
        topicParser.SubmitDialog(parsedTopic, dialogHandler);

        //StartCoroutine(dialogHandler.RunDialog(parsedTopic));
    }
}
