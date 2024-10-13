using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.Entity;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class LeaseRepository : ILeaseRepository

    {
        // Default constructor
        public LeaseRepository() { }

        //Parameterized constructor
        Lease lease= new Lease();
        public LeaseRepository(int leaseID, int customerID, int vehicleID, DateTime startDate, DateTime endDate, string type)
        {
            lease.leaseID = leaseID;
            lease.customerID = customerID;
            lease.vehicleID = vehicleID;
            lease.startDate = startDate;
            lease.endDate = endDate;
            lease.type = type;

        }
        public override string ToString()
        {
            return $"Lease {{ leaseID={lease.leaseID}, customerID='{lease.customerID}', vehicleID='{lease.vehicleID}', " +
                   $"startDate='{lease.startDate}', endDate='{lease.endDate}',type='{lease.type }";

        }
        public void DisplayLeaseInfo()
        {
            Console.WriteLine($"{lease.leaseID}, {lease.customerID},{lease.vehicleID},{lease.startDate},{lease.endDate},{lease.type}");
        }
    }
}
