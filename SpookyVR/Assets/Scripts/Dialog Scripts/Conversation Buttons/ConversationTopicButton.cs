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

    // Start is called before the first frame update
    void Start()
    {
        thisResourceManager = FindObjectOfType<LevelManager>().GetLevelResourceManager();
    }

    private void OnEnable()
    {
        DetermineAvailability();
    }

    public void DetermineAvailability()
    {
        int valueNeeded = 0;
        int selectionAmount = 0;

        if(checkPopulation)
        {
            valueNeeded++;

            if ((thisResourceManager.GetPopulation() > populationRange[0]) && (thisResourceManager.GetPopulation() < populationRange[1]))
            {
                selectionAmount++;
            }
        }

        if(checkMoney)
        {
            valueNeeded++;

            if ((thisResourceManager.GetMoney() > moneyRange[0]) && (thisResourceManager.GetMoney() < moneyRange[1]))
            {
                selectionAmount++;
            }
        }

        if(checkProsperity)
        {
            valueNeeded++;

            //if ((thisResourceManager.GetMoney() > moneyRange[0]) && (thisResourceManager.GetMoney() < moneyRange[1]))
            //{
            //    selectionAmount++;
            //}
        }

        if (checkTrust)
        {
            valueNeeded++;

            //if ((thisResourceManager.GetMoney() > moneyRange[0]) && (thisResourceManager.GetMoney() < moneyRange[1]))
            //{
            //    selectionAmount++;
            //}
        }

        if (checkMilitia)
        {
            valueNeeded++;

            if ((thisResourceManager.GetMilitiaUnits() > militiaRange[0]) && (thisResourceManager.GetMilitiaUnits() < militiaRange[1]))
            {
                selectionAmount++;
            }
        }

        if (checkCrime)
        {
            valueNeeded++;

            if ((thisResourceManager.GetCrimeRate() > crimeRange[0]) && (thisResourceManager.GetCrimeRate() < crimeRange[1]))
            {
                selectionAmount++;
            }
        }

        if (checkCult)
        {
            valueNeeded++;

            if ((thisResourceManager.GetCultPresence() > cultRange[0]) && (thisResourceManager.GetCultPresence() < cultRange[1]))
            {
                selectionAmount++;
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
