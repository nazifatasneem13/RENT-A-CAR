using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public interface ICar
    {
        string CarType { get; }
        string Model { get; set; }
        string LicensePlate { get; set; }
        void DisplayInfo();

    }
}
