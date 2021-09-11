using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyScheduleSlotOrder : MonoBehaviour
{
    [SerializeField, Tooltip(" ")] private List<ScheduleSlotData> dailyScheduleSlotOrder = new List<ScheduleSlotData>();

    public List<ScheduleSlotData> GetDailySlotOrder()
    {
        return dailyScheduleSlotOrder;
    }
}
