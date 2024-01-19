using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class PaymentService : IPaymentService
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Payment processed: ${amount:F2}");
        }
    }
}
