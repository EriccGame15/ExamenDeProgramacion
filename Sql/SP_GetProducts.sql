USE Examen
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Ericc Gaxiola
-- Create Date: 29/03/2022
-- Description: Obtiene todos los registro de la tabla.
-- =============================================
CREATE PROCEDURE SP_GetProducts
AS
BEGIN
    SET NOCOUNT ON

    SELECT Id, Name, Price, Creation, Modification 
	FROM Product

END
GO
