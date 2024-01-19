using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class RentalService : IRentalService
    {
        private ICarRepository carRepository;
        private List<ICar> rentedCars = new List<ICar>();
        private Dictionary<ICar, DateTime> rentalStartTimes = new Dictionary<ICar, DateTime>();
        private Dictionary<ICar, RentalHistory> rentalHistory = new Dictionary<ICar, RentalHistory>();

        private readonly RentPaymentCalculator rentPaymentCalculator;

        public RentalService(ICarRepository carRepository, IPaymentService paymentService)
        {
            this.carRepository = carRepository;
            this.rentPaymentCalculator = new RentPaymentCalculator(paymentService);
        }

        private IPaymentService paymentService; // Dependency Injection

        private void SimulatePayment(double totalAmount)
        {
            paymentService.ProcessPayment(totalAmount);
        }

        public void RentCar(ICar car)
        {
            if (carRepository.GetAvailableCars().Any())
            {
                carRepository.RemoveCar(car);
                rentedCars.Add(car);
                rentalStartTimes.Add(car, DateTime.Now);
                Console.WriteLine("Car is rented succesfully.");
            }
            else
            {
                Console.WriteLine("No available cars to rent.");
            }
        }

        public void ReturnCar(ICar car)
        {
            if (rentalStartTimes.TryGetValue(car, out DateTime startTime))
            {
                rentalStartTimes.Remove(car);
                TimeSpan duration = DateTime.Now - startTime;
                double totalAmount = rentPaymentCalculator.CalculateRentalAmount(car, duration.TotalMinutes);

                carRepository.AddCar(car);
                rentedCars.Remove(car);

                Console.WriteLine($"Car returned successfully.\nDuration: {duration.TotalMinutes:F0} minutes {duration.Seconds} seconds.\nTotal amount: ${totalAmount:F2}");

                // Update rental history
                UpdateRentalHistory(car, startTime, DateTime.Now, duration);

                // Simulate payment
                IPaymentService paymentService = new PaymentService();
                paymentService.ProcessPayment(totalAmount);
            }
            else
            {
                Console.WriteLine("Car not found or not rented.");
            }
        }

        public List<ICar> GetRentedCars()
        {
            return rentedCars;
        }

        public Dictionary<ICar, RentalHistory> GetRentalHistory()
        {
            return rentalHistory;
        }

        private void DisplayAvailableCars()
        {
            var availableCars = carRepository.GetAvailableCars();
            if (availableCars.Any())
            {
                Console.WriteLine("\nAvailable Cars:");
                foreach (var availableCar in availableCars)
                {
                    availableCar.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("No available cars.");
            }
        }

        private void UpdateRentalHistory(ICar car, DateTime startTime, DateTime returnTime, TimeSpan duration)
        {
            if (!rentalHistory.ContainsKey(car))
            {
                rentalHistory.Add(car, new RentalHistory());
            }

            rentalHistory[car].AddRentalRecord(startTime, returnTime, duration);
        }
    }
}
