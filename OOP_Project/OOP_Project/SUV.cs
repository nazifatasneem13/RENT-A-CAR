using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class SUV : ICar
    {
        public string CarType => "SUV";
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"SUV - Model: {Model}, License Plate: {LicensePlate}");
        }
    }
}
