using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateScheduleLocationResources : MonoBehaviour
{
    [Tooltip("The resource manager that should be used. ")] ResourceManager usedResources;

    #region Update Visual Variables
    [SerializeField, Tooltip("The location to have checked for money allocated and militia stationed resources to update visuals to. ")] private Location location;
    [SerializeField, Tooltip("The TMPro that should be updated to display money allocated to a given location. Leave empty if non-applicable. ")] private TextMeshProUGUI moneyAllocatedText;
    [SerializeField, Tooltip("The checkbox image that should be updated to display militia stationed at a given location. Leave empty if non-applicable. ")] private Image checkboxImage;
    [Tooltip("The display resource handler for this location. ")] private OtloDisplayResources displayResources;
    #endregion

    #region Update Resource Variables

    [Tooltip("The money to be funded to this location this week. ")] private int moneyToBeFunded = 0;
    [Tooltip("The money currently funded to this location. ")] private int currentMoneyFunded = 0;

    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyAllocatedText();
        //UpdateMilitiaScheduledCheckBox();
        SetResourceManager();

        displayResources = FindObjectOfType<OtloDisplayResources>();
    }

    private void SetResourceManager()
    {
        usedResources = FindObjectOfType<LevelManager>().GetLevelResourceManager();
    }

    #region Update Visuals Methods

    /// <summary>
    /// Updates the moneyAllocated text of this location to properly reflect money allocated.
    /// </summary>
    public void UpdateMoneyAllocatedText()
    {
        currentMoneyFunded = location.GetMoneyAllocated();

        // Sets the money allocated text to equal the current money funded at this location plus the new money meant to be funded this week. 
        moneyAllocatedText.text = (moneyToBeFunded + currentMoneyFunded).ToString();
    }

    /// <summary>
    /// Updates militia stationed checkbox to properly reflect if militia is stationed at this location.
    /// </summary>
    public void UpdateMilitiaScheduledCheckBox()
    {
        if (location.GetMilitiaStationed())
        {
            checkboxImage.enabled = true;
        }
        else
        {
            checkboxImage.enabled = false;
        }
    }

    #endregion 

    /// <summary>
    /// Sets the amount to fund to a location. Access by button.
    /// </summary>
    /// <param name="amount">the amount of funding to be added. </param>
    public void AddFunding(int amount)
    {
        if (usedResources == null)
        {
            SetResourceManager();
        }

        if (location.GetMoneyAllocated() + moneyToBeFunded + amount >= 0)
        {
            if ((usedResources.GetMoney() > 0 && amount > 0) || amount < 0)
            {
                moneyToBeFunded += amount;
                usedResources.UpdateMoney(-amount);
                displayResources.UpdateMoneyText();
            }
        }

    }

    /// <summary>
    /// Updates the money allocated to this location at the start of the week.
    /// </summary>
    public void SetFunding()
    {
        location.UpdateMoneyAllocated(moneyToBeFunded);
        moneyToBeFunded = 0;
        currentMoneyFunded = 0;
    }

    /// <summary>
    /// Sets the militia stationed at a location. Access by button
    /// </summary>
    public void AddStationedMilitia()
    {
        if (usedResources == null)
        {
            SetResourceManager();
        }

        if (location.GetMilitiaStationed())
        {
            location.SetMilitiaStationed(false);
            usedResources.UpdateMilitiaUnits(1);
            displayResources.UpdateMilitiaUnitsText();
        }
        else
        {
            if (usedResources.GetMilitiaUnits() > 0)
            {
                location.SetMilitiaStationed(true);
                usedResources.UpdateMilitiaUnits(-1);
                displayResources.UpdateMilitiaUnitsText();
            }
        }
    }
}
