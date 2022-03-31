CREATE TABLE employee(
Id integer Not null identity PRIMARY KEY,
FName varchar(50) Not null,
MName varchar(50),
LName varchar(50) Not null,
DOB date Not null,
Mno varchar(10) Not null,
Address varchar(100) 
);
SELECT * FROM employee;
INSERT INTO employee VALUES('Deval',' G ','Patel','1996-08-31','7999469001','ANAND');
INSERT INTO employee VALUES('SURBHI',' S ','Patel','1998-05-03','8997869001','KHEDA');
INSERT INTO employee VALUES('GANESH',' V ','Patel','1997-01-04','8190469071','ANAND');
INSERT INTO employee VALUES('DHRUV',' D ','HARSORA','2001-12-17','7555467893','SURAT');
INSERT INTO employee VALUES('ARSH',' Y ','Patel','2001-11-30','9989479803','RAJKOT');
INSERT INTO employee VALUES('ARSH','  ','Patel','2001-11-30','9989479803',' ');

UPDATE Employee SET [FName]='SQLPerson' where Id=1;
SELECT * FROM employee;
UPDATE Employee SET [MName]='I';
delete from employee where Id < 2;
delete from employee;