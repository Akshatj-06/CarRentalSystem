using System;
using System.Linq;
using NUnit.Framework;
using CarRentalSystem.Entity;
using CarRentalSystem.BusinessLayer.Repository;
using CarRentalSystem.BusinessLayer.MyExceptions;

namespace CarRentalSystemTests
{
    [TestFixture]  // Indicates that this class contains tests
    public class CarTests
    {
        private CarLeaseRepositoryImpl _carLeaseRepo;
        private CustomerRepository _customerRepo;  // Assuming you have a CustomerRepository for customer tests

        [SetUp]  // This method runs before each test
        public void Setup()
        {
            _carLeaseRepo = new CarLeaseRepositoryImpl();  // Initialize the repository
            _customerRepo = new CustomerRepository();  // Initialize customer repository
        }

        [Test]  // Test case for adding a car
        public void AddCar_Should_Create_Car_Successfully()
        {
            // Arrange: Prepare the data
            var car = new Vehicle
            {
                vehicleID = 1,
                make = "Toyota",
                model = "Corolla",
                year = new DateTime(2020, 1, 1),
                dailyRate = 50,
                passangerCapacity = 5,
                engineCapacity = 40,
                status = "Available"
            };

            // Act: Perform the action
            _carLeaseRepo.AddCar(car);

            // Assert: Verify the result
            var addedCar = _carLeaseRepo.ListAvailableCars().FirstOrDefault(c => c.vehicleID == car.vehicleID);
            Assert.IsNotNull(addedCar);
            Assert.AreEqual(car.make, addedCar.make);
        }

        [Test]  // Test case for creating a lease
        public void CreateLease_Should_Create_Lease_Successfully()
        {
            // Arrange: Prepare the data
            var customer = new Customer
            {
                customerID = 1,
                firstName = "John",
                lastName = "Doe",
                email = "john@example.com",
                phoneNumber = "1234567890"
            };
            _customerRepo.AddCustomer(customer);  // Assuming you have a method to add a customer

            var car = new Vehicle
            {
                vehicleID = 1,
                make = "Toyota",
                model = "Corolla",
                year = new DateTime(2020, 1, 1),
                dailyRate = 50,
                passangerCapacity = 5,
                engineCapacity = 40,
                status = "Available"
            };
            _carLeaseRepo.AddCar(car);

            // Act: Create lease
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(5);  // Lease for 5 days
            Lease newLease = _carLeaseRepo.CreateLease(customer.customerID, car.vehicleID, startDate, endDate);

            // Assert: Verify the result
            Assert.IsNotNull(newLease);
            Assert.AreEqual(customer.customerID, newLease.customerID);
            Assert.AreEqual(car.vehicleID, newLease.vehicleID);
        }

        [Test]  // Test case for retrieving a lease
        public void GetLease_Should_Return_Lease_Successfully()
        {
            // Arrange: Create customer and car as shown in the previous test
            var customer = new Customer
            {
                customerID = 1,
                firstName = "Jane",
                lastName = "Doe",
                email = "jane@example.com",
                phoneNumber = "0987654321"
            };
            _customerRepo.AddCustomer(customer);

            var car = new Vehicle
            {
                vehicleID = 2,
                make = "Honda",
                model = "Civic",
                year = new DateTime(2020, 1, 1),
                dailyRate = 60,
                passangerCapacity = 5,
                engineCapacity = 45,
                status = "Available"
            };
            _carLeaseRepo.AddCar(car);

            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(3);
            _carLeaseRepo.CreateLease(customer.customerID, car.vehicleID, startDate, endDate);

            // Act: Retrieve the lease
            var lease = _carLeaseRepo.ListActiveLeases().FirstOrDefault(l => l.customerID == customer.customerID && l.vehicleID == car.vehicleID);

            // Assert: Verify the lease was retrieved successfully
            Assert.IsNotNull(lease);
            Assert.AreEqual(customer.customerID, lease.customerID);
            Assert.AreEqual(car.vehicleID, lease.vehicleID);
        }

        [Test]  // Test case for exception when customer ID is not found
        public void CreateLease_Should_Throw_Exception_When_Customer_Not_Found()
        {
            // Arrange
            int nonExistentCustomerId = 999;  // ID that doesn't exist
            var car = new Vehicle
            {
                vehicleID = 1,
                make = "Toyota",
                model = "Corolla",
                year = new DateTime(2020, 1, 1),
                dailyRate = 50,
                passangerCapacity = 5,
                engineCapacity = 36,
                status = "Available"
            };
            _carLeaseRepo.AddCar(car);

            // Act & Assert: Verify exception is thrown
            var ex = Assert.Throws<CustomerNotFoundException>(() => _carLeaseRepo.CreateLease(nonExistentCustomerId, car.vehicleID, DateTime.Now, DateTime.Now.AddDays(5)));
            Assert.AreEqual("Customer not found.", ex.Message);  // Ensure the exception message is correct
        }

        [Test]  // Test case for exception when car ID is not found
        public void CreateLease_Should_Throw_Exception_When_Car_Not_Found()
        {
            // Arrange
            var customer = new Customer
            {
                customerID = 1,
                firstName = "Jane",
                lastName = "Doe",
                email = "jane@example.com",
                phoneNumber = "0987654321"
            };
            _customerRepo.AddCustomer(customer);

            int nonExistentCarId = 999;  // ID that doesn't exist

            // Act & Assert: Verify exception is thrown
            var ex = Assert.Throws<CarNotFoundException>(() => _carLeaseRepo.CreateLease(customer.customerID, nonExistentCarId, DateTime.Now, DateTime.Now.AddDays(5)));
            Assert.AreEqual("Car not found.", ex.Message);  // Ensure the exception message is correct
        }

        [Test]  // Test case for exception when lease ID is not found
        public void ReturnCar_Should_Throw_Exception_When_Lease_Not_Found()
        {
            // Arrange
            int nonExistentLeaseId = 999;  // ID that doesn't exist

            // Act & Assert: Verify exception is thrown
            var ex = Assert.Throws<LeaseNotFoundException>(() => _carLeaseRepo.ReturnCar(nonExistentLeaseId));
            Assert.AreEqual("Lease not found.", ex.Message);  // Ensure the exception message is correct
        }
    }
}
