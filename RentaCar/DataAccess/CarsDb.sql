CREATE DATABASE RentACarDb
GO
USE RentACarDb
GO
drop table Users
CREATE TABLE Users(
[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Username] NVARCHAR(MAX) NOT NULL,
[Passsword] NVARCHAR(MAX) NOT NULL,
[Email] NVARCHAR(MAX) NOT NULL
)
GO

CREATE TABLE Admins(
[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Username] NVARCHAR(MAX) NOT NULL,
[Passsword] NVARCHAR(MAX) NOT NULL
)

GO
CREATE TABLE Cars(
[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Model] NVARCHAR(MAX) NOT NULL,
[Vendor] NVARCHAR(MAX) NOT NULL,
[ImagePath] NVARCHAR(MAX) NOT NULL,
[PricePerDay] MONEY NOT NULL,
[SeatCount] INT NOT NULL,
[UserId] INT FOREIGN KEY REFERENCES Users([Id])
)
GO
INSERT INTO Users([Username],[Passsword],[Email])
VALUES ('mehemmed','12345','mehemmedbayramov2004@gmail.com'),
 ('hebib','12345','habibaliyev044@gmail.com'),
('nurlan','12345','nurlan.shirinov1998@gmail.com')

GO
INSERT INTO Admins([Username],[Passsword])
VALUES ('admin','admin')
GO
INSERT INTO Cars([Vendor],[Model],[SeatCount],[PricePerDay],[ImagePath],[UserId])
VALUES
('Mercedes','C240',5,121,'https://www.amanworld.com//images/default_car.jpg',NULL),
('AUDI','A6',5,219,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Mercedes','S500',5,790,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Bentley','Continental',4,565,'https://www.amanworld.com//images/default_car.jpg',NULL),
('BMW','530',5,200,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Mazda','CX-5',5,160,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Hyundai','Elantra',5,140,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Kia','Optima',5,130,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Mercedes','C230',5,120,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Toyota','Corolla',5,129,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Chevrolet','Cruze',5,88,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Ford','Fusion',5,188,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Mercedes','C300',5,330,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Mercedes','Vito',7,360,'https://www.amanworld.com//images/default_car.jpg',NULL),
('AUDI','Q7',5,235,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Mercedes','Viana',7,239,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Jaguar','F-Pace R',5,940,'https://www.amanworld.com//images/default_car.jpg',NULL),
('BMW','X5',5,308,'https://www.amanworld.com//images/default_car.jpg',NULL),
('Volvo','XC-90',5,290,'https://www.amanworld.com//images/default_car.jpg',NULL)

