using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Otlo Location")]
public class OtloLocation : ScriptableObject
{
    [Tooltip(" ")] public int moneyAllocated = 0;
    [Tooltip(" ")] public int prosperity = 0;
    [Tooltip(" ")] public bool militiaStationed = false;

    [Tooltip(" ")] public int moneyProduced = 0;
    [Tooltip(" ")] public int foodProcuded = 0;
    [Tooltip(" ")] public int crimeProduced = 0;
}
