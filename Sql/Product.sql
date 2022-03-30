USE Examen

CREATE TABLE Product
(
	Id INT IDENTITY(1,1),
	Name NVARCHAR(250),
	Price MONEY,
	Creation DATETIME2,
	Modification DATETIME2,
    CONSTRAINT PK_Id PRIMARY KEY (Id)
)
GO