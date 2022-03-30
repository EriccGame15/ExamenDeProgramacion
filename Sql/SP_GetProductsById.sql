USE Examen
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ====================================================
-- Author:      Ericc Gaxiola
-- Create Date: 29/03/2022
-- Description: Obtiene el registro de la tabla por Id.
-- ====================================================
CREATE PROCEDURE SP_GetProductsById
	@Id INT
AS
BEGIN
    SET NOCOUNT ON

    SELECT Id, Name, Price, Creation, Modification 
	FROM Product
	WHERE Id = @Id

END
GO
