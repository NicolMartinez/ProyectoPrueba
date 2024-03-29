

-- Se crea la base de datos
CREATE DATABASE MilesCarRentalDB;
GO

USE MilesCarRentalDB;
GO

-- Se crea tabla de ciudades
CREATE TABLE City
(
	Id				BIGINT PRIMARY KEY IDENTITY(1,1),
	Name			VARCHAR(100) UNIQUE,
	Coordinates		VARCHAR(100)
)

-- Se crea tabla de estados
CREATE TABLE State
(
	Id				BIGINT PRIMARY KEY IDENTITY(1,1),
	Description		VARCHAR(100)
)

-- Se agrega tabla de Vehiculos
CREATE TABLE Vehicle
(
	Id				BIGINT PRIMARY KEY IDENTITY(1,1),
	Plate			VARCHAR(10) UNIQUE,
	VIN				VARCHAR(100),
	Brand			VARCHAR(100),
	Model			VARCHAR(100),
	RentalPrice		DECIMAL(18,2),
	IdCity			BIGINT,
	IdState			BIGINT,
	FOREIGN KEY (IdCity) REFERENCES City(Id),
	FOREIGN KEY (IdState) REFERENCES State(Id)
)


-- INSERT DATOS

INSERT INTO City 
VALUES ('BOGOTA', '4.713976516258015, -74.08447548050484'),
('MEDELLIN', '6.247444056596838, -75.55855309367774'),
('BUCARAMANGA', '7.119374518091056, -73.12508247002195'),
('CALI', '3.451265371870177, -76.53390727774907'),
('ARMENIA', '4.535254287476289, -75.67574397589061'),
('IBAGUE', '4.444122068278347, -75.23947848173485'),
('CARTAGENA', '10.39327355889761, -75.48140384322365'),
('BARRANQUILLA', '11.004423499627112, -74.8026698195423'),
('CUCUTA', '7.8898844262333645, -72.49583832379052'),
('MANIZALES', '5.064076092359123, -75.50424836891408'),
('VILLAVICENCIO', '4.1485552082974975, -73.62863033915558'),
('PEREIRA', '4.808983614801988, -75.69028568998432'),
('SANTA MARTA', '11.239943057079918, -74.21295294443378'),
('POPAYAN', '2.444691365622152, -76.61487455704453'),
('NEIVA', '2.934704231349167, -75.28028581650977')

INSERT INTO State
VALUES ('DISPONIBLE'), ('RENTADO'), ('RESERVADO')

INSERT INTO Vehicle
VALUES ('AWS123', '7QW8W9ER1D56', 'CHEVROLET', '2020', 110000, 1, 1),
('ERT478', '65SDA65DA59D', 'CHEVROLET', '2020', 50000, 2, 1),
('SDF456', '5FD47S8D7F4S', 'SUSUKI', '2021', 180000, 3, 3),
('XCV123', 'S7DF877SD4F1', 'RENAULT', '2022', 50000, 4, 1),
('TYU965', '8WE4RWE4RW4R', 'FORD', '2023', 110000, 5, 2),
('RFT854', '4C1V45X4VX54', 'RENAULT', '2020', 110000, 6, 1),
('GHY965', '7E44WER1WER4', 'CHEVROLET', '2024', 50000, 7, 1),
('EFT824', '4V4X6V14XV15', 'FORD', '2021', 180000, 8, 1),
('SCF153', 'EWR41WR1W1E5', 'SUSUKI', '2022', 110000, 9, 3),
('EDF965', 'D74F51SF1556', 'RENAULT', '2023', 50000, 10, 1),
('RGY852', 'Z54CX1Z5CX87', 'CHEVROLET', '2020', 180000, 11, 1),
('BHU965', 'FGD45FG16D54', 'RENAULT', '2024', 110000, 12, 2),
('IOP821', '5S41D5AD747A', 'CHEVROLET', '2020', 50000, 13, 1),
('WDT782', '201VCX6V15XC', 'FORD', '2021', 110000, 14, 3),
('ZSQ159', '54W154E15QW4', 'SUSUKI', '2022', 50000, 15, 1),
('QSC357', 'G74D8G74G1D4', 'CHEVROLET', '2023', 110000, 1, 2),
('UHY965', 'WE54R15WER1W', 'FORD', '2024', 180000, 2, 1)


SELECT * FROM Vehicle
SELECT * FROM City
SELECT * FROM State

