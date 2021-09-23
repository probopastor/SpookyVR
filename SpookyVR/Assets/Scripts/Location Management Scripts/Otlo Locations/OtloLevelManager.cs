/* 
* Glory to the High Council
* William Nomikos
* OtloLevelManager.cs
* Otlo's individual level manager. Maintains starting conditions of Otlo, and methods to reset Otlo (called when the level is started or restarted).
* 
* Should be inherited by individual level managers.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtloLevelManager : LevelManager
{
    [SerializeField, Tooltip("The initial week Otlo will start at. ")] private int weekInitial = 1;
    [SerializeField, Tooltip("The initial population Otlo will start at. ")] private int populationInitial = 0;
    [SerializeField, Tooltip("The initial money Otlo will start at. ")] private int moneyInitial = 0;
    [SerializeField, Tooltip("The initial food Otlo will start at. ")] private int foodInitial = 0;
    [SerializeField, Tooltip("The initial militia Otlo will start at. ")] private int militiaInitial = 0;
    [SerializeField, Tooltip("The initial crime Otlo will start at. ")] private int crimeRateInitial = 0;
    [SerializeField, Tooltip("The initial cult presence Otlo will start at. ")] private int cultPresenceInitial = 0;

    /// <summary>
    /// CJ's Addition...
    /// </summary>
    [SerializeField, Tooltip("This is a list that will be filled with the correct Characters when an action requires the player to talk to any.")]
    private List<Character> charactersToTalkTo = new List<Character>();

    [SerializeField, Tooltip("A list of all Otlo characters. ")] private List<OtloCharacterData> characterData = new List<OtloCharacterData>();
    [SerializeField, Tooltip("A list of all Otlo locations. ")] private List<OtloLocationData> locationData = new List<OtloLocationData>();

    /// <summary>
    /// OtloLocationData overrides LocationDataInitial to include Location starting information for Otlo's unique resources.
    /// </summary>
    [System.Serializable]
    private class OtloLocationData : LocationDataInitial
    {
        [Tooltip("The prosperity of this location on level start. ")] public int prosperityInitial = 0;
        [Tooltip("The money allocated to this location on level start. ")] public int moneyAllocatedInitial = 0;
        [Tooltip("Whether militia will start stationed at this location. ")] public bool militiaStationedInitial = false;
        [Tooltip("The money produced by this location on level start. ")] public int moneyProducedInitial = 0;
        [Tooltip("The food produced by this location on level start. ")] public int foodProducedInitial = 0;
        [Tooltip("The crime produced by this location on level start. ")] public int crimeProducedInitial = 0;
    }

    /// <summary>
    /// OtloCharacterData overrides CharacterDataInitial to include Character starting information for Otlo's unique characters.
    /// </summary>
    [System.Serializable]
    private class OtloCharacterData: CharacterDataInitial
    {

    }

    public override void ResetLevelData()
    {
        thisResourceManager.SetMoney(moneyInitial);
        thisResourceManager.SetMilitiaUnits(militiaInitial);

        OtloResourceManager otloResources = (OtloResourceManager)thisResourceManager;

        otloResources.SetCurrentWeek(weekInitial);
        otloResources.SetPopulation(populationInitial);
        otloResources.SetFood(foodInitial);
        otloResources.SetCrimeRate(crimeRateInitial);
        otloResources.SetCultPresence(cultPresenceInitial);

        // Cycles through the locations associated with thisResourceManager to reset their variables.
        for(int i = 0; i < locationData.Count; i++)
        {
            if(locationData[i] != null)
            {
                Location thisLocation = locationData[i].GetLocation();

                thisLocation.SetAccessibility(locationData[i].isInaccessible);
                thisLocation.SetName(locationData[i].name);
                thisLocation.SetLocationImages(locationData[i].locationImages);
                thisLocation.SetMilitiaStationed(locationData[i].militiaStationedInitial);
                thisLocation.SetMoneyAllocated(locationData[i].moneyAllocatedInitial);

                // If the location is an OtloLocation, reset its individual data
                if (thisLocation is OtloLocation)
                {
                    OtloLocation otloLocation = (OtloLocation)locationData[i].GetLocation();

                    otloLocation.SetProsperity(locationData[i].prosperityInitial);
                    otloLocation.SetMoneyProduced(locationData[i].moneyProducedInitial);
                    otloLocation.SetFoodProduced(locationData[i].foodProducedInitial);
                    otloLocation.SetCrimeProduced(locationData[i].crimeProducedInitial);
                }

                Debug.Log(thisLocation.GetName() + " Money Allocated: " + thisLocation.GetMoneyAllocated());
                Debug.Log(thisLocation.GetName() + " Militia Stationed: " + thisLocation.GetMilitiaStationed());
            }
        }

        // Cycles through the characters associated with thisResourceManager to reset their variables.
        for(int i = 0; i < characterData.Count; i++)
        {
            if(characterData[i] != null)
            {
                Character thisCharacter = characterData[i].GetCharacter();

                thisCharacter.SetName(characterData[i].name);
                thisCharacter.SetCharacterImages(characterData[i].characterImages);
                thisCharacter.SetCharacterTrust(characterData[i].trustInitial);
                thisCharacter.UpdateDeathStatus(characterData[i].isDead);
                // Set other condition here: characterList[i].SetSpecialCondition(characterData[i].otherCondition);
            }
        }
    }

}
