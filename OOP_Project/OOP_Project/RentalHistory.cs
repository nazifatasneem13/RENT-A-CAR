using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class RentalHistory : IRentalHistory
    {
        private List<RentalRecord> rentalRecords = new List<RentalRecord>();

        public void AddRentalRecord(DateTime startTime, DateTime returnTime, TimeSpan duration)
        {
            rentalRecords.Add(new RentalRecord(startTime, returnTime, duration));
        }

        public List<RentalRecord> GetRentalRecords()
        {
            return rentalRecords;
        }
    }
}
