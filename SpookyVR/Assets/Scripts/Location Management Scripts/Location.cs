/* 
* Glory to the High Council
* William Nomikos
* Location.cs
* The Location scriptable object superclass. Maintains data for all Location resources / variables
* that will be shared across all levels. Contains Setters, Getters, and Update methods for these resources.
* 
* Should be inherited by each individual level's Location script (and scriptable objects should then be made in the editor
* based on these children).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Location", menuName = "Location")]
public class Location : ScriptableObject
{
    #region Variables
    [Tooltip("This location's name. ")] protected string locationName;
    [Tooltip("An array of all location state images this location will use. ")] protected Image[] locationImages;

    [Tooltip("Maintains whether this location is accessible by the player. ")] protected bool isInaccessible = false;

    [Tooltip("Maintains whether militia is stationed at this location. ")] private bool militiaStationed = false;
    [Tooltip("Maintains the money allocated to this location. ")] private int moneyAllocated = 0;

    [Tooltip("The prosperity of this location. ")] private int prosperity = 0;

    [Tooltip("The money produced by this location. ")] private int moneyProduced = 0;
    [Tooltip("The food produced by this location. ")] private int foodProcuded = 0;
    [Tooltip("The crime produced by this location. ")] private int crimeProduced = 0;
    #endregion

    #region Setters
    /// <summary>
    /// Sets this location's name to a new name.
    /// </summary>
    /// <param name="newName">A string of the new location name. </param>
    public void SetName(string newName)
    {
        locationName = newName;
    }

    /// <summary>
    /// Sets this location's image states to the passed in Image array.
    /// </summary>
    /// <param name="images">An array of Images. </param>
    public void SetLocationImages(Image[] images)
    {
        locationImages = images;
    }


    /// <summary>
    /// Sets whether this location is inaccessible.
    /// </summary>
    /// <param name="inaccessible">True if inaccessible, false if accessible. </param>
    public void SetAccessibility(bool inaccessible)
    {
        isInaccessible = inaccessible;
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
    /// Directly sets the money allocated to this location. This is not additive.
    /// </summary>
    /// <param name="newMoneyAllocated">The new amount of money that should be allocated.</param>
    public void SetMoneyAllocated(int newMoneyAllocated)
    {
        moneyAllocated = newMoneyAllocated;
    }

    /// <summary>
    /// Updates the money allocated to this location. 
    /// </summary>
    /// <param name="moneyToBeAllocated">The change in money allocated. </param>
    public void UpdateMoneyAllocated(int moneyToBeAllocated)
    {
        moneyAllocated += moneyToBeAllocated;
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

    #region Getters

    /// <summary>
    /// Returns this location's name.
    /// </summary>
    /// <returns>String of location's name.</returns>
    public string GetName()
    {
        return locationName;
    }

    /// <summary>
    /// Returns this location's image states. 
    /// </summary>
    /// <returns>An array of Images. </returns>
    public Image[] GetLocationImages()
    {
        return locationImages;
    }

    /// <summary>
    /// Returns whether this location is inaccessible or accessible.
    /// </summary>
    /// <returns>True if this location is inaccessible, false if it is accessible. </returns>
    public bool GetAccessibility()
    {
        return isInaccessible;
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
