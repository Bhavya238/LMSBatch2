create database Final1
use Final1


create table Employee(
EmpId int primary key identity(1,1),
EmpName varchar(20),
EmpEmail varchar(20),
EmpUname varchar(10),
EmpPass varchar(10),
EmpAddress varchar(15),
EmpPhone varchar(10),
EmpSalary int,
LeaveBalance int,
ManagerId int
);


create table Leave(
LeaveId int primary key identity(101,1),
LeaveType varchar(20),
LeaveStatus varchar(20) default 'Pending',
LeaveReason varchar(20),
LeaveStartDate date,
LeaveEndDate date,
EmpId int,
ManagerId int

)

insert into Employee values
('Micahel','Micahel1@gmail.com','Michael_1','Pass@123','Banglore','8989898989',200000,20,1),
('Jack','Jack2@gmail.com','Jack_2','Pass@123','Hyderabad','9090909090',32000,10,1),
('Rosy','Rosy3@gmail.com','Rosy_3','Pass@123','Hyderabad','7878787889',25000,10,2)


insert into Employee values
('Smarty','Smarty4@gmail.com','Smarty_4','Pass@123','Chennai','9090909090',40500,10,1,2,'Manager'),
('Rajesh','Rajesh5@gmail.com','Rajesh_5','Pass@123','Pune','9090909090',43000,10,1,2,'Manager')

select * from Employee

alter table Employee add  extraLeave int

select * from Leave
delete from leave where LeaveId=221
insert into Employee values ('Nandu','Nandu7@gmail.com','Nandu_7','Pass@123','Hyderabad','9292929299',200000,10,2,3,'developer'),
('Jill','Jill8@gmail.com','Jill_8','Pass@123','Hyderabad','9090907577',32000,10,2,3,'Tester'),
('Rose','Rose9@gmail.com','Rose_9','Pass@123','chennai','7883887889',25000,10,5,3,'developer'),
('Mike','Mike10@gmail.com','Mike_10','Pass@123','chennai','9594898989',200000,10,5,3,'executive'),
('Jacob','Jacob11@gmail.com','Jacob_11','Pass@123','chennai','7373709090',32000,10,5,3, 'tester'),
('Rand','Rand12@gmail.com','Rand_12','Pass@123','banglore','5454787889',25000,10,6,3,'developer')

update Employee set EmpSalary=48900 where EmpId=13

select * from Employee


update Leave set ManagerId=5 where LeaveId=168
update Leave set LeaveStatus='Pending' where leaveId=167
alter table Employee add Designation varchar(10)

alter table Employee add Level int

update Employee set LeaveBalance=10   Where EmpId=3
update Employee set EmpSalary=30000 where EmpId=3

alter table Leave add LeaveBalance int

update  Leave set LeaveBalance=10 where LeaveId=103

update  Employee set EmpUname='Rajesh_6' where empId=6
insert into Employee values

('Matt','Matt13@gmail.com','Matt_13','Pass@123','pune','6363698989',200000,10,6,3,'executive'),
('Jane','Jane14@gmail.com','Jane_14','Pass@123','pune','7373709075',32000,10,6,3, 'tester')

update Leave set LeaveBalance=10 where LeaveId=168