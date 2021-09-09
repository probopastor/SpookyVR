using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OtloLocation : MonoBehaviour
{
    [Tooltip(" ")] protected int moneyAllocated = 0;
    [Tooltip(" ")] protected int prosperity = 0;
    [Tooltip(" ")] protected bool militiaStationed = false;

    [Tooltip(" ")] protected int moneyProduced = 0;
    [Tooltip(" ")] protected int foodProcuded = 0;
    [Tooltip(" ")] protected int crimeProduced = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Abstract Location Methods

    /// <summary>
    /// Handles the Assess action of this location. Should properly switch to the correct scene, and handle text, input, etc., associated with the given location. Needs to be overwritten by subclass locations.
    /// </summary>
    public abstract void StartAssess();

    #endregion

    #region Collection Methods

    /// <summary>
    /// Collects resources produced by this location and adds their values to the Resource Bank.
    /// </summary>
    public abstract void Collect();

    #endregion

    #region Location Setters - Key Resources

    /// <summary>
    /// Changes the amount of money given to this location.
    /// </summary>
    /// <param name="changeInLocationMoney">The amount of money to be changed.</param>
    public void ChangeMoney(int changeInLocationMoney)
    {
        moneyAllocated += changeInLocationMoney;
    }

    /// <summary>
    /// Changes the prosperity of this location.
    /// </summary>
    /// <param name="changeInProsperity">The amount prosperity should increase / decrease by.</param>
    public void ChangeProsperity(int changeInProsperity)
    {
        prosperity += changeInProsperity;
    }

    /// <summary>
    /// Sets whether militia is stationed at this location or not.
    /// </summary>
    /// <param name="militiaStationedStatus">Set to True to station militia at this location, false otherwise.</param>
    public void SetMilitiaStationedStatus(bool militiaStationedStatus)
    {
        militiaStationed = militiaStationedStatus;
    }

    #endregion

    #region Location Setters - Resources Produced

    /// <summary>
    /// Changes the money produced at this location. This will be taken into account when the player chooses to Collect.
    /// </summary>
    /// <param name="changeInMoney">The change in produced money at this location.</param>
    public void ChangeMoneyProduced(int changeInMoney)
    {
        moneyProduced += changeInMoney;
    }

    /// <summary>
    /// Changes the food produced at this location. This will be taken into account when the player chooses to Collect.
    /// </summary>
    /// <param name="changeInFood">The change in produced food at this location.</param>
    public void ChangeFoodProduced(int changeInFood)
    {
        foodProcuded += foodProcuded;
    }

    /// <summary>
    /// Changes the crime produced at this location. This will be added passively to the Crime resource at the end of the week.
    /// </summary>
    /// <param name="changeInCrime">The change in produced crime at this location.</param>
    public void ChangeCrimeProduced(int changeInCrime)
    {
        crimeProduced += changeInCrime;
    }

    #endregion

    #region Location Getters - Key Resources

    /// <summary>
    /// Returns the amount of money stored at this location currently.
    /// </summary>
    /// <returns>Returns an int of the total money allocated. </returns>
    public int GetTotalMoneyAllocated()
    {
        return moneyAllocated;
    }

    /// <summary>
    /// Returns the prosperity of this location.
    /// </summary>
    /// <returns>Returns an int of the prosperity of this location.</returns>
    public int GetProsperity()
    {
        return prosperity;
    }

    /// <summary>
    /// Returns whether militia is stationed at this location.
    /// </summary>
    /// <returns>Returns true if militia is stationed at this location, false otherwise.</returns>
    public bool GetMilitiaStationed()
    {
        return militiaStationed;
    }
    #endregion

    #region Location Getters - Resources Produced
    
    /// <summary>
    /// Returns the total amount of money produced at this location currently.
    /// </summary>
    /// <returns>Returns an int of total money produced at this location.</returns>
    public int GetMoneyProduced()
    {
        return moneyProduced;
    }

    /// <summary>
    /// Returns the total amount of food produced at this location currently.
    /// </summary>
    /// <returns>Returns an int of total food produced at this location.</returns>
    public int GetFoodProduced()
    {
        return foodProcuded;
    }

    /// <summary>
    /// Returns the total amount of crime produced at this location currently.
    /// </summary>
    /// <returns>Returns an int of total crime produced at this location.</returns>
    public int GetCrimeProduced()
    {
        return crimeProduced;
    }

    #endregion 
}
