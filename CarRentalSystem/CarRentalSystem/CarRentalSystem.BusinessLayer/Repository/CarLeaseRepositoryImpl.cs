using System;
using System.Collections.Generic;
using CarRentalSystem.Entity;
using CarRentalSystem.DatabaseConnection;
using System.Data.SqlClient;
using CarRentalSystem.Util;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class CarLeaseRepositoryImpl : ICarLeaseRepository
    {
        private string connectionString = "Server=DEUSEXMACHINA;Database=CarRentalSystem;Integrated Security=True;";
        // Update with your connection string

        // Car Management
        public void AddCar(Vehicle car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Vehicles (vehicleID, make, model, year, dailyRate, status, passangerCapacity, engineCapacity) VALUES (@vehicleID, @make, @model, @year, @dailyRate, @status, @passangerCapacity, @engineCapacity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicleID", car.vehicleID);
                command.Parameters.AddWithValue("@make", car.make);
                command.Parameters.AddWithValue("@model", car.model);
                command.Parameters.AddWithValue("@year", car.year);
                command.Parameters.AddWithValue("@dailyRate", car.dailyRate);
                command.Parameters.AddWithValue("@status", car.status);
                command.Parameters.AddWithValue("@passangerCapacity", car.passangerCapacity);
                command.Parameters.AddWithValue("@engineCapacity", car.engineCapacity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveCar(int carID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Vehicles WHERE vehicleID = @vehicleID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicleID", carID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Vehicle> ListAvailableCars()
        {
            List<Vehicle> availableCars = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicles WHERE status = 'Available'";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle car = new Vehicle
                    {
                        vehicleID = (int)reader["vehicleID"],
                        make = (string)reader["make"],
                        model = (string)reader["model"],
                        year = (DateTime)reader["year"],
                        dailyRate = (int)reader["dailyRate"],
                        status = (string)reader["status"],
                        passangerCapacity = (int)reader["passangerCapacity"],
                        engineCapacity = (int)reader["engineCapacity"]
                    };
                    availableCars.Add(car);
                }
            }

            return availableCars;
        }

        public List<Vehicle> ListRentedCars()
        {
            List<Vehicle> rentedCars = new List<Vehicle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicles WHERE status = 'Rented'";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle car = new Vehicle
                    {
                        vehicleID = (int)reader["vehicleID"],
                        make = (string)reader["make"],
                        model = (string)reader["model"],
                        year = (DateTime)reader["year"],
                        dailyRate = (int)reader["dailyRate"],
                        status = (string)reader["status"],
                        passangerCapacity = (int)reader["passangerCapacity"],
                        engineCapacity = (int)reader["engineCapacity"]
                    };
                    rentedCars.Add(car);
                }
            }

            return rentedCars;
        }

        public Vehicle FindCarById(int carID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Vehicles WHERE vehicleID = @vehicleID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@vehicleID", carID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Vehicle
                    {
                        vehicleID = (int)reader["vehicleID"],
                        make = (string)reader["make"],
                        model = (string)reader["model"],
                        year = (DateTime)reader["year"],
                        dailyRate = (int)reader["dailyRate"],
                        status = (string)reader["status"],
                        passangerCapacity = (int)reader["passangerCapacity"],
                        engineCapacity = (int)reader["engineCapacity"]
                    };
                }
            }
            throw new Exception("Car not found."); // Or create a custom exception
        }

        // Customer Management
        public void AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (customerID, firstName, lastName, email, phoneNumber) VALUES (@customerID, @firstName, @lastName, @email, @phoneNumber)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerID", customer.customerID);
                command.Parameters.AddWithValue("@firstName", customer.firstName);
                command.Parameters.AddWithValue("@lastName", customer.lastName);
                command.Parameters.AddWithValue("@email", customer.email);
                command.Parameters.AddWithValue("@phoneNumber", customer.phoneNumber);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveCustomer(int customerID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customers WHERE customerID = @customerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerID", customerID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        customerID = (int)reader["customerID"],
                        firstName = (string)reader["firstName"],
                        lastName = (string)reader["lastName"],
                        email = (string)reader["email"],
                        phoneNumber = (string)reader["phoneNumber"]
                    };
                    customers.Add(customer);
                }
            }

            return customers;
        }

        public Customer FindCustomerById(int customerID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE customerID = @customerID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@customerID", customerID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        customerID = (int)reader["customerID"],
                        firstName = (string)reader["firstName"],
                        lastName = (string)reader["lastName"],
                        email = (string)reader["email"],
                        phoneNumber = (string)reader["phoneNumber"]
                    };
                }
            }
            throw new Exception("Customer not found."); // Or create a custom exception
        }

        // Lease Management
        public Lease CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate)
        {
            Lease newLease = new Lease
            {
                customerID = customerID,
                vehicleID = carID,
                startDate = startDate,
                endDate = endDate,
                leaseID = GetNewLeaseId(), // Assume this method generates a new Lease ID
                //status = "Active"
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Leases (leaseID, customerID, carID, startDate, endDate, status) VALUES (@leaseID, @customerID, @carID, @startDate, @endDate, @status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@leaseID", newLease.leaseID);
                command.Parameters.AddWithValue("@customerID", newLease.customerID);
                command.Parameters.AddWithValue("@carID", newLease.vehicleID);
                command.Parameters.AddWithValue("@startDate", newLease.startDate);
                command.Parameters.AddWithValue("@endDate", newLease.endDate);
                //command.Parameters.AddWithValue("@status", newLease.status);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return newLease;
        }

        public Lease ReturnCar(int leaseID)
        {
            Lease leaseToReturn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Leases WHERE leaseID = @leaseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@leaseID", leaseID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    leaseToReturn = new Lease
                    {
                        leaseID = (int)reader["leaseID"],
                        customerID = (int)reader["customerID"],
                        vehicleID = (int)reader["carID"],
                        startDate = (DateTime)reader["startDate"],
                        endDate = (DateTime)reader["endDate"],
                        //status = (string)reader["status"]
                    };

                    // Update car status to available
                    UpdateCarStatus(leaseToReturn.vehicleID, "Available");

                    // Remove the lease from the database
                    string deleteQuery = "DELETE FROM Leases WHERE leaseID = @leaseID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@leaseID", leaseID);
                    deleteCommand.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Lease not found."); // Or create a custom exception
                }
            }

            return leaseToReturn;
        }

        public List<Lease> ListActiveLeases()
        {
            List<Lease> activeLeases = new List<Lease>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Leases WHERE status = 'Active'";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Lease lease = new Lease
                    {
                        leaseID = (int)reader["leaseID"],
                        customerID = (int)reader["customerID"],
                        vehicleID = (int)reader["carID"],
                        startDate = (DateTime)reader["startDate"],
                        endDate = (DateTime)reader["endDate"],
                        //status = (string)reader["status"]
                    };
                    activeLeases.Add(lease);
                }
            }

            return activeLeases;
        }

        private void UpdateCarStatus(int carID, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Vehicles SET status = @status WHERE vehicleID = @vehicleID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@vehicleID", carID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private int GetNewLeaseId()
        {
            // Implement logic to generate a new Lease ID, possibly using a sequence or a simple increment from the last ID.
            return 1; // Placeholder; implement your logic here
        }

        public List<Lease> ListLeaseHistory()
        {
            throw new NotImplementedException();
        }

        public void RecordPayment(Lease lease, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
