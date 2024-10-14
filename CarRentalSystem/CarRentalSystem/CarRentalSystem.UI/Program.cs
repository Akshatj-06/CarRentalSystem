using System;
using CarRentalSystem.BusinessLayer.MyExceptions;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;
using CarRentalSystem.BusinessLayer.MyExceptions;

namespace CarRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the CustomerRepository
            CustomerRepository customerRepo = new CustomerRepository();

            while (true)
            {
                Console.WriteLine("Car Rental System Menu:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Remove Customer");
                Console.WriteLine("3. Find Customer");
                Console.WriteLine("4. List All Customers");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            // Add Customer
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());

                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter Email: ");
                            string email = Console.ReadLine();

                            Console.Write("Enter Phone Number: ");
                            string phoneNumber = Console.ReadLine();

                            Customer newCustomer = new Customer
                            {
                                customerID = customerId,
                                firstName = firstName,
                                lastName = lastName,
                                email = email,
                                phoneNumber = phoneNumber
                            };

                            customerRepo.AddCustomer(newCustomer);
                            Console.WriteLine("Customer added successfully.");
                            break;

                        case "2":
                            // Remove Customer
                            Console.Write("Enter Customer ID to remove: ");
                            int removeId = int.Parse(Console.ReadLine());

                            customerRepo.RemoveCustomer(removeId);
                            Console.WriteLine("Customer removed successfully.");
                            break;

                        case "3":
                            // Find Customer
                            Console.Write("Enter Customer ID to find: ");
                            int findId = int.Parse(Console.ReadLine());

                            Customer foundCustomer = customerRepo.FindCustomerById(findId);
                            Console.WriteLine($"Found Customer: {foundCustomer}");
                            break;

                        case "4":
                            // List All Customers
                            customerRepo.DisplayCustomerInfo();
                            break;

                        case "5":
                            // Exit
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (CustomerNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter the correct values.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
                Console.WriteLine(); // New line for better readability
            }
        }
    }
}
