/* 
* Glory to the High Council
* William Nomikos
* ResourceManager.cs
* The Resouce Manager scriptable object superclass. Should be inherited by individual level Resource Managers.
* Contains variables and setter / getter methods for everything that will remain constant across all level Resource Managers.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceManager : ScriptableObject
{
    [Tooltip("The current week the level is on. ")] private int currentWeek = 0;

    #region Setters 
    /// <summary>
    /// Directly sets the current week. This is not additive.
    /// </summary>
    /// <param name="newWeek">The new week number. </param>
    public void SetCurrentWeek(int newWeek)
    {
        currentWeek = newWeek;
    }

    /// <summary>
    /// Updates the current week. This is additive to the current current week.
    /// </summary>
    /// <param name="changeInWeek">The amount the week should change by. (Will generally be 1). </param>
    public void UpdateCurrentWeek(int changeInWeek)
    {
        currentWeek += changeInWeek;

        if (currentWeek < 0)
            currentWeek = 0;
    }

    #endregion

    #region Getters

    /// <summary>
    /// Returns the current week.
    /// </summary>
    /// <returns>Int of current week. </returns>
    public int GetCurrentWeek()
    {
        return currentWeek;
    }

    #endregion 
}
