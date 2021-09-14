using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtloLevelManager : LevelManager
{
    [SerializeField, Tooltip(" ")] private int weekInitial = 1;
    [SerializeField, Tooltip(" ")] private int populationInitial = 0;
    [SerializeField, Tooltip(" ")] private int moneyInitial = 0;
    [SerializeField, Tooltip(" ")] private int foodInitial = 0;
    [SerializeField, Tooltip(" ")] private int militiaInitial = 0;
    [SerializeField, Tooltip(" ")] private int crimeRateInitial = 0;
    [SerializeField, Tooltip(" ")] private int cultPresenceInitial = 0;

    [SerializeField, Tooltip(" ")] private List<OtloCharacterData> characterData = new List<OtloCharacterData>();
    [SerializeField, Tooltip(" ")] private List<OtloLocationData> locationData = new List<OtloLocationData>();


    [System.Serializable]
    private class OtloLocationData : LocationDataInitial
    {
        public int prosperityInitial = 0;
        public int moneyAllocatedInitial = 0;
        public bool militiaStationedInitial = false;
        public int moneyProducedInitial = 0;
        public int foodProducedInitial = 0;
        public int crimeProducedInitial = 0;
    }

    [System.Serializable]
    private class OtloCharacterData: CharacterDataInitial
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ResetLevelData(ResourceManager thisResourceManager)
    {
        OtloResourceManager otloResources = (OtloResourceManager)thisResourceManager;

        otloResources.SetCurrentWeek(weekInitial);
        otloResources.SetPopulation(populationInitial);
        otloResources.SetMoney(moneyInitial);
        otloResources.SetFood(foodInitial);
        otloResources.SetMilitiaUnits(militiaInitial);
        otloResources.SetCrimeRate(crimeRateInitial);
        otloResources.SetCultPresence(cultPresenceInitial);

        //Location[] locations = otloResources.GetLocations();
        //Character[] characters = otloResources.GetCharacters();

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
