using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OtloDisplayResources : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private TextMeshProUGUI populationText;
    [SerializeField, Tooltip(" ")] private TextMeshProUGUI moneyText;
    [SerializeField, Tooltip(" ")] private TextMeshProUGUI militiaUnitsText;
    [SerializeField, Tooltip(" ")] private TextMeshProUGUI foodText;
    [SerializeField, Tooltip(" ")] private TextMeshProUGUI cultPresenceText;

    [Tooltip(" ")] private OtloResourceManager usedResources;

    // Start is called before the first frame update
    void Start()
    {
        SetResourceManager();
    }

    private void SetResourceManager()
    {
        usedResources = (OtloResourceManager)FindObjectOfType<LevelManager>().GetLevelResourceManager();
    }

    /// <summary>
    /// Updates every Otlo display resource.
    /// </summary>
    public void UpdateDisplayedResources()
    {
        if (usedResources == null)
            SetResourceManager();

        populationText.text = "Population: " + usedResources.GetPopulation();
        moneyText.text = "Money: " + usedResources.GetMoney();
        militiaUnitsText.text = "Militia Units: " + usedResources.GetMilitiaUnits();
        foodText.text = "Food: " + usedResources.GetFood();
        cultPresenceText.text = "Cult: " + usedResources.GetCultPresence();
    }

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
}
