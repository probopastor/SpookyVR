using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class LevelManager : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private int levelID = -1;

    public abstract class CharacterDataInitial
    {
        [SerializeField, Tooltip(" ")] private Character thisCharacter;

        public string name;
        public Image[] characterImages;
        public bool isDead = false;
        public int trustInitial = 0;
        public bool otherCondition = false;

        /// <summary>
        /// Returns this character.
        /// </summary>
        /// <returns>Returns Character. </returns>
        public Character GetCharacter()
        {
            return thisCharacter;
        }
    }

    public abstract class LocationDataInitial
    {
        [SerializeField, Tooltip(" ")] private Location thisLocation;

        public string name;
        public Image[] locationImages;
        public bool isInaccessible = false;

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
    public abstract void ResetLevelData(ResourceManager thisResourceManager);

    /// <summary>
    /// Returns this level's LevelID. This will be used to determine which level resource manager should be used.
    /// </summary>
    /// <returns>An Int of this level's ID.</returns>
    public int GetLevelID()
    {
        return levelID;
    }
}
