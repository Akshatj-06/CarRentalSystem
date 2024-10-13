using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class VehicleRepository : IVehicleRepository

    {
        // Default constructor
        public VehicleRepository() { }

        //Parameterized constructor
        Vehicle vehicle = new Vehicle();
        public VehicleRepository(int vehicleID, string make, string model, DateTime year, int dailyRate, string status, int passangerCapacity, int engineCapacity)
        {
            vehicle.vehicleID = vehicleID;
            vehicle.make = make;
            vehicle.model = model;
            vehicle.year = year;
            vehicle.dailyRate = dailyRate;
            vehicle.status = status;
            vehicle.passangerCapacity = passangerCapacity;
            vehicle.engineCapacity = engineCapacity;

        }
        public override string ToString()
        {
            return $"Vehicle {{ vehicleID={vehicle.vehicleID}, make='{vehicle.make}', model='{vehicle.model}', " +
                   $"year='{vehicle.year}', dailyRate='{vehicle.dailyRate}',status='{vehicle.status}',passangerCapacity{vehicle.passangerCapacity}',engineCapacity{vehicle.engineCapacity}";

        }
        public void DisplayVehicleInfo()
        {
            Console.WriteLine($"{vehicle.vehicleID}, {vehicle.make},{vehicle.model},{vehicle.year},{vehicle.dailyRate},{vehicle.status},{vehicle.passangerCapacity},{vehicle.engineCapacity}");
        }
    }
}
