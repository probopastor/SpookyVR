using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Manager", menuName = "Otlo Resource Manager")]
public class OtloResourceManager : ScriptableObject
{
    #region Otlo Overall Resources
    [Tooltip(" ")] private int currentWeek = 0;
    [Tooltip(" ")] private int population = 0;
    [Tooltip(" ")] private int money = 0;
    [Tooltip(" ")] private int food = 0;
    [Tooltip(" ")] private int militia = 0;
    [Tooltip(" ")] private int crimeRate = 0;
    [Tooltip(" ")] private int cultPresence = 0;
    #endregion

    #region Setters
    #region Direct Setters

    /// <summary>
    /// Directly sets the current week. This is not additive.
    /// </summary>
    /// <param name="newWeek">The new week number. </param>
    public void SetCurrentWeek(int newWeek)
    {
        currentWeek = newWeek;
    }

    /// <summary>
    /// Directly sets the population. This is not additive. 
    /// </summary>
    /// <param name="newPopulationAmount">The new population amount.</param>
    public void SetPopulation(int newPopulationAmount)
    {
        population = newPopulationAmount;
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
    /// Directly sets the food. This is not additive. 
    /// </summary>
    /// <param name="newFood">The new food amount.</param>
    public void SetFood(int newFood)
    {
        food = newFood;
    }

    /// <summary>
    /// Directly sets the militia units available. This is not additive. 
    /// </summary>
    /// <param name="newMilitiaUnits">The new militia units available.</param>
    public void SetMilitiaUnits(int newMilitiaUnits)
    {
        militia = newMilitiaUnits;
    }

    /// <summary>
    /// Directly sets the crime rate. This is not additive. 
    /// </summary>
    /// <param name="newCrimeRate">The new crime rate.</param>
    public void SetCrimeRate(int newCrimeRate)
    {
        crimeRate = newCrimeRate;
    }

    /// <summary>
    /// Directly sets the cult presence. This is not additive.
    /// </summary>
    /// <param name="newCultPresence">The new cult presence.</param>
    public void SetCultPresence(int newCultPresence)
    {
        cultPresence = newCultPresence;
    }

    #endregion 

    #region Update Methods
   
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
    /// Updates the population. This is additive to current population.
    /// </summary>
    /// <param name="changeInPopulation">The amount population should change by.</param>
    public void UpdatePopulation(int changeInPopulation)
    {
        population += changeInPopulation;

        if (population < 0)
            population = 0;
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
    /// Updates the food. This is additive to current food.
    /// </summary>
    /// <param name="changeInFood">The amount food should change by.</param>
    public void UpdateFood(int changeInFood)
    {
        food += changeInFood;

        if (food < 0)
            food = 0;
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

    /// <summary>
    /// Updates the crime rate. This is additive to current crime rate.
    /// </summary>
    /// <param name="changeInCrimeRate">The amount crime rate should change by.</param>
    public void UpdateCrimeRate(int changeInCrimeRate)
    {
        crimeRate += changeInCrimeRate;

        if (crimeRate < 0)
            crimeRate = 0;
    }

    /// <summary>
    /// Updates the cult presence. This is additive to current cult presence.
    /// </summary>
    /// <param name="changeInCult">The amount cult presence should change by.</param>
    public void UpdateCultPresence(int changeInCult)
    {
        cultPresence += changeInCult;

        if (cultPresence < 0)
            cultPresence = 0;
    }

    #endregion

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
    /// Returns the population.
    /// </summary>
    /// <returns>Int of population.</returns>
    public int GetPopulation()
    {
        return population;
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
    /// Returns the food.
    /// </summary>
    /// <returns>Int of food.</returns>
    public int GetFood()
    {
        return food;
    }

    /// <summary>
    /// Returns the militia units available.
    /// </summary>
    /// <returns>Int of militia units available.</returns>
    public int GetMilitiaUnits()
    {
        return militia;
    }

    /// <summary>
    /// Returns the crime rate.
    /// </summary>
    /// <returns>Int of crime rate.</returns>
    public int GetCrimeRate()
    {
        return crimeRate;
    }

    /// <summary>
    /// Returns the cult presence.
    /// </summary>
    /// <returns>Int of cult presence.</returns>
    public int GetCultPresence()
    {
        return cultPresence;
    }

    #endregion
}
