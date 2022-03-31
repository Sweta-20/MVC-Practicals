CREATE TABLE employeedetails(
Id integer Not null identity PRIMARY KEY,
FName varchar(50) Not null,
MName varchar(50),
LName varchar(50) Not null,
DOB date Not null,
Mno varchar(10) Not null,
Address varchar(100),
Salary Decimal Not null
);
select * from employeedetails;
INSERT INTO employeedetails VALUES('Deval',' G ','Patel','1996-08-31','7999469001','ANAND',25000);
INSERT INTO employeedetails VALUES('SURBHI',' S ','Patel','1998-05-03','8997869001','KHEDA',10000);
INSERT INTO employeedetails VALUES('GANESH',' V ','Patel','1997-01-04','8190469071',' ',31000);
INSERT INTO employeedetails VALUES('DHRUV',' D ','HARSORA','2001-12-17','7555467893','SURAT',5000);
INSERT INTO employeedetails VALUES('ARSH','  ','Patel','2001-11-30','9989479803','RAJKOT',50000);
INSERT INTO employeedetails VALUES('ARSH','  ','Patel','2001-11-30','9989479803',' ',10000);

select sum(salary) from employeedetails;
select * from employeedetails where DOB < '01-01-2000';
select COUNT(MName) from employeedetails where MName='';