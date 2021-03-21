using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Schedule
    {
        public int DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
