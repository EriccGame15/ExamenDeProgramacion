USE Examen
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =====================================================
-- Author:      Ericc Gaxiola
-- Create Date: 29/03/2022
-- Description: Inserta un registro de la tabla.
-- =====================================================
CREATE PROCEDURE SP_InsertProduct
	@Name NVARCHAR(250),
	@Price MONEY
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO Product (Name, Price, Creation, Modification)
	VALUES (@Name, @Price, GETDATE(),  '01/01/1900')

	SELECT CAST(SCOPE_IDENTITY() as int)

END
GO
