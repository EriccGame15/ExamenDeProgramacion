USE Examen
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =====================================================
-- Author:      Ericc Gaxiola
-- Create Date: 29/03/2022
-- Description: Elimina un registro de la tabla por id.
-- =====================================================
CREATE PROCEDURE SP_DeleteProduct
	@Id INT
AS
BEGIN
    SET NOCOUNT ON

    DELETE FROM Product
	WHERE Id = @Id

END
GO
