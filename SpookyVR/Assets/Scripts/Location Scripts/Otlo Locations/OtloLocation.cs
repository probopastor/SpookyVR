using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Otlo Location")]
public class OtloLocation : ScriptableObject
{
    [Tooltip(" ")] public int moneyAllocated = 0;
    [Tooltip(" ")] public int prosperity = 0;
    [Tooltip(" ")] public bool militiaStationed = false;

    [Tooltip(" ")] public int moneyProduced = 0;
    [Tooltip(" ")] public int foodProcuded = 0;
    [Tooltip(" ")] public int crimeProduced = 0;

    #region Setters

    #region Direct Setters

    /// <summary>
    /// Directly sets the money allocated to this location. This is not additive.
    /// </summary>
    /// <param name="newMoneyAllocated">The new amount of money that should be allocated.</param>
    public void SetMoneyAllocated(int newMoneyAllocated)
    {
        moneyAllocated = newMoneyAllocated;
    }

    /// <summary>
    /// Directly sets the prosperity of this location. This is not additive.
    /// </summary>
    /// <param name="newProsperity">The new amount of prosperity that should be allocated.</param>
    public void SetProsperity(int newProsperity)
    {
        prosperity = newProsperity;
    }

    /// <summary>
    /// Sets whether militia are stationed at this location or not.
    /// </summary>
    /// <param name="stationMilitia">Pass in true if militia should be stationed at this location, false otherwise. </param>
    public void SetMilitiaStationed(bool stationMilitia)
    {
        militiaStationed = stationMilitia;
    }

    /// <summary>
    /// Directly sets the money produced by this location. This is not additive.
    /// </summary>
    /// <param name="newMoneyProduced">The new amount of money produced. </param>
    public void SetMoneyProduced(int newMoneyProduced)
    {
        moneyProduced = newMoneyProduced;
    }

    /// <summary>
    /// Directly sets the food produced by this location. This is not additive.
    /// </summary>
    /// <param name="newFoodProduced">The new amount of food produced.</param>
    public void SetFoodProduced(int newFoodProduced)
    {
        foodProcuded = newFoodProduced;
    }

    /// <summary>
    /// Directly sets the crime produced by this location. This is not additive.
    /// </summary>
    /// <param name="newCrimeProduced">The new amount of crime produced.</param>
    public void SetCrimeProduced(int newCrimeProduced)
    {
        crimeProduced = newCrimeProduced;
    }

    #endregion 

    #region Update Methods

    /// <summary>
    /// Updates the money allocated to this location. 
    /// </summary>
    /// <param name="moneyToBeAllocated">The change in money allocated. </param>
    public void UpdateMoneyAllocated(int moneyToBeAllocated)
    {
        moneyAllocated += moneyToBeAllocated;
    }

    /// <summary>
    /// Updates the prosperity of this location.
    /// </summary>
    /// <param name="changeInProsperity">The change in prosperity of this location.</param>
    public void UpdateProsperity(int changeInProsperity)
    {
        prosperity += changeInProsperity;
    }

    /// <summary>
    /// Updates the money produced by this location.
    /// </summary>
    /// <param name="changeInMoneyProduced">The change in money produced by this location.</param>
    public void UpdateMoneyProduced(int changeInMoneyProduced)
    {
        moneyProduced += changeInMoneyProduced;
    }

    /// <summary>
    /// Updates the food produced by this location.
    /// </summary>
    /// <param name="changeInFoodProduced">The change in food produced by this location.</param>
    public void UpdateFoodProduced(int changeInFoodProduced)
    {
        foodProcuded += changeInFoodProduced;
    }

    /// <summary>
    /// Updates the crime produced by this location.
    /// </summary>
    /// <param name="changeInCrimeProduced">The change in crime produced by this location.</param>
    public void UpdateCrimeProduced(int changeInCrimeProduced)
    {
        crimeProduced += changeInCrimeProduced;
    }

    #endregion

    #endregion

    #region Getters

    /// <summary>
    /// Returns the amount of money allocated at this location.
    /// </summary>
    /// <returns>Int of money allocated.</returns>
    public int GetMoneyAllocated()
    {
        return moneyAllocated;
    }

    /// <summary>
    /// Returns the prosperity of this location.
    /// </summary>
    /// <returns>Int of prosperity.</returns>
    public int GetProsperity()
    {
        return prosperity;
    }

    /// <summary>
    /// Returns whether militia are stationed at this location.
    /// </summary>
    /// <returns>True if militia are stationed, false otherwise. </returns>
    public bool GetMilitiaStationed()
    {
        return militiaStationed;
    }

    /// <summary>
    /// Returns the money produced each week at this location.
    /// </summary>
    /// <returns>Int of money produced.</returns>
    public int GetMoneyProduced()
    {
        return moneyProduced;
    }

    /// <summary>
    /// Returns the food produced each week at this location.
    /// </summary>
    /// <returns>Int of food produced.</returns>
    public int GetFoodProduced()
    {
        return foodProcuded;
    }

    /// <summary>
    /// Returns the crime produced each week at this location.
    /// </summary>
    /// <returns>Int of crime produced.</returns>
    public int GetCrimeProduced()
    {
        return crimeProduced;
    }

    #endregion
}
