using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class CarRepository : ICarRepository
    {
        private List<ICar> cars = new List<ICar>();
        private const string FilePath = "cars.txt"; // File path for storing cars
        private readonly ICarFileHandler carFileHandler;

        public CarRepository(ICarFileHandler carFileHandler)
        {
            this.carFileHandler = carFileHandler;
            LoadCarsFromFile();
        }

        public void AddCar(ICar car)
        {
            cars.Add(car);
            SaveCarsToFile();
            Console.WriteLine("Car added successfully to the repository.");
        }

        public void RemoveCar(ICar car)
        {
            cars.Remove(car);
            SaveCarsToFile();
            Console.WriteLine("Car removed temporarily from the repository.");
        }

        public IEnumerable<ICar> GetAvailableCars()
        {
            return cars;
        }

        private void LoadCarsFromFile()
        {
            cars = carFileHandler.LoadCarsFromFile(FilePath);
        }

        private void SaveCarsToFile()
        {
            carFileHandler.SaveCarsToFile(cars, FilePath);
        }
    }
}
