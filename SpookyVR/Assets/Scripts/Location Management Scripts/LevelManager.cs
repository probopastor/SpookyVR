/* 
* Glory to the High Council
* William Nomikos
* LevelManager.cs
* Superclass that handles each level's initial resources. Variables and methods that will remain the same across all level
* managers are on this superclass. 
* 
* Should be inherited by individual level managers.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class LevelManager : MonoBehaviour
{
    [SerializeField, Tooltip("This level's levelID. Will be used to choose the proper ResourceManager by the GameManager. ")] private int levelID = -1;
    [Tooltip("The resource manager used this level. ")] protected ResourceManager thisResourceManager;

    /// <summary>
    /// Maintains individual character information for a character associated with this level. This information will be used to update the Character scriptable object on level start.
    /// </summary>
    public abstract class CharacterDataInitial
    {
        [SerializeField, Tooltip("This character's Character scriptable object. It will be updated with the appropriate parameters. ")] private Character thisCharacter;

        [Tooltip("This character's name. ")] public string name;
        [Tooltip("An array of all character state images this character will use. ")] public Image[] characterImages;
        [Tooltip("Whether this character starts off dead. Set to true if they do. ")] public bool isDead = false;
        [Tooltip("This character's starting trust with the player. ")] public int trustInitial = 0;
        [Tooltip("If this character has special conditions that require unique checks, mark this as true. ")] public bool otherCondition = false;

        /// <summary>
        /// Returns this character.
        /// </summary>
        /// <returns>Returns Character. </returns>
        public Character GetCharacter()
        {
            return thisCharacter;
        }
    }

    /// <summary>
    /// Maintains individual location information for a location associated with this level. This information will be used to update the Location scriptable object on level start.
    /// </summary>
    public abstract class LocationDataInitial
    {
        [SerializeField, Tooltip("This location's Location scriptable object. It will be updated with the appropriate parameters. ")] private Location thisLocation;

        [Tooltip("This location's name. ")] public string name;
        [Tooltip("An array of all location state images this location will use. ")] public Image[] locationImages;
        [Tooltip("Whether this location starts off as inaccessible to the player. Set to true if it is inaccessible. ")] public bool isInaccessible = false;

        /// <summary>
        /// Returns this location.
        /// </summary>
        /// <returns>Returns Location. </returns>
        public Location GetLocation()
        {
            return thisLocation;
        }
    }

    /// <summary>
    /// Resets the level data in the given level's resource manager.
    /// </summary>
    /// <param name="thisResourceManager">The ResourceManager to have its data reset.</param>
    public abstract void ResetLevelData();

    /// <summary>
    /// Returns this level's LevelID. This will be used to determine which level resource manager should be used.
    /// </summary>
    /// <returns>An Int of this level's ID.</returns>
    public int GetLevelID()
    {
        return levelID;
    }

    /// <summary>
    /// Sets this level's resource manager.
    /// </summary>
    /// <param name="resourceManagerToUse">The ResourceManager this level should use. </param>
    public void SetResourceManager(ResourceManager resourceManagerToUse)
    {
        thisResourceManager = resourceManagerToUse;
    }

    /// <summary>
    /// Returns this level's resource manager.
    /// </summary>
    /// <returns>The ResourceManager of this level. </returns>
    public ResourceManager GetLevelResourceManager()
    {
        return thisResourceManager;
    }
}
