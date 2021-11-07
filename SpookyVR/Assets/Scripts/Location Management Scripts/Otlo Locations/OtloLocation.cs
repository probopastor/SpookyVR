/* 
* Glory to the High Council
* William Nomikos
* OtloLocation.cs
* The Location scriptable object script for Otlo. This maintains the resources common
* across all Otlo Locations.
* 
* Contains Setters, Getters, and Update methods for these resources.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtloLocation : Location
{
    //[Tooltip("The prosperity of this location. ")] private int prosperity = 0;

    //[Tooltip("The money produced by this location. ")] private int moneyProduced = 0;
    //[Tooltip("The food produced by this location. ")] private int foodProcuded = 0;
    //[Tooltip("The crime produced by this location. ")] private int crimeProduced = 0;

    #region Setters

    #region Direct Setters

    /// <summary>
    /// Directly sets the prosperity of this location. This is not additive.
    /// </summary>
    /// <param name="newProsperity">The new amount of prosperity that should be allocated.</param>
    //public void SetProsperity(int newProsperity)
    //{
    //    prosperity = newProsperity;
    //}

    ///// <summary>
    ///// Directly sets the money produced by this location. This is not additive.
    ///// </summary>
    ///// <param name="newMoneyProduced">The new amount of money produced. </param>
    //public void SetMoneyProduced(int newMoneyProduced)
    //{
    //    moneyProduced = newMoneyProduced;
    //}

    ///// <summary>
    ///// Directly sets the food produced by this location. This is not additive.
    ///// </summary>
    ///// <param name="newFoodProduced">The new amount of food produced.</param>
    //public void SetFoodProduced(int newFoodProduced)
    //{
    //    foodProcuded = newFoodProduced;
    //}

    ///// <summary>
    ///// Directly sets the crime produced by this location. This is not additive.
    ///// </summary>
    ///// <param name="newCrimeProduced">The new amount of crime produced.</param>
    //public void SetCrimeProduced(int newCrimeProduced)
    //{
    //    crimeProduced = newCrimeProduced;
    //}

    #endregion 

    #region Update Methods

    ///// <summary>
    ///// Updates the prosperity of this location.
    ///// </summary>
    ///// <param name="changeInProsperity">The change in prosperity of this location.</param>
    //public void UpdateProsperity(int changeInProsperity)
    //{
    //    prosperity += changeInProsperity;
    //}

    ///// <summary>
    ///// Updates the money produced by this location.
    ///// </summary>
    ///// <param name="changeInMoneyProduced">The change in money produced by this location.</param>
    //public void UpdateMoneyProduced(int changeInMoneyProduced)
    //{
    //    moneyProduced += changeInMoneyProduced;
    //}

    ///// <summary>
    ///// Updates the food produced by this location.
    ///// </summary>
    ///// <param name="changeInFoodProduced">The change in food produced by this location.</param>
    //public void UpdateFoodProduced(int changeInFoodProduced)
    //{
    //    foodProcuded += changeInFoodProduced;
    //}

    ///// <summary>
    ///// Updates the crime produced by this location.
    ///// </summary>
    ///// <param name="changeInCrimeProduced">The change in crime produced by this location.</param>
    //public void UpdateCrimeProduced(int changeInCrimeProduced)
    //{
    //    crimeProduced += changeInCrimeProduced;
    //}

    #endregion

    #endregion

    #region Getters

    ///// <summary>
    ///// Returns the prosperity of this location.
    ///// </summary>
    ///// <returns>Int of prosperity.</returns>
    //public int GetProsperity()
    //{
    //    return prosperity;
    //}

    ///// <summary>
    ///// Returns the money produced each week at this location.
    ///// </summary>
    ///// <returns>Int of money produced.</returns>
    //public int GetMoneyProduced()
    //{
    //    return moneyProduced;
    //}

    ///// <summary>
    ///// Returns the food produced each week at this location.
    ///// </summary>
    ///// <returns>Int of food produced.</returns>
    //public int GetFoodProduced()
    //{
    //    return foodProcuded;
    //}

    ///// <summary>
    ///// Returns the crime produced each week at this location.
    ///// </summary>
    ///// <returns>Int of crime produced.</returns>
    //public int GetCrimeProduced()
    //{
    //    return crimeProduced;
    //}

    #endregion
}
