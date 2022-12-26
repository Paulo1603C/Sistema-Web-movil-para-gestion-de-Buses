--Gestion de usuarios
--22/12/2022 : 17:19
-- Ing. Toapanta Diego
USE [MovilmitogBuses]
--Tabla Rol
CREATE TABLE Rol
(
Id int IDENTITY(1,1) primary key ,
Nombre varchar(150) not null,
Descripcion varchar(250),
Estado varchar(3) Default('ACT')
);
--Sentencias
INSERT INTO Rol (Nombre, Descripcion,Estado) values('','','ACT')
UPDATE Rol Set Nombre='', Descripcion='' WHERE Id=#
UPDATE Rol Set Estado='ELI' WHERE Id=#
Select Nombre, Descripcion FROM Rol WHERE Estado='ACT'
Select * FROM Rol WHERE Estado='ACT'

--Tabla Uusario
CREATE TABLE Usuario
(
Id int IDENTITY(1,1) primary key ,
Nombre varchar(50),
Apellido varchar(50),
TipoIdentificacion char(1) NOT NULL default 'C',
NumeroIdentificacion varchar(25),
Telefono varchar(25),
Correo varchar(50),
Direccion varchar(250),
Usuario varchar(50) NOT NULL,
Password varchar(50) NOT NULL,
IdRol int NOT NULL,
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_RolUsuario FOREIGN KEY (IdRol) REFERENCES Rol (Id)
);
--Tabla Cooperativa
CREATE TABLE Cooperativa
(
Id int IDENTITY(1,1) primary key ,
Nombre varchar(150),
Representante varchar(250),
Telefono varchar(25),
Correo varchar(50),
PaginaWeb varchar(50),
Estado varchar(3) Default('ACT')
);