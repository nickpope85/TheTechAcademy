
using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleUsers.Models
{
    /// <summary>
    /// Model for storing requests for time off. All events are stored in the Events Table
    /// </summary>
    public class TimeOffEvent:Event
    {
    }
}