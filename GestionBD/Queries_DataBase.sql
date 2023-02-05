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
--Gestion de Rutas
--Tabla Lugar
CREATE TABLE Lugar
(
Id int IDENTITY(1,1) primary key ,
Nombre varchar(50),
Latitud decimal(18,10),
Longitud decimal(18,10),
Canton varchar(50),
Provincia varchar(50)
);
--Tabla Ruta
CREATE TABLE Ruta
(
Id int IDENTITY(1,1) primary key ,
IdLugarOrigen int,
IdLugarDestino int,
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_LugarRutaO FOREIGN KEY (IdLugarOrigen) REFERENCES Lugar (Id),
CONSTRAINT fk_LugarRutaD FOREIGN KEY (IdLugarDestino) REFERENCES Lugar (Id)
);
--Gestion de Buses
--Tabla Bus
CREATE TABLE Bus
(
Id int IDENTITY(1,1) primary key ,
IdCooperativa int,
Numero varchar(15),
Anio int,
RamvCpn varchar(25),
ModeloCar varchar(25),
MarcaCh varchar(25),
Transporte varchar(25),
Pisos int NOT NULL,
Capacidad int NOT NULL,
Puertas int NOT NULL,
RutaImagen varchar(150),
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_CooperativaBus FOREIGN KEY (IdCooperativa) REFERENCES Cooperativa (Id)
);
--Tabla Categoria de Asientos
CREATE TABLE Categoria
(
Id int IDENTITY(1,1) primary key ,
Descripcion varchar(50),
IdCooperativa int,
CONSTRAINT fk_CooperativaCategoria FOREIGN KEY (IdCooperativa) REFERENCES Cooperativa (Id)
);
--Tabla Asiento
CREATE TABLE Asiento
(
Id int IDENTITY(1,1) primary key ,
IdBus int,
Orden int,
Descripcion varchar(25),
IdCategoria int, 
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_BusAsiento FOREIGN KEY (IdBus) REFERENCES Bus (Id),
CONSTRAINT fk_CategoriaAsiento FOREIGN KEY (IdCategoria) REFERENCES Categoria (Id)
);
--Gestión de Frecuencias
--Tabla Frecuencia
CREATE TABLE Frecuencia
(
Id int IDENTITY(1,1) primary key ,
IdRuta int,
IdCooperativa int,
HoraSalida varchar(5),
HoraArribo varchar(5),
Habilitado bit,
IdUsuarioH int,
DiaSemana char(1),
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_RutaFrecuencia FOREIGN KEY (IdRuta) REFERENCES Ruta (Id),
CONSTRAINT fk_CooperativaFrecuencia FOREIGN KEY (IdCooperativa) REFERENCES Cooperativa (Id),
CONSTRAINT fk_UsuarioFrecuencia FOREIGN KEY (IdUsuarioH) REFERENCES Usuario (Id)
);
--Tabla Frecuencia_Bus
CREATE TABLE Frecuencia_Bus
(
Id int IDENTITY(1,1) primary key ,
IdFrecuencia int,
IdBus int,
Habilitado bit,
IdUsuarioH int,
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_Frecuencia_FrecuenciaBus FOREIGN KEY (IdFrecuencia) REFERENCES Frecuencia (Id),
CONSTRAINT fk_Bus_FrecuenciaBus FOREIGN KEY (IdBus) REFERENCES Bus (Id),
CONSTRAINT fk_Usuario_FrecuenciaBus FOREIGN KEY (IdUsuarioH) REFERENCES Usuario (Id)
);
--Tabla Frecuencia_Parada
CREATE TABLE Frecuencia_Parada
(
Id int IDENTITY(1,1) primary key ,
IdFrecuencia int,
IdLugar int,
Orden int,
Estado varchar(3) Default('ACT'),
CONSTRAINT fk_Frecuencia_FrecuenciaParada FOREIGN KEY (IdFrecuencia) REFERENCES Frecuencia (Id),
CONSTRAINT fk_Lugar_FrecuenciaParada FOREIGN KEY (IdLugar) REFERENCES Lugar (Id)
);
--Tabla Viaje
CREATE TABLE Viaje
(
Id int IDENTITY(1,1) primary key ,
IdFrecuenciaBus int,
Fecha date,
Estado varchar(15) Default('Creado'),
CONSTRAINT fk_FrecuenciaBusViaje FOREIGN KEY (IdFrecuenciaBus) REFERENCES Frecuencia_Bus (Id)
);
--Tabla DetalleViaje
CREATE TABLE DetalleViaje
(
Id int IDENTITY(1,1) primary key ,
IdViaje int,
IdAsiento int,
Estado varchar(15) Default('Disponible'),
CONSTRAINT fk_ViajeDetalleViaje FOREIGN KEY (IdViaje) REFERENCES Viaje (Id),
CONSTRAINT fk_AsientDetalleViaje FOREIGN KEY (IdAsiento) REFERENCES Asiento (Id)
);