using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Microbus : ICar
    {
        public string CarType => "Microbus";
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Microbus - Model: {Model}, License Plate: {LicensePlate}");
        }
    }
}
