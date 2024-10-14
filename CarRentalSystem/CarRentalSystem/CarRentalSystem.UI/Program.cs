using System;
using CarRentalSystem.BusinessLayer.MyExceptions;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;

namespace CarRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the repositories
            CustomerRepository customerRepo = new CustomerRepository();
            ICarLeaseRepository carLeaseRepo = new CarLeaseRepositoryImpl();

            while (true)
            {
                Console.WriteLine("Car Rental System Menu:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Remove Customer");
                Console.WriteLine("3. Find Customer");
                Console.WriteLine("4. List All Customers");
                Console.WriteLine("5. Add Car");
                Console.WriteLine("6. Remove Car");
                Console.WriteLine("7. List Available Cars");
                Console.WriteLine("8. Create Lease");
                Console.WriteLine("9. Return Car");
                Console.WriteLine("10. List Active Leases");
                Console.WriteLine("11. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        // Customer Management
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

                        // Car Management
                        case "5":
                            // Add Car
                            Console.Write("Enter Car ID: ");
                            int carID = int.Parse(Console.ReadLine());

                            Console.Write("Enter Make: ");
                            string make = Console.ReadLine();

                            Console.Write("Enter Model: ");
                            string model = Console.ReadLine();

                            Console.Write("Enter Year: ");
                            DateTime year = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter Daily Rate: ");
                            int dailyRate = int.Parse(Console.ReadLine());

                            Console.Write("Enter Passenger Capacity: ");
                            int passengerCapacity = int.Parse(Console.ReadLine());

                            Console.Write("Enter Engine Capacity: ");
                            int engineCapacity = int.Parse(Console.ReadLine());

                            Vehicle newCar = new Vehicle
                            {
                                vehicleID = carID,
                                make = make,
                                model = model,
                                year = year,
                                dailyRate = dailyRate,
                                status = "Available",
                                passangerCapacity = passengerCapacity,
                                engineCapacity = engineCapacity
                            };

                            carLeaseRepo.AddCar(newCar);
                            Console.WriteLine("Car added successfully.");
                            break;

                        case "6":
                            // Remove Car
                            Console.Write("Enter Car ID to remove: ");
                            int removeCarId = int.Parse(Console.ReadLine());

                            carLeaseRepo.RemoveCar(removeCarId);
                            Console.WriteLine("Car removed successfully.");
                            break;

                        case "7":
                            // List Available Cars
                            var availableCars = carLeaseRepo.ListAvailableCars();
                            Console.WriteLine("Available Cars:");
                            foreach (var car in availableCars)
                            {
                                Console.WriteLine($"{car.vehicleID}: {car.make} {car.model}");
                            }
                            break;

                        case "8":
                            // Create Lease
                            Console.Write("Enter Customer ID: ");
                            int leaseCustomerId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Car ID: ");
                            int leaseCarId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Start Date (YYYY-MM-DD): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter End Date (YYYY-MM-DD): ");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());

                            Lease newLease = carLeaseRepo.CreateLease(leaseCustomerId, leaseCarId, startDate, endDate);
                            Console.WriteLine($"Lease created successfully with ID: {newLease.leaseID}");
                            break;

                        case "9":
                            // Return Car
                            Console.Write("Enter Lease ID to return: ");
                            int leaseId = int.Parse(Console.ReadLine());

                            Lease returnedLease = carLeaseRepo.ReturnCar(leaseId);
                            Console.WriteLine($"Car returned successfully. Lease ID: {returnedLease.leaseID}");
                            break;

                        case "10":
                            // List Active Leases
                            var activeLeases = carLeaseRepo.ListActiveLeases();
                            Console.WriteLine("Active Leases:");
                            foreach (var lease in activeLeases)
                            {
                                Console.WriteLine($"Lease ID: {lease.leaseID}, Customer ID: {lease.customerID}");
                            }
                            break;

                        case "11":
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
