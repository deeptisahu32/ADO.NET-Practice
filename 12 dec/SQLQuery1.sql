create procedure searchbysal(@s int)
as
select * from employee where salary>@s;
