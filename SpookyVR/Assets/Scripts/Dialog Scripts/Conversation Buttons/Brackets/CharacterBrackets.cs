using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrackets : MonoBehaviour
{
    [SerializeField, Tooltip("The Character Scriptable Object that should be looked at. ")] private Character characterToCheck;
    [SerializeField, Tooltip("Whether the character's life should be checked. ")] private bool checkIfAlive = false;

    [SerializeField, Tooltip("The money brackets to check. ")] private ResourceBrackets[] trustBrackets;
}
