using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class CarFileHandler : ICarFileHandler
    {
        public List<ICar> LoadCarsFromFile(string filePath)
        {
            List<ICar> cars = new List<ICar>();

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(',');

                            if (parts.Length == 3)
                            {
                                string carType = parts[0];
                                string model = parts[1];
                                string licensePlate = parts[2];

                                // Create the appropriate car type based on the loaded data
                                ICar car;
                                switch (carType.ToLower())
                                {
                                    case "private":
                                        car = new PrivateCar { Model = model, LicensePlate = licensePlate };
                                        break;
                                    case "microbus":
                                        car = new Microbus { Model = model, LicensePlate = licensePlate };
                                        break;
                                    case "suv":
                                        car = new SUV { Model = model, LicensePlate = licensePlate };
                                        break;
                                    default:
                                        Console.WriteLine($"Unknown car type: {carType}. Skipping.");
                                        continue;
                                }

                                cars.Add(car);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid line in the file: {line}. Skipping.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading cars from file: {ex.Message}");
                }
            }

            return cars;
        }

        public void SaveCarsToFile(IEnumerable<ICar> cars, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var car in cars)
                    {
                        writer.WriteLine($"{car.CarType},{car.Model},{car.LicensePlate}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cars to file: {ex.Message}");
            }
        }
    }
}
