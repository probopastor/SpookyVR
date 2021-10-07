using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTextSetter : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private List<Interactions> interactionsToQueue = new List<Interactions>();

    [SerializeField, Tooltip(" ")] private bool checkTrust = false;
    [SerializeField, Tooltip(" ")] private bool checkProsperity = false;
    [SerializeField, Tooltip(" ")] private bool checkIfAlive = false;

    [SerializeField, Tooltip(" ")] private bool checkMoney = false;
    [SerializeField, Tooltip(" ")] private bool checkFood = false;
    [SerializeField, Tooltip(" ")] private bool checkMilitia = false;
    [SerializeField, Tooltip(" ")] private bool checkCrime = false;

    public List<Interactions> GetInteractions()
    {
        return interactionsToQueue;
    }

    public bool CheckTrust()
    {
        return checkTrust;
    }
}
