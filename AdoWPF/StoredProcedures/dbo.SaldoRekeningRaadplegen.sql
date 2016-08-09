CREATE PROCEDURE SaldoRekeningRaadplegen (@rekeningNr nvarchar(14))
AS
select Saldo
from Rekeningen
where RekeningNr=@rekeningNr
