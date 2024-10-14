using System;
using System.Collections.Generic;
using CarRentalSystem.BusinessLayer.MyExceptions;
using System.Text;
using CarRentalSystem.Entity;


namespace CarRentalSystem.BusinessLayer.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> vehicles;

        // Default constructor initializing the vehicle list
        public VehicleRepository()
        {
            vehicles = new List<Vehicle>();
        }

        // Parameterized constructor for convenience (not typically used in a repository)
        public VehicleRepository(int vehicleID, string make, string model, DateTime year, int dailyRate, string status, int passengerCapacity, int engineCapacity)
        {
            Vehicle vehicle = new Vehicle
            {
                vehicleID = vehicleID,
                make = make,
                model = model,
                year = year,
                dailyRate = dailyRate,
                status = status,
                passangerCapacity = passengerCapacity,
                engineCapacity = engineCapacity
            };
            vehicles.Add(vehicle);
        }

        // Method to add a vehicle
        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            vehicles.Add(vehicle);
        }

        // Method to remove a vehicle by ID
        public void RemoveVehicle(int vehicleID)
        {
            var vehicle = FindVehicleById(vehicleID);
            if (vehicle == null)
            {
                throw new CarNotFoundException($"Car with ID {vehicleID} was not found.");
            }
            vehicles.Remove(vehicle);
        }

        // Method to find a vehicle by ID
        public Vehicle FindVehicleById(int vehicleID)
        {
            var vehicle = vehicles.Find(v => v.vehicleID == vehicleID);
            if (vehicle == null)
            {
                throw new CarNotFoundException($"Car with ID {vehicleID} was not found.");
            }
            return vehicle;
        }

        // Method to list all vehicles
        public List<Vehicle> ListAllVehicles()
        {
            return vehicles;
        }

        // Method to display vehicle information
        public void DisplayVehicleInfo()
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.vehicleID}, {vehicle.make}, {vehicle.model}, {vehicle.year.Year}, {vehicle.dailyRate}, {vehicle.status}, {vehicle.passangerCapacity}, {vehicle.engineCapacity}");
            }
        }

        // Override ToString method to display vehicle details
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var vehicle in vehicles)
            {
                sb.AppendLine($"Vehicle {{ vehicleID={vehicle.vehicleID}, make='{vehicle.make}', model='{vehicle.model}', " +
                              $"year='{vehicle.year.Year}', dailyRate='{vehicle.dailyRate}', status='{vehicle.status}', " +
                              $"passengerCapacity='{vehicle.passangerCapacity}', engineCapacity='{vehicle.engineCapacity}' }}");
            }
            return sb.ToString();
        }
    }
}
