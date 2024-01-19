using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class PrivateCar : ICar
    {
        public string CarType => "Private";
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Private Car - Model: {Model}, License Plate: {LicensePlate}");
        }
    }
}
