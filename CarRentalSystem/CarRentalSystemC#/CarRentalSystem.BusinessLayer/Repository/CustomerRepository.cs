using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository

    {
        // Default constructor
        public CustomerRepository() { }

        //Parameterized constructor
        Customer customer = new Customer();
        public CustomerRepository(int customerID, string firstName, string lastName, string email, string phoneNumber)
        {
            customer.customerID = customerID;
            customer.firstName = firstName;
            customer.lastName = lastName;
            customer.email = email;
            customer.phoneNumber = phoneNumber;

        }
        public override string ToString()
        {
            return $"Customer {{ customerID={customer.customerID}, firstName='{customer.firstName}', lastName='{customer.lastName}', " +
                   $"email='{customer.email}', phoneNumber='{customer.phoneNumber}' }}";

        }
        public void DisplayCustomerInfo()
        {
            Console.WriteLine($"{customer.customerID}, {customer.firstName},{customer.lastName},{customer.email},{customer.phoneNumber}");
        }
    }
}
