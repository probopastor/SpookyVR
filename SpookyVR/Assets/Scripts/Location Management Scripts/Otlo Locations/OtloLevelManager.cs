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

[DisallowMultipleComponent]
public class OtloLevelManager : LevelManager
{
    [Space(10)]
    [Header("Otlo Initial Resources")]
    [Space(40)]

    [SerializeField, Tooltip("The initial week Otlo will start at. ")] private int weekInitial = 1;
    [SerializeField, Tooltip("The initial population Otlo will start at. ")] private int populationInitial = 0;
    [SerializeField, Tooltip("The initial money Otlo will start at. ")] private int moneyInitial = 0;
    [SerializeField, Tooltip("The initial food Otlo will start at. ")] private int foodInitial = 0;
    [SerializeField, Tooltip("The initial militia Otlo will start at. ")] private int militiaInitial = 0;
    [SerializeField, Tooltip("The initial crime Otlo will start at. ")] private int crimeRateInitial = 0;
    [SerializeField, Tooltip("The initial cult presence Otlo will start at. ")] private int cultPresenceInitial = 0;

    [Space(10)]
    [Header("Otlo Character and Location Data References")]
    [Space(40)]
    [SerializeField, Tooltip("A list of all Otlo characters. ")] public List<OtloCharacterData> characterData = new List<OtloCharacterData>();
    [SerializeField, Tooltip("A list of all Otlo locations. ")] public List<OtloLocationData> locationData = new List<OtloLocationData>();

    /// <summary>
    /// OtloLocationData overrides LocationDataInitial to include Location starting information for Otlo's unique resources.
    /// </summary>
    [System.Serializable]
    public class OtloLocationData : LocationDataInitial
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
    public class OtloCharacterData: CharacterDataInitial
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
                thisCharacter.SetMetStatus(false);
                // Set other condition here: characterList[i].SetSpecialCondition(characterData[i].otherCondition);
            }
        }
    }

    /// <summary>
    /// Returns a List of Otlo Character Data - which contains information on all Otlo Characters.
    /// </summary>
    /// <returns>List of Otlo Character Data. </returns>
    public List<OtloCharacterData> GetOtloCharacterData()
    {
        return characterData;
    }

    /// <summary>
    /// Returns a List of Otlo Location Data - which contains information on all Otlo Locations.
    /// </summary>
    /// <returns>List of OtloLocationData. </returns>
    public List<OtloLocationData> GetOtloLocationData()
    {
        return locationData;
    }

}
