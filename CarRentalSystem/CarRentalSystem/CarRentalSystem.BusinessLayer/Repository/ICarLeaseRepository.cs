﻿using CarRentalSystem.Entity;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.BusinessLayer.Repository
{
    public interface ICarLeaseRepository
    {
        // Car Management
        void AddCar(Vehicle car);
        void RemoveCar(int carID);
        List<Vehicle> ListAvailableCars();
        List<Vehicle> ListRentedCars();
        Vehicle FindCarById(int carID);

        // Customer Management
        void AddCustomer(Customer customer);
        void RemoveCustomer(int customerID);
        List<Customer> ListCustomers();
        Customer FindCustomerById(int customerID);

        // Lease Management
        Lease CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate);
        Lease ReturnCar(int leaseID);
        List<Lease> ListActiveLeases();
        List<Lease> ListLeaseHistory();

        // Payment Handling
        void RecordPayment(Lease lease, double amount);
    }
}
