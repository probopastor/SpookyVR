using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateScheduleLocationResources : MonoBehaviour
{
    #region Update Visual Variables
    [SerializeField, Tooltip("The location to have checked for money allocated and militia stationed resources to update visuals to. ")] private Location location;
    [SerializeField, Tooltip("The TMPro that should be updated to display money allocated to a given location. Leave empty if non-applicable. ")] private TextMeshProUGUI moneyAllocatedText;
    [SerializeField, Tooltip("The checkbox image that should be updated to display militia stationed at a given location. Leave empty if non-applicable. ")] private Image checkboxImage;
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
        if(location.GetMilitiaStationed())
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
        // TODO: Amount funded cannot be lower than current money.
        // TODO: Make funding location specific... may need a seperate script or reference to hold individual location funding.
        // TODO: Set a cap on how much can be funded.
        // TODO: Link this to buttons that increase / decrease this value by an amount (probably 100).
        // TODO: Make sure this amount stays in funding even after scene change for the following week. (Probably a TextMeshProGUI that always just reads the current amount funded value)

        if(location.GetMoneyAllocated() + moneyToBeFunded + amount >= 0)
        {
            moneyToBeFunded += amount;
        }
    }

    /// <summary>
    /// Updates the money allocated to this location at the start of the week.
    /// </summary>
    public void SetFunding()
    {
        location.UpdateMoneyAllocated(moneyToBeFunded);
        moneyToBeFunded = 0;
    }

    /// <summary>
    /// Sets the militia stationed at a location. Access by button
    /// </summary>
    public void AddStationedMilitia()
    {
        // TODO: Only an amount of militia can be stationed. Need to decrement some value to preserve this. 
        // TODO: Link this to a button thats a checkmark. 
        // TODO: Make sure this stays even after scene change for the following week. (Probably a UI visual that is enabled or disabled by reading the current amount funded value)
        if (location.GetMilitiaStationed())
        {
            location.SetMilitiaStationed(false);
        }
        else
        {
            location.SetMilitiaStationed(true);
        }
    }
}
