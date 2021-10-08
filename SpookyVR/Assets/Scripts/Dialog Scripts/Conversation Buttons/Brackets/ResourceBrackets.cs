using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBrackets : MonoBehaviour
{
    [SerializeField, Tooltip("The minimum bound of this bracket. ")] private int bracketMin = 0;
    [SerializeField, Tooltip("The maximum bound of this bracket. ")] private int bracketMax = 0;

    [SerializeField, Tooltip("The index of interactions to be called when the resource falls into this bracket (between min and max bounds). ")] private int interactionIndex = 0;
}
