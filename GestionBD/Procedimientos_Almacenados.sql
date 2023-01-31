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








