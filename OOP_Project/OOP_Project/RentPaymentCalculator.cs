using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class RentPaymentCalculator
    {
        private const double PrivateCarRatePerMinute = 50;
        private const double MicrobusRatePerMinute = 60;
        private const double SUVRatePerMinute = 55;

        private readonly IPaymentService paymentService;

        public RentPaymentCalculator(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public double CalculateRentalAmount(ICar car, double minutes)
        {
            if (car is PrivateCar)
            {
                return PrivateCarRatePerMinute * minutes;
            }
            else if (car is Microbus)
            {
                return MicrobusRatePerMinute * minutes;
            }
            else if (car is SUV)
            {
                return SUVRatePerMinute * minutes;
            }

            return 0.0; // Unknown car type
        }

        public void ProcessPayment(double totalAmount)
        {
            paymentService.ProcessPayment(totalAmount);
        }
    }
}
