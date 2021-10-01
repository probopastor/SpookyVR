/* 
* Glory to the High Council
* William Nomikos
* OtloDisplayResources.cs
* Handles displaying the resources in Otlo. Inherits from DisplayResources.cs.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class OtloDisplayResources : DisplayResources
{
    [SerializeField, Tooltip("The TMP the population resource will update. ")] private TextMeshProUGUI populationText;
    [SerializeField, Tooltip("The TMP the money resource will update. ")] private TextMeshProUGUI moneyText;
    [SerializeField, Tooltip("The TMP the militia units resource will update. ")] private TextMeshProUGUI militiaUnitsText;
    [SerializeField, Tooltip("The TMP the food resource will update. ")] private TextMeshProUGUI foodText;
    [SerializeField, Tooltip("The TMP the cult presence resource will update. ")] private TextMeshProUGUI cultPresenceText;

    [Tooltip("The Otlo Resource manager of this location. Handles the resources to be used and manipulated. ")] private OtloResourceManager usedResources;

    // Start is called before the first frame update
    void Start()
    {
        SetResourceManager();
    }

    #region Display Resources Interface Implementation 
    public override void SetResourceManager()
    {
        usedResources = (OtloResourceManager)FindObjectOfType<LevelManager>().GetLevelResourceManager();
    }

    public override void UpdateDisplayedResources()
    {
        if (usedResources == null)
            SetResourceManager();

        populationText.text = "Population: " + usedResources.GetPopulation();
        moneyText.text = "Money: " + usedResources.GetMoney();
        militiaUnitsText.text = "Militia Units: " + usedResources.GetMilitiaUnits();
        foodText.text = "Food: " + usedResources.GetFood();
        cultPresenceText.text = "Cult: " + usedResources.GetCultPresence();
    }

    #endregion

    #region Other Resource Update Methods
    /// <summary>
    /// Updates the population resource text. 
    /// </summary>
    public void UpdatePopulationText()
    {
        if (usedResources == null)
            SetResourceManager();

        populationText.text = "Population: " + usedResources.GetPopulation();
    }

    /// <summary>
    /// Updates the money resource text. 
    /// </summary>
    public void UpdateMoneyText()
    {
        if (usedResources == null)
            SetResourceManager();

        moneyText.text = "Money: " + usedResources.GetMoney();
    }

    /// <summary>
    /// Updates the militia resource text. 
    /// </summary>
    public void UpdateMilitiaUnitsText()
    {
        if (usedResources == null)
            SetResourceManager();

        militiaUnitsText.text = "Militia Units: " + usedResources.GetMilitiaUnits();
    }

    /// <summary>
    /// Updates the food resource text. 
    /// </summary>
    public void UpdateFoodText()
    {
        if (usedResources == null)
            SetResourceManager();

        foodText.text = "Food: " + usedResources.GetFood();
    }

    /// <summary>
    /// Updates the cult presence resource text. 
    /// </summary>
    public void UpdateCultPresenceText()
    {
        if (usedResources == null)
            SetResourceManager();

        cultPresenceText.text = "Cult: " + usedResources.GetCultPresence();
    }

    #endregion 
}
