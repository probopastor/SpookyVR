using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource Manager", menuName = "Otlo Resource Manager")]
public class OtloResourceManager : ScriptableObject
{
    #region Otlo Overall Resources
    [Tooltip(" ")] private int population = 0;
    [Tooltip(" ")] private int money = 0;
    [Tooltip(" ")] private int food = 0;
    [Tooltip(" ")] private int militia = 0;
    [Tooltip(" ")] private int crimeRate = 0;
    [Tooltip(" ")] private int cultPresence = 0;
    #endregion
}
