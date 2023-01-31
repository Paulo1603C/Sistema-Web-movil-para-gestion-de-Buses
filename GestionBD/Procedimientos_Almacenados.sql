--SP Gestion de Roles
USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertarRol]    Script Date: 30/01/2023 20:08:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertarRol] 
@Nombre varchar(150),
@Descripcion varchar(250)
AS
BEGIN 
INSERT INTO Rol values(@Nombre, @Descripcion, 'ACT');
SELECT SCOPE_IDENTITY();
END
GO

USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_ActualizarRol]    Script Date: 30/01/2023 20:09:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Actualiza registro con estado Activo por Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_ActualizarRol]  
@Id int,
@Nombre varchar(150),
@Descripcion varchar(250)
AS
BEGIN 
UPDATE Rol SET Nombre=@Nombre, Descripcion=@Descripcion
WHERE Id=@Id
END

--EXEC sp_GetRolById
GO
USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_ListarRoles]    Script Date: 30/01/2023 20:10:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Listar Roles registrados con estado Activo
-- =============================================
CREATE PROCEDURE [dbo].[sp_ListarRoles]
AS
BEGIN 
SELECT
  Id
, Nombre
, Descripcion
FROM Rol
WHERE Estado='ACT'
END
GO


USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_ObtenerRolPorId]    Script Date: 30/01/2023 20:11:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Obtener Rol registrado con estado Activo por Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_ObtenerRolPorId] 
@Id int
AS
BEGIN 
SELECT
  Id
, Nombre
, Descripcion
FROM Rol
WHERE Estado='ACT' and Id=@Id
END

--EXEC sp_GetRolById
GO
USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_EliminarRol]    Script Date: 30/01/2023 20:11:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Elimina registro con estado Activo por Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_EliminarRol]  
@Id int
AS
BEGIN 
Update Rol Set Estado='ELI' Where Id=@Id 
END

--EXEC sp_GetRolById
--Exec sp_ListarRoles


GO

-- SP Gestion de Uusarios
USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 30/01/2023 20:12:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_InsertarUsuario] 
@Nombre varchar(50),
@Apellido varchar(50),
@TipoIdentificacion char(1),
@NumeroIdentificacion varchar(25),
@Telefono varchar(25),
@Correo varchar(50),
@Direccion varchar(250),
@Usuario varchar(50),
@Password varchar(50),
@IdRol int
AS
BEGIN 
INSERT INTO Usuario values(@Nombre, @Apellido, @TipoIdentificacion, @NumeroIdentificacion, @Telefono, @Correo, @Direccion, @Usuario, @Password, @IdRol , 'ACT');
SELECT SCOPE_IDENTITY();
END
GO


USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_ActualizarUsuario]    Script Date: 30/01/2023 20:13:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Actualiza registro con estado Activo por Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_ActualizarUsuario]  
@Id int,
@Nombre varchar(50),
@Apellido varchar(50),
@TipoIdentificacion char(1),
@NumeroIdentificacion varchar(25),
@Telefono varchar(25),
@Correo varchar(50),
@Direccion varchar(250),
@Usuario varchar(50),
@Password varchar(50),
@IdRol int
AS
BEGIN 
UPDATE Usuario SET Nombre=@Nombre,Apellido=@Apellido,TipoIdentificacion=@TipoIdentificacion,NumeroIdentificacion=@NumeroIdentificacion,Telefono=@Telefono,Correo=@Correo,Direccion=@Direccion,Usuario=@Usuario,[Password]=@Password,IdRol=@IdRol 
WHERE Id=@Id
END
GO


USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_ListarUsuarios]    Script Date: 30/01/2023 20:14:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Listar Usuarios registrados con estado Activo
-- =============================================
CREATE PROCEDURE [dbo].[sp_ListarUsuarios]
AS
BEGIN 
SELECT
Id ,
Nombre ,
Apellido ,
TipoIdentificacion ,
NumeroIdentificacion ,
Telefono ,
Correo ,
Direccion ,
Usuario ,
[Password] ,
IdRol ,
(Select Nombre From Rol s Where s.Id=IdRol and s.Estado='ACT') as Rol
FROM Usuario
WHERE Estado='ACT'
END
GO


USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_ObtenerUsuarioLogin]    Script Date: 30/01/2023 20:14:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Movilmitog Team
-- Create date: 12/01/2023
-- Description:	Obtener Usuario registrado por Datos de Login
-- =============================================
CREATE PROCEDURE [dbo].[sp_ObtenerUsuarioLogin] 
@userName varchar(50),
@password varchar(50)
AS
BEGIN 
SELECT
Id ,
Nombre ,
Apellido ,
TipoIdentificacion ,
NumeroIdentificacion ,
Telefono ,
Correo ,
Direccion ,
Usuario ,
[Password] ,
IdRol,
(Select s.Nombre From Rol s Where s.Id=IdRol) as Rol
FROM Usuario
WHERE Estado='ACT' and (NumeroIdentificacion=@userName or Correo=@userName or Usuario=@userName)
and Password=@password
END
GO


USE [MovilmitogBuses]
GO

/****** Object:  StoredProcedure [dbo].[sp_EliminarUsuario]    Script Date: 30/01/2023 20:14:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Movilmitog Team
-- Create date: 06/01/2023
-- Description:	Elimina registro con estado Activo por Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_EliminarUsuario]  
@Id int
AS
BEGIN 
Update Usuario Set Estado='ELI' Where Id=@Id 
END
GO









