--creating the carrental database 
create database [Car Rental Platform]
--using the car rental database 
use [Car Rental Platform]
/* creating the table with following schema 
1. Customer Table: 
• CustomerID (Primary Key): Unique identifier for each customer. 
• FirstName: First name of the customer. 
• LastName: Last name of the customer. 
• Email: Email address of the customer for communication. 
• PhoneNumber: Contact number of the customer. 
• Address: Customer's residential address. 
• Username: Unique username for customer login. 
• Password: Securely hashed password for customer authentication. 
• RegistrationDate: Date when the customer registered. */

create table Customer(
CustomerId int primary key identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Email varchar(20) unique,
phoneNumber numeric,
[Address] varchar(50),
Username varchar(20)  unique,
Password varchar(20),
RegistrationDate datetime)

--inserting values into customer table

insert into Customer
values('sunil','ganesh','sunil@gmail.com',7013373120,'1/44-Triupathi','sunil2435','Sunil@2435',getdate()),
('rohith','sai','rohith@gmail.com',9394416682,'14-Srikalahasthi','Rohith143','Rohith@143',getdate()),
('sai','ganesh','sai@gmail.com',9652636425,'14-chennai','saiganesh123','sai@123',getdate())


/* creating the table with following schema 
2. Vehicle Table: 
• VehicleID (Primary Key): Unique identifier for each vehicle. 
• Model: Model of the vehicle. 
• Make: Manufacturer or brand of the vehicle. 
• Year: Manufacturing year of the vehicle. 
• Color: Color of the vehicle. 
• RegistrationNumber: Unique registration number for each vehicle. 
• Availability: Boolean indicating whether the vehicle is available for rent. 
• DailyRate: Daily rental rate for the vehicle. */

create table Vehicle(
VehicleId int primary key identity(1,1),
Model varchar(20),
Make varchar(20),
[Year] datetime,
Color varchar(20),
RegistrationNumber varchar(20) unique,
Availability int,
DailyRate decimal(10,2))

--inserting into vechile
insert into Vehicle
values('Civic', 'Honda', getdate(), 'Red', 'ABC123', 1, 50.00),
('Camry', 'Toyota', getdate(), 'Black', 'XYZ456', 1, 60.00),
('Corolla', 'Toyota', getdate(), 'White', 'DEF789', 0, 55.00)

/* creating the table with following schema 
3. Reservation Table: 
• ReservationID (Primary Key): Unique identifier for each reservation. 
• CustomerID (Foreign Key): Foreign key referencing the Customer table. 
• VehicleID (Foreign Key): Foreign key referencing the Vehicle table. 
• StartDate: Date and time of the reservation start. 
• EndDate: Date and time of the reservation end. 
• TotalCost: Total cost of the reservation. 
• Status: Current status of the reservation (e.g., pending, confirmed, completed).*/

create table Reservation(
ReservationId int primary key identity(1,1),
CustomerId int,
VechileId int,
StartDate datetime,
EndDate datetime,
TotalCost decimal(10,2),
Status varchar(20),
foreign key(CustomerId) references Customer(CustomerId) on delete cascade,
foreign key(VechileId) references Vehicle(VehicleId) on delete cascade)

/*
create table Reservation(
ReservationId int primary key identity(1,1),
CustomerId int,
VechileId int,
StartDate datetime,
EndDate datetime,
TotalCost decimal(10,2),
Status as
case
when StartDate > getdate() then 'pending'
WHEN EndDate < getdate() then 'completed'
else 'confirmed'
end,
foreign key(CustomerId) references Customer(CustomerId) on delete cascade,
foreign key(VechileId) references Vehicle(VehicleId) on delete cascade)
*/
--inserting the values into the table 

insert into Reservation
values(1, 1, '2024-05-10 08:00:00', '2024-05-15 18:00:00', 300.00, 'Confirmed'),
(2, 2, '2024-06-01 10:00:00', '2024-06-05 15:00:00', 240.00, 'completed'),
(3, 3, '2024-07-20 09:00:00', '2024-07-25 12:00:00', 275.00, 'Pending');

/* creating the table with the following schema 
AdminID (Primary Key): Unique identifier for each admin. 
• FirstName: First name of the admin. 
• LastName: Last name of the admin. 
• Email: Email address of the admin for communication. 
• PhoneNumber: Contact number of the admin. 
• Username: Unique username for admin login. 
• Password: Securely hashed password for admin authentication. 
• Role: Role of the admin within the system (e.g., super admin, fleet manager). 
• JoinDate: Date when the admin joined the system.*/

create table Admin(
AdminId int primary key identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Email varchar(20) unique,
PhoneNumber decimal,
UserName varchar(20) unique,
Password varchar(20),
Role varchar(50),
JoinDate datetime)

--inserting values into the above table
insert into Admin
values('sunil','ganesh','sunil@gmail.com',7013373120,'sunil143','sunil123','Adminstrator',getdate()),
('sumanth','joe','sumanth@123',8885657120,'sumanth143','sumanth123','Manager',getdate()),
('rohith','sai','rohtih@123',9394416682,'rohtih143','rohith123','developer',getdate())


select * from Admin
select * from Customer
select * from Vehicle
select * from Reservation

