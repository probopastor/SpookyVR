using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogTextSetter : MonoBehaviour
{
    [SerializeField, Tooltip("All interactions this button can have. ")] private List<Interactions> interactions = new List<Interactions>();

    [Space(20)]
    [Header("Interaction Changers - Whether the following variables should change which Interaction the interactions should use.")]
    [Space(20)]

    [Space(10)]
    [Header("Change Interaction - Money")]
    [Space(10)]
    [SerializeField, Tooltip("Whether money should be checked for when deciding which interaction to use. ")] private bool checkMoney = false;
    [SerializeField, Tooltip("The money brackets to check. ")] private ResourceBrackets[] moneyBrackets;

    [Space(10)]
    [Header("Change Interaction - Militia")]
    [Space(10)]
    [SerializeField, Tooltip("Whether militia should be checked for when deciding which interaction to use. ")] private bool checkMilitia = false;
    [SerializeField, Tooltip("The money brackets to check. ")] private ResourceBrackets[] militiaBrackets;

    [Space(10)]
    [Header("Change Interaction - Prosperity")]
    [Space(10)]
    [SerializeField, Tooltip("Whether prosperity should be checked for when deciding which interaction to use. ")] private bool checkProsperity = false;
    [SerializeField, Tooltip("The money brackets to check. ")] private ResourceBrackets[] prosperityBrackets;

    public List<Interactions> GetInteractions()
    {
        return interactions;
    }
}
