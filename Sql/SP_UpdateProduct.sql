USE Examen
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =====================================================
-- Author:      Ericc Gaxiola
-- Create Date: 29/03/2022
-- Description: Actualiza un registro de la tabla.
-- =====================================================
CREATE PROCEDURE SP_UpdateProduct
	@Id INT,
	@Name NVARCHAR(250),
	@Price MONEY
AS
BEGIN
    SET NOCOUNT ON

    UPDATE Product SET Name = @Name, Price = @Price, Modification = GETDATE()
	WHERE Id = @Id
	
END
GO
