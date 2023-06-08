CREATE DATABASE ParkingLot

USE ParkingLot

CREATE TABLE VehicleTypes (
	VehicleTypeID	int IDENTITY (1, 1) PRIMARY KEY,
	VehicleTypeName nvarchar(MAX) not null,
	ParkingFee		int not null
);

CREATE TABLE Vehicles (
	VehicleID			int IDENTITY (1, 1) PRIMARY KEY,
	VehicleTypeID		int not null,
	ParkingCardID		bigint not null,
	TimeStartedParking	datetime2 not null, 
	TimeEndedParking	datetime2,
	VehicleState		int not null, -- 1: Parked, 0: Unparked --
	VehicleImage		nvarchar(max) not null, -- the path to the vehicle's image --
	Fee					int not null,
	StaffID				int
);

CREATE TABLE ParkingCards (
	ParkingCardID	bigint PRIMARY KEY,
	CardType		int not null, -- 0: Vang lai, 1: Thang
	CardState		int not null -- 1: Used, 0: Unused --
);

CREATE TABLE Accounts (
	AccountID		int IDENTITY (1, 1) PRIMARY KEY,
	StaffID			int not null,
	RoleID			int not null,
	AccountName		nvarchar(MAX) not null,
	AccountPassword nvarchar(MAX) not null,
)

CREATE TABLE Roles (
	RoleID		int IDENTITY (1, 1) PRIMARY KEY,  -- 1: staff, 2: admin --
	RoleName	nvarchar(MAX) not null
);

CREATE TABLE Staff (
	StaffID			int IDENTITY (1, 1) PRIMARY KEY,
	CivilID			nvarchar(MAX) not null,
	StaffName		nvarchar(MAX) not null,
	RoleID			int not null,
	PhoneNumber		nvarchar(MAX),
	StaffAddress	nvarchar(MAX),
	DateOfBirth		date,
	IsDeleted		bit default 0, -- 0: false, 1: true -- 
);

CREATE TABLE Timekeeps (
	TimekeepID int IDENTITY (1, 1) PRIMARY KEY,
	StaffID int not null,
	LoginTime datetime2 not null,
	LogoutTime datetime2
);

SET DATEFORMAT dmy;
--ALTER TABLE
ALTER TABLE Vehicles ADD CONSTRAINT Vehicles_VehicleTypeID_FK FOREIGN KEY (VehicleTypeID) REFERENCES VehicleTypes(VehicleTypeID);
ALTER TABLE Vehicles ADD CONSTRAINT Vehicles_StaffID_FK FOREIGN KEY (StaffID) REFERENCES Staff(StaffID);
ALTER TABLE Timekeeps ADD CONSTRAINT Timekeeps_StaffID_FK FOREIGN KEY (StaffID) REFERENCES Staff(StaffID) ON DELETE CASCADE;
ALTER TABLE Accounts ADD CONSTRAINT Accounts_StaffID_FK FOREIGN KEY (StaffID) REFERENCES Staff(StaffID) ON DELETE CASCADE;
ALTER TABLE Accounts ADD CONSTRAINT Accounts_RoleID_FK FOREIGN KEY (RoleID) REFERENCES Roles(RoleID);
ALTER TABLE Staff ADD CONSTRAINT Staff_RoleID_FK FOREIGN KEY (RoleID) REFERENCES Roles(RoleID);

--INSERT INTO
INSERT INTO Roles VALUES ('staff'), ('admin')

INSERT INTO VehicleTypes (VehicleTypeName, ParkingFee) VALUES (N'Xe máy', 4000), (N'Xe hơi', 8000), (N'Xe đạp', 1000)

INSERT INTO Staff (CivilID, StaffName, RoleID, PhoneNumber, StaffAddress, DateOfBirth) VALUES
('CCCD1233466', 'admin', 2, '09123784', '221 Baker St', '1/1/1990'),
('079202005979', 'Chatte', 1, '0945655469', '1 Holmes St', '28/12/2002'),
('079202035060', 'StarGazer', 2, '0939843426', '3 Sherlock St', '22/6/2002'),
('079202003950', 'Dragon', 1, '0868410903', '5 Watson St', '20/9/2002'),
('079202034050', 'MiMi', 2, '0916056982', '7 London St', '8/6/2002')

INSERT INTO Accounts (StaffID, RoleID, AccountName, AccountPassword) VALUES
(1, 2, 'admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918'),
(2, 1, '1', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b'),
(3, 2, '2', 'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35'),
(4, 1, '3', '4e07408562bedb8b60ce05c1decfe3ad16b72230967de01f640b7e4729b49fce'),
(5, 2, '4', '94938b8212580c530e8b2a863f2e5b03fa3b060421e752eb2a0c6941250ecaa0')

INSERT INTO Timekeeps (StaffID, LoginTime, LogoutTime) VALUES
( 1, '2023-06-09 00:07:01.7291212','2023-06-09 00:07:16.2086860'),
( 1, '2023-06-09 00:07:19.5876126','2023-06-09 00:08:06.8272546'),
( 2, '2023-06-09 00:07:19.5876126','2023-06-09 00:08:31.6599561'),
( 1, '2023-06-09 00:38:22.4294729','2023-06-09 00:38:27.9693305'),
( 2, '0001-01-01 00:00:00.0000000','2023-06-09 00:41:18.5418983'),
( 1, '2023-06-09 00:41:21.7622679','2023-06-09 00:41:28.3411406'),
( 1, '2023-06-09 00:45:49.1628018','2023-06-09 00:45:56.7665148'),
( 2, '2023-06-09 00:45:49.1628018','2023-06-09 00:46:11.4326709'),
( 1, '2023-06-09 00:48:15.5542902','2023-06-09 00:48:40.0033276'),
( 1, '2023-06-09 00:48:58.9506476','2023-06-09 00:51:48.7217780'),
( 3, '2023-06-09 00:51:51.7214336','2023-06-09 00:53:14.8826361')

INSERT INTO ParkingCards (ParkingCardID, CardType, CardState) VALUES
(1111111111,0,0),
(2222222222,0,0),
(3333333333,0,0),
(4444444444,0,0),
(5555555555,0,0)