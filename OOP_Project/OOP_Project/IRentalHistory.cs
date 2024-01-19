using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public interface IRentalHistory
    {
        void AddRentalRecord(DateTime startTime, DateTime returnTime, TimeSpan duration);
        List<RentalRecord> GetRentalRecords();
    }
}
