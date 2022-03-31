select * from Designation;
INSERT INTO Designation VALUES('Traniees Engineer');
INSERT INTO Designation VALUES('Software Engineer');
INSERT INTO Designation VALUES('QA');
INSERT INTO Designation VALUES('Android Devloper');
INSERT INTO Designation VALUES('Senior Data Analyst');
CREATE TABLE employeedata(
Id integer Not null identity PRIMARY KEY,
FName varchar(50) Not null,
MName varchar(50),
LName varchar(50) Not null,
DOB date Not null,
Mno varchar(10) Not null,
Address varchar(100),
Salary Decimal,
DId int,
FOREIGN KEY (DId) REFERENCES Designation(id)
);
select * from employeedata;
INSERT INTO employeedata VALUES('Deval',' G ','Patel','1996-08-31','7999469001','ANAND',25000,2);
INSERT INTO employeedata VALUES('SURBHI',' S ','Patel','1998-05-03','8997869001','KHEDA',10000,1);
INSERT INTO employeedata VALUES('GANESH',' V ','Patel','1997-01-04','8190469071',' ',31000,3);
INSERT INTO employeedata VALUES('DHRUV',' D ','HARSORA','2001-12-17','7555467893','SURAT',5000,4);
INSERT INTO employeedata VALUES('ARSH','  ','Patel','2001-11-30','9989479803','RAJKOT',50000,2);
INSERT INTO employeedata VALUES('ARSH','  ','Patel','2001-11-30','9989479803',' ',10000,5);
-- count the number of records by designation name
select COUNT(*) as NoOfDesignation from Designation;
--  display First Name, Middle Name, Last Name & Designation name
select employeedata.FName,employeedata.MName,employeedata.LName,Designation.Designation from employeedata inner join Designation 
on employeedata.DId=Designation.Id;

exec Storeprocedure4;-- insert data
select * from employeedata;

exec Storeprocedure;-- insert data
select * from Designation;

--database view that outputs Employee Id, First Name, Middle Name, Last Name, Designation, DOB, Mobile Number, Address & Salary
select * from [viewdataemp];

exec Storeprocedure1;--update data
select * from Designation;

exec Storeprocedure2;--ordered by DOB
exec Storeprocedure3 3;--records should be ordered by First Name(designation id (Input) )
--display designation names that have more than 1 employee
SELECT D.Designation FROM
Designation D WHERE (SELECT COUNT(*)
FROM employeedata e
WHERE e.DId = D.id) > 1

--Non-Clustered index on the DesignationId
Create nonclustered index Xdesignation on employeedata([DID] DESC);
execute sp_helpindex employeedata;

--maximum salary
select MAX(salary) from employeedata;


