use Employee

go

create procedure Storeprocedure
as
insert into Designation values('Software Er.')
go

create procedure Storeprocedure1
as
update Designation set [Designation] ='Asp.net Devloper' where Id=1;
go

create procedure Storeprocedure2
as
select employeedata.Id,employeedata.FName,employeedata.MName,employeedata.LName,Designation.Designation,employeedata.DOB,employeedata.Salary,employeedata.Address from employeedata inner join Designation 
on employeedata.DId=Designation.Id Order by DOB;
go

create procedure Storeprocedure3(@id int)
as
select employeedata.Id,employeedata.FName,employeedata.MName,employeedata.LName,Designation.Designation,employeedata.DOB,employeedata.Salary,employeedata.Address from employeedata inner join Designation 
on employeedata.DId=Designation.Id where employeedata.Id=@id Order by FName;
go

drop procedure Storeprocedure4;

create procedure Storeprocedure4
as
insert into employeedata values('SUResh',' S ','shah','1998-05-03','8997869001','Khambhat',10000,5)
go

create view viewdataemp as
select employeedata.Id,employeedata.FName,employeedata.MName,employeedata.LName,Designation.Designation,employeedata.DOB,employeedata.Salary,employeedata.Address from employeedata inner join Designation 
on employeedata.DId=Designation.Id;

