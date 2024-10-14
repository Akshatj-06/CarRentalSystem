using System;
using System.Collections.Generic;
using CarRentalSystem.BusinessLayer.MyExceptions.CarRentalSystem.MyExceptions;
using System.Text;
using CarRentalSystem.Entity;
using CarRentalSystem.BusinessLayer.MyExceptions;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public class LeaseRepository : ILeaseRepository
    {
        // List to store leases
        private List<Lease> leases;

        // Default constructor
        public LeaseRepository()
        {
            leases = new List<Lease>();
        }

        // Parameterized constructor (not commonly needed for repositories)
        public LeaseRepository(int leaseID, int customerID, int vehicleID, DateTime startDate, DateTime endDate, string type)
        {
            Lease lease = new Lease
            {
                leaseID = leaseID,
                customerID = customerID,
                vehicleID = vehicleID,
                startDate = startDate,
                endDate = endDate,
                type = type
            };
            leases = new List<Lease> { lease }; // Initialize with a single lease
        }

        public void AddLease(Lease lease)
        {
            if (lease == null)
                throw new ArgumentNullException(nameof(lease));

            leases.Add(lease);
        }

        public void RemoveLease(int leaseID)
        {
            var lease = FindLeaseById(leaseID);
            if (lease == null)
            {
                throw new LeaseNotFoundException($"Lease with ID {leaseID} was not found.");
            }
            leases.Remove(lease);
        }

        public Lease FindLeaseById(int leaseID)
        {
            var lease = leases.Find(l => l.leaseID == leaseID);
            if (lease == null)
            {
                throw new LeaseNotFoundException($"Lease with ID {leaseID} was not found.");
            }
            return lease;
        }

        public List<Lease> ListAllLeases()
        {
            return leases;
        }

        public override string ToString()
        {
            var leaseDetails = new StringBuilder();
            leaseDetails.AppendLine("Leases:");
            foreach (var lease in leases)
            {
                leaseDetails.AppendLine($"Lease {{ leaseID={lease.leaseID}, customerID='{lease.customerID}', vehicleID='{lease.vehicleID}', " +
                    $"startDate='{lease.startDate}', endDate='{lease.endDate}', type='{lease.type}' }}");
            }
            return leaseDetails.ToString();
        }

        public void DisplayLeaseInfo()
        {
            foreach (var lease in leases)
            {
                Console.WriteLine($"{lease.leaseID}, {lease.customerID}, {lease.vehicleID}, {lease.startDate}, {lease.endDate}, {lease.type}");
            }
        }
    }
}
