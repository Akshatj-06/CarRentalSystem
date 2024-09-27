USE CarRentalSystem;


--Q1 Update the daily rate for a Mercedes car to 68.
UPDATE Vehicle
SET dailyRate = 68
WHERE make = 'Mercedes';
SELECT make, dailyRate
FROM Vehicle
WHERE make = 'Mercedes';


--Q2 Delete a specific customer and all associated leases and payments.
DELETE FROM Payment
WHERE leaseID = 1;
DELETE FROM Lease
WHERE leaseID = 1 AND customerID = 1;
DELETE FROM Customer
WHERE customerID = 1;
SELECT * FROM Customer, 

--Q3 Rename the "paymentDate" column in the Payment table to "transactionDate".
EXEC sp_rename 'Payment.paymentDate', 'transactionDate', 'COLUMN';
SELECT * FROM Payment;

--Q4 Find a specific customer by email.
SELECT *
FROM Customer
WHERE email = 'sarah@';

--Q5 Get active leases for a specific customer.
SELECT *
FROM Lease
WHERE customerID = 2
AND endDate >= GETDATE();

--Q6 Find all payments made by a customer with a specific phone number.
SELECT P.*
FROM Payment P
INNER JOIN Lease L ON P.leaseID = L.leaseID
INNER JOIN Customer C ON L.customerID = C.customerID
WHERE C.phoneNumber = 5557891234;

--Q7 Calculate the average daily rate of all available cars.
SELECT AVG(dailyRate) AS AverageDailyRate
FROM Vehicle
WHERE status = 'Available';


--Q8 Find the car with the highest daily rate.
SELECT TOP 1 *
FROM Vehicle
ORDER BY dailyRate DESC;

--Q9 Retrieve all cars leased by a specific customer.
SELECT V.*
FROM Vehicle V
INNER JOIN Lease L ON V.vehicleID = L.vehicleID
WHERE L.customerID = 3;

--Q10 Find the details of the most recent lease.
SELECT TOP 1 *
FROM Lease
ORDER BY startDate DESC;

--Q11 List all payments made in the year 2023.
SELECT *
FROM Payment
WHERE YEAR(transactionDate) = 2023;

--Q12 Retrieve customers who have not made any payments.
SELECT C.*
FROM Customer C
LEFT JOIN Lease L ON C.customerID = L.customerID
LEFT JOIN Payment P ON L.leaseID = P.leaseID
WHERE P.paymentID IS NULL;


--Q13 Retrieve Car Details and Their Total Payments.
SELECT V.vehicleID, V.make, V.model, V.dailyRate, SUM(P.Amount) AS TotalPayments
FROM Vehicle V
LEFT JOIN Lease L ON V.vehicleID = L.vehicleID
LEFT JOIN Payment P ON L.leaseID = P.leaseID
GROUP BY V.vehicleID, V.make, V.model, V.dailyRate;

--Q14 Calculate Total Payments for Each Customer.
SELECT 
    C.customerID, 
    C.firstName, 
    C.lastName, 
    COALESCE(SUM(P.Amount), 0) AS TotalPayments
FROM 
    Customer C
LEFT JOIN 
    Lease L ON C.customerID = L.customerID
LEFT JOIN 
    Payment P ON L.leaseID = P.leaseID
GROUP BY 
    C.customerID, C.firstName, C.lastName;


--Q15 List Car Details for Each Lease.
SELECT 
    L.leaseID, 
    V.vehicleID, 
    V.make, 
    V.model, 
    V.year, 
    V.dailyRate
FROM 
    Lease L
JOIN 
    Vehicle V ON L.vehicleID = V.vehicleID;


--Q16 Retrieve Details of Active Leases with Customer and Car Information.
SELECT 
    L.leaseID, 
    C.customerID, 
    C.firstName, 
    C.lastName, 
    V.vehicleID, 
    V.make, 
    V.model, 
    V.year, 
    V.dailyRate, 
    L.startDate, 
    L.endDate
FROM 
    Lease L
JOIN 
    Customer C ON L.customerID = C.customerID
JOIN 
    Vehicle V ON L.vehicleID = V.vehicleID
WHERE 
    L.endDate > GETDATE();


--Q17 Find the Customer Who Has Spent the Most on Leases.
SELECT TOP 1
    C.customerID, 
    C.firstName, 
    C.lastName, 
    SUM(P.Amount) AS TotalSpent
FROM 
    Customer C
JOIN 
    Lease L ON C.customerID = L.customerID
JOIN 
    Payment P ON L.leaseID = P.leaseID
GROUP BY 
    C.customerID, C.firstName, C.lastName
ORDER BY 
    TotalSpent DESC;


--Q18 List All Cars with Their Current Lease Information.
SELECT 
    V.vehicleID, 
    V.make, 
    V.model, 
    V.year, 
    V.dailyRate,
    L.leaseID,
    L.customerID,
    L.startDate,
    L.endDate
FROM 
    Vehicle V
LEFT JOIN 
    Lease L ON V.vehicleID = L.vehicleID
WHERE 
    L.endDate >= GETDATE();





