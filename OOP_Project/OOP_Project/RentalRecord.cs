using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class RentalRecord
    {
        public DateTime StartTime { get; }
        public DateTime ReturnTime { get; }
        public TimeSpan Duration { get; }

        public RentalRecord(DateTime startTime, DateTime returnTime, TimeSpan duration)
        {
            StartTime = startTime;
            ReturnTime = returnTime;
            Duration = duration;
        }
    }
}
