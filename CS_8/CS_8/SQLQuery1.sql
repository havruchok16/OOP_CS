go
create procedure PROCed
as 
begin 
declare @k int = (select count (*) from �������)
select * from �������;
return @k;
end;

declare @kk int = 0;
exec @kk = PROCed;
print 'PROCEDURE = ' + cast (@kk as varchar(3));