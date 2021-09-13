using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Location : ScriptableObject
{
    protected string locationName;
    protected Image[] locationImages;

    protected bool isInaccessible = false;

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
}
