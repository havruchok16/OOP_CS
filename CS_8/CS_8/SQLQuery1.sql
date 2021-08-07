go
create procedure PROCed
as 
begin 
declare @k int = (select count (*) from опндюфх)
select * from опндюфх;
return @k;
end;

declare @kk int = 0;
exec @kk = PROCed;
print 'PROCEDURE = ' + cast (@kk as varchar(3));