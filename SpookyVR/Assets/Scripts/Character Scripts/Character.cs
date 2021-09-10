using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Otlo Character")]
public class Character : ScriptableObject
{
    public string characterName;

    public Image[] characterImages; 

    private int trust = 0;
    private bool isDead = false;

    #region Setters

    /// <summary>
    /// Sets this character's name to a new name.
    /// </summary>
    /// <param name="newName">A string of the new character name. </param>
    public void SetName(string newName)
    {
        characterName = newName;
    }

    /// <summary>
    /// Updates a character's trust.
    /// </summary>
    /// <param name="changeInTrust">The amount this character's trust should be changed by.</param>
    public void UpdateCharacterTrust(int changeInTrust)
    {
        trust += changeInTrust;
    }

    /// <summary>
    /// Sets this character's trust. (This is not additive. To update trust, call UpdateCharacterTrust()).
    /// </summary>
    /// <param name="trustAmount">The trust amount this character should have. </param>
    public void SetCharacterTrust(int trustAmount)
    {
        trust = trustAmount;
    }

    /// <summary>
    /// Updates this character's living status. 
    /// </summary>
    /// <param name="dead">False if dead, true if alive.</param>
    public void UpdateLivingStatus(bool dead)
    {
        isDead = dead;
    }

    #endregion 

    #region Getters

    /// <summary>
    /// Returns this character's name.
    /// </summary>
    /// <returns>String of character's name.</returns>
    public string GetName()
    {
        return characterName;
    }

    /// <summary>
    /// Returns this character's trust.
    /// </summary>
    /// <returns>Int of trust amount.</returns>
    public int GetTrust()
    {
        return trust;
    }

    /// <summary>
    /// Returns whether this character is dead.
    /// </summary>
    /// <returns>True if dead, false if alive.</returns>
    public bool GetDeathStatus()
    {
        return isDead;
    }

    #endregion 
}
