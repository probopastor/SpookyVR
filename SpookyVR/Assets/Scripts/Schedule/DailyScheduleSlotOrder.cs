/* 
* Glory to the High Council
* William Nomikos
* DailyScheduleSlotOrder.cs
* Maintains the order of the schedule slots on a given day. 
* Should be placed in the Scene to be given a schedule slot order.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Schedule
{
    public class DailyScheduleSlotOrder : MonoBehaviour
    {
        [SerializeField, Tooltip("The Schedule Slot order for this day. Order runs top down, top most slot should be before the bottom most slot. ")] private List<ScheduleSlotData> dailyScheduleSlotOrder = new List<ScheduleSlotData>();

        /// <summary>
        /// Returns the order of schedule slots on a given day.
        /// </summary>
        /// <returns>A List of ScheduleSlotData for a given day. </returns>
        public List<ScheduleSlotData> GetDailySlotOrder()
        {
            return dailyScheduleSlotOrder;
        }
    }
}