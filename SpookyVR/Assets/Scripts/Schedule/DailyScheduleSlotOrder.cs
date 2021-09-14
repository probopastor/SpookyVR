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
        [SerializeField, Tooltip(" ")] private List<ScheduleSlotData> dailyScheduleSlotOrder = new List<ScheduleSlotData>();

        public List<ScheduleSlotData> GetDailySlotOrder()
        {
            return dailyScheduleSlotOrder;
        }
    }
}