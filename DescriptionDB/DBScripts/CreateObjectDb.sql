aGO
SET DATEFORMAT dmy;
GO
CREATE DATABASE OfficeEquipment
GO
USE OfficeEquipment
GO
CREATE TABLE TypeEquipment (
    Id      INT  IDENTITY (1, 1) PRIMARY KEY,
    Code    NVARCHAR (50)  NOT NULL,
    Name    NVARCHAR (100) NOT NULL,
    Kind    NVARCHAR (50)  NULL
);
GO
CREATE TABLE Equipment (
    Id              INT IDENTITY (1, 1) PRIMARY KEY,
    Code            NVARCHAR (50)  NOT NULL,
    Name            NVARCHAR (100) NOT NULL,
    Amount          INT NOT NULL,        
    Price           DECIMAL (10, 2) NULL,
    TypeEquipmentId INT REFERENCES TypeEquipment (Id) ON DELETE CASCADE ON UPDATE CASCADE
);
GO