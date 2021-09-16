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
    [Tooltip("This location's total money. ")] private int money = 0;
    [Tooltip("This location's total militia. ")] private int militia = 0;

    #region Setters - Direct
    /// <summary>
    /// Directly sets the current week. This is not additive.
    /// </summary>
    /// <param name="newWeek">The new week number. </param>
    public void SetCurrentWeek(int newWeek)
    {
        currentWeek = newWeek;
    }

    /// <summary>
    /// Directly sets the money. This is not additive. 
    /// </summary>
    /// <param name="newMoney">The new money amount.</param>
    public void SetMoney(int newMoney)
    {
        money = newMoney;
    }

    /// <summary>
    /// Directly sets the militia units available. This is not additive. 
    /// </summary>
    /// <param name="newMilitiaUnits">The new militia units available.</param>
    public void SetMilitiaUnits(int newMilitiaUnits)
    {
        militia = newMilitiaUnits;
    }

    #endregion

    #region Setters - Updates

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

    /// <summary>
    /// Updates the money. This is additive to current money.
    /// </summary>
    /// <param name="changeInMoney">The amount money should change by.</param>
    public void UpdateMoney(int changeInMoney)
    {
        money += changeInMoney;

        if (money < 0)
            money = 0;
    }

    /// <summary>
    /// Updates the militia units available. This is additive to current amount of available militia units.
    /// </summary>
    /// <param name="changeInMilitiaUnits">The amount militia units should change by.</param>
    public void UpdateMilitiaUnits(int changeInMilitiaUnits)
    {
        militia += changeInMilitiaUnits;

        if (militia < 0)
            militia = 0;
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

    /// <summary>
    /// Returns the money.
    /// </summary>
    /// <returns>Int of money.</returns>
    public int GetMoney()
    {
        return money;
    }

    /// <summary>
    /// Returns the militia units available.
    /// </summary>
    /// <returns>Int of militia units available.</returns>
    public int GetMilitiaUnits()
    {
        return militia;
    }

    #endregion 
}
