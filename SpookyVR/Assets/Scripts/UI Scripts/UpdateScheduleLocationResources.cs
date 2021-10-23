/* 
* Glory to the High Council
* William Nomikos
* UpdateScheduleLocationResources.cs
* Handles setting and updating the schedule's location resources (money funded, militia stationed, etc.) when the player manages them.
* Adds / Removes from the necessary resource pools as resources are used on locations. (For example, funding a location will take from the overall money resource).
* 
*[TODO: make a superclass and make this inherit from it for Otlo. Should be set from Otlo Level Manager. ]
*/

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

    #region Display Resources variables

    [Tooltip("The display resource handler for Otlo. ")] private OtloDisplayResources displayResourcesOtlo;
    //[Tooltip("The display resource handler for Atlantis. ")] private AtlantisDisplayResources displayResourcesAtlantis;
    #endregion 

    [Tooltip("The int ID of the level being used. This variable will be used to determine which DisplayResources should be used. ")] private int levelIDUsed = -1;
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
        SetDisplayResources();
    }

    /// <summary>
    /// Obtains the resource manager used this level.
    /// </summary>
    private void SetResourceManager()
    {
        usedResources = FindObjectOfType<LevelManager>().GetLevelResourceManager();
    }

    /// <summary>
    /// Sets the correct DisplayResources to use based on this level's int ID.
    /// </summary>
    private void SetDisplayResources()
    {
        levelIDUsed = FindObjectOfType<LevelManager>().GetLevelID();

        if (levelIDUsed == 0)
        {
            displayResourcesOtlo = FindObjectOfType<OtloDisplayResources>();
        }
        else if (levelIDUsed == 1)
        {
            //displayResourcesAtlantis = FindObjectOfType<AtlantisDisplayResources>();
        }
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
                displayResourcesOtlo.UpdateMoneyText();
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
            displayResourcesOtlo.UpdateMilitiaUnitsText();
        }
        else
        {
            if (usedResources.GetMilitiaUnits() > 0)
            {
                location.SetMilitiaStationed(true);
                usedResources.UpdateMilitiaUnits(-1);
                displayResourcesOtlo.UpdateMilitiaUnitsText();
            }
        }
    }
}
