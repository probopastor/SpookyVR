using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Schedule;

public class InturruptionEventManager : MonoBehaviour
{
    private List<Days> eventOccurences = new List<Days>(0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEvent(int dayNumber, int actionNumber, int actionLength, bool isOptional, bool isScheduleable)
    {
        if(actionNumber == 3)
        {
            actionLength = 0;
        }

        // If isOptional is false, this action has to be scheduled. 
        // If isScheduleable, then player will be brought to the schedule to add the event at a given time.
        // If not isScheduleable, then a "this is occuring, attend? " message will occur the day of.
    }
}
