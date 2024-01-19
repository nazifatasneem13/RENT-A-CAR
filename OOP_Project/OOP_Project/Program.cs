using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OOP_Project
{
    class Program
    {
        static void Main()
        {
            // Initialize repository, rental service, and payment service
            ICarFileHandler carFileHandler = new CarFileHandler();
            ICarRepository carRepository = new CarRepository(carFileHandler);
            IPaymentService paymentService = new PaymentService();
            IRentalService rentalService = new RentalService(carRepository, paymentService);
            

            while (true)
            {
                Console.WriteLine("RENT-A-CAR DHAKA");
                Console.WriteLine("----------------");
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a new car");
                Console.WriteLine("2. Rent a car");
                Console.WriteLine("3. Return a car");
                Console.WriteLine("4. Display available cars");
                Console.WriteLine("5. Display rented cars");
                Console.WriteLine("6. Rental History");
                Console.WriteLine("7. Exit\n");
                Console.WriteLine("----------------\n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter car type (Private/Microbus/SUV):");
                        string carType = Console.ReadLine();

                        ICar newCar;
                        switch (carType.ToLower())
                        {
                            case "private":
                                newCar = new PrivateCar();
                                break;
                            case "microbus":
                                newCar = new Microbus();
                                break;
                            case "suv":
                                newCar = new SUV();
                                break;
                            default:
                                Console.WriteLine("Invalid car type.");
                                continue;
                        }

                        Console.WriteLine("Enter car model:");
                        newCar.Model = Console.ReadLine();

                        // Validating the car model
                        if (string.IsNullOrWhiteSpace(newCar.Model))
                        {
                            Console.WriteLine("Invalid car model. Please enter a valid model.");
                            continue;
                        }

                        Console.WriteLine("Enter license plate (e.g., ABC123):");
                        newCar.LicensePlate = Console.ReadLine();

                        // Validating the license plate format
                        if (!ValidateLicensePlateFormat(newCar.LicensePlate))
                        {
                            Console.WriteLine("Invalid license plate format. Please enter a valid format (e.g., ABC123).");
                            continue;
                        }

                        carRepository.AddCar(newCar);
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case "2":
                        Console.WriteLine("Available Cars:");
                        foreach (var Car in carRepository.GetAvailableCars())
                        {
                            Car.DisplayInfo();
                        }

                        Console.WriteLine("\nEnter the license plate of the car to rent:");
                        string rentLicensePlate = Console.ReadLine();
                        var carToRent = carRepository.GetAvailableCars().FirstOrDefault(c => c.LicensePlate == rentLicensePlate);

                        if (carToRent != null)
                        {
                            rentalService.RentCar(carToRent);
                        }
                        else
                        {
                            Console.WriteLine("Car not found or not available for rent.");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("\nRented Cars:");
                        foreach (var rentedCar in rentalService.GetRentedCars())
                        {
                            rentedCar.DisplayInfo();
                        }

                        Console.WriteLine("Enter the license plate of the car to return:");
                        string returnLicensePlate = Console.ReadLine();
                        var carToReturn = rentalService.GetRentedCars().FirstOrDefault(c => c.LicensePlate == returnLicensePlate);

                        if (carToReturn != null)
                        {
                            rentalService.ReturnCar(carToReturn);
                        }
                        else
                        {
                            Console.WriteLine("Car not found or not rented.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("Available Cars:");
                        foreach (var car in carRepository.GetAvailableCars())
                        {
                            car.DisplayInfo();
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        if (rentalService.GetRentedCars().Any())
                        {
                            Console.WriteLine("\nRented Cars:");
                            foreach (var rentedCar in rentalService.GetRentedCars())
                            {
                                rentedCar.DisplayInfo();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rented cars available.");
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "6":
                        DisplayRentalHistory(rentalService);
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");

                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        // Function to validate the license plate format
        private static bool ValidateLicensePlateFormat(string licensePlate)
        {
            // Customize the validation logic based on your requirements
            // For simplicity, here we check if the license plate has at least three characters
            return !string.IsNullOrWhiteSpace(licensePlate) && licensePlate.Length >= 3;
        }

        // Function to display rental history
        private static void DisplayRentalHistory(IRentalService rentalService)
        {
            Console.WriteLine("\nRental History:");

            foreach (var entry in rentalService.GetRentalHistory())
            {
                Console.WriteLine($"Car: {entry.Key.Model}, License Plate: {entry.Key.LicensePlate}");
                Console.WriteLine("Rental Records:");

                foreach (var record in entry.Value.GetRentalRecords())
                {
                    Console.WriteLine($"  Start Time: {record.StartTime}, Return Time: {record.ReturnTime}, Duration: {record.Duration.TotalMinutes:F0} minutes {record.Duration.Seconds} seconds");
                }

                Console.WriteLine();
            }
        }
    }
}
