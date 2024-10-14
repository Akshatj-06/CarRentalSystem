using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class PaymentRepository : IPaymentRepository

    {
        // Default constructor
        public PaymentRepository() { }

        //Parameterized constructor
        Payment payment = new Payment();
        public PaymentRepository(int paymentID, int leaseID, DateTime paymentDate, int amount)
        {
            payment.paymentID = paymentID;
            payment.leaseID = leaseID;
            payment.paymentDate = paymentDate;
            payment.amount = amount;

        }
        public override string ToString()
        {
            return $"Payment {{ paymentID={payment.paymentID}, leaseID='{payment.leaseID}', " +
                   $" paymentDate='{payment.paymentDate}',amount='{payment.amount}";

        }
        public void DisplayPaymentInfo()
        {
            Console.WriteLine($"{payment.paymentID}, {payment.leaseID},{payment.paymentDate},{payment.amount}");
        }
    }
}
