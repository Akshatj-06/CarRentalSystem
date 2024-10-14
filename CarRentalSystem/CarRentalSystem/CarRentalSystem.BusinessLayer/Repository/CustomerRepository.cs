
using System;
using System.Collections.Generic;
using CarRentalSystem.BusinessLayer.MyExceptions;
using System.Text;
using CarRentalSystem.Entity;


namespace CarRentalSystem.BusinessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        // List to store customers
        private List<Customer> customers;

        // Default constructor
        public CustomerRepository()
        {
            customers = new List<Customer>();
        }

        // Parameterized constructor (not commonly needed for repositories)
        public CustomerRepository(int customerID, string firstName, string lastName, string email, string phoneNumber)
        {
            Customer customer = new Customer
            {
                customerID = customerID,
                firstName = firstName,
                lastName = lastName,
                email = email,
                phoneNumber = phoneNumber
            };
            customers = new List<Customer> { customer }; // Initialize with a single customer
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            customers.Add(customer);
        }

        public void RemoveCustomer(int customerID)
        {
            var customer = FindCustomerById(customerID);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerID} was not found.");
            }
            customers.Remove(customer);
        }

        public Customer FindCustomerById(int customerID)
        {
            var customer = customers.Find(c => c.customerID == customerID);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerID} was not found.");
            }
            return customer;
        }

        public List<Customer> ListAllCustomers()
        {
            return customers;
        }

        public override string ToString()
        {
            var customerDetails = new StringBuilder();
            customerDetails.AppendLine("Customers:");
            foreach (var customer in customers)
            {
                customerDetails.AppendLine($"Customer {{ customerID={customer.customerID}, firstName='{customer.firstName}', lastName='{customer.lastName}', " +
                    $"email='{customer.email}', phoneNumber='{customer.phoneNumber}' }}");
            }
            return customerDetails.ToString();
        }

        public void DisplayCustomerInfo()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.customerID}, {customer.firstName}, {customer.lastName}, {customer.email}, {customer.phoneNumber}");
            }
        }
    }
}
