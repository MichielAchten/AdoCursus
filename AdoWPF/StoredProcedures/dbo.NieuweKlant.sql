CREATE PROCEDURE NieuweKlant(@Naam nvarchar(50))
AS
	insert into klanten(naam) values (@Naam);
	select @@identity
