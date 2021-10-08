using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtloDialogTextSetter : DialogTextSetter
{
    [Space(10)]
    [Header("Change Interaction - Food")]
    [Space(10)]
    [SerializeField, Tooltip("Whether food should be checked for when deciding which interaction to use. ")] private bool checkFood = false;
    [SerializeField, Tooltip("The food brackets to check. ")] private ResourceBrackets[] foodBrackets;

    [Space(10)]
    [Header("Change Interaction - Crime")]
    [Space(10)]
    [SerializeField, Tooltip("Whether crime should be checked for when deciding which interaction to use. ")] private bool checkCrime = false;
    [SerializeField, Tooltip("The crime brackets to check. ")] private ResourceBrackets[] crimeBrackets;

    [Space(10)]
    [Header("Change Interaction - Cult")]
    [Space(10)]
    [SerializeField, Tooltip("Whether cult presence should be checked for when deciding which interaction to use. ")] private bool checkCult = false;
    [SerializeField, Tooltip("The cult brackets to check. ")] private ResourceBrackets[] cultBrackets;
}
