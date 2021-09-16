/* 
* Glory to the High Council
* William Nomikos
* OtloResourceManager.cs
* The Resouce Manager scriptable object for Otlo. Maintains data for all resources / variables
* Otlo will use. Contains Setters, Getters, and Update methods for these resources.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Manager", menuName = "Otlo Resource Manager")]
public class OtloResourceManager : ResourceManager
{
    #region Otlo Overall Resources
    [Tooltip("Otlo's population. ")] private int population = 0;
    [Tooltip("Otlo's total food. ")] private int food = 0;
    [Tooltip("Otlo's total crime rate. ")] private int crimeRate = 0;
    [Tooltip("Otlo's cult presence. ")] private int cultPresence = 0;
    #endregion

    #region Direct Setters

    /// <summary>
    /// Directly sets the population. This is not additive. 
    /// </summary>
    /// <param name="newPopulationAmount">The new population amount.</param>
    public void SetPopulation(int newPopulationAmount)
    {
        population = newPopulationAmount;
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

    #region Getters

    /// <summary>
    /// Returns the population.
    /// </summary>
    /// <returns>Int of population.</returns>
    public int GetPopulation()
    {
        return population;
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
