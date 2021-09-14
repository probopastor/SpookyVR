using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Location : ScriptableObject
{
    #region Variables
    protected string locationName;
    protected Image[] locationImages;

    protected bool isInaccessible = false;

    [Tooltip(" ")] private bool militiaStationed = false;
    [Tooltip(" ")] private int moneyAllocated = 0;

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

    #endregion 
}
