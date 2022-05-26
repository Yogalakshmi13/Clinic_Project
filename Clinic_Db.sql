create database products

create database Clinics

use Clinics
go


----User Table----
create table LoginPage
(
FirstName varchar(20),
LastName varchar(20),
UserName varchar(40),
UserPassword varchar(8)
)
select * from LoginPage
truncate table LoginPage

insert into LoginPage values('Brindha','Jayakumar','Bindhu03','bindu3');
insert into LoginPage values('Rukshana','Kumar','Rukshi10','shana123');

----LoginValidate Procedure----
create proc Validate
@user varchar(40),
@pass varchar(8)
as
select *  from LoginPage where UserName like @user and  UserPassword like @pass

----Doctor Table---
create table Doctors
(
DoctorID int identity(101,1),
Doctor_FirstName varchar(20),
Doctor_LastName varchar(20),
Gender  varchar(8),
Specialization varchar(20),
Visiting_Hours varchar(20),
constraint PK_DocID Primary Key(DoctorID)
)

----Doctor Procedure----

create proc Doctorproc
@Doc_Fname varchar(20),
@Doc_Lname varchar(20),
@Gen varchar(8),
@Spl varchar(20),
@hrs varchar(20)
as
insert into Doctors(Doctor_FirstName,Doctor_LastName,Gender,Specialization,Visiting_Hours)
values(@Doc_Fname,@Doc_Lname,@Gen,@Spl,@hrs)

select * from Doctors

----Patient Table----
create table Patients
(
PatientId int identity(1,1),
Patient_FirstName varchar(20),
Patient_LastName varchar(20),
Gender varchar(8),
Age int,
DOB varchar(10)
constraint pk_patID primary key (PatientId)
)

drop table Patients
truncate table Patients
--Patient procedure
create proc Patientproc
@pat_Fname varchar(20),
@pat_Lname varchar(20),
@Gen varchar(8),
@age int,
@dob varchar(10)
as
insert into Patients(Patient_FirstName,Patient_LastName,Gender,Age,DOB)
values(@pat_Fname,@pat_Lname,@Gen,@age,@dob)

delete  from Patients where PatientId=1
select * from Patients
drop proc Patientproc
----Schedules----
create table Schedules
(
AppointmentID int identity(1001,1),
PatientId int,
Specialization varchar(20),
Doctor varchar(20),
VisitDate varchar(10),
AppointmentTime varchar(10)
)

--schedule procedure
create proc ScheduleProc
@patid int,
@Spl varchar(20),
@doc varchar(20),
@visit varchar(10),
@v_time varchar(10)
as 
insert into Schedules(PatientId,Specialization, Doctor, VisitDate, AppointmentTime)
values(@patid,@Spl,@doc,@visit,@v_time)


select * from Schedules


----Schedule View----
create proc GetSchedule
as
select * from Schedules

exec GetSchedule
drop proc GetSchedule
create proc GetSchedule
as
select Patientid,Specialization, Doctor, VisitDate, AppointmentTime
from Schedules


create proc DoctorApp
as
select * from Doctors


create proc PatientApp
as
select * from Patients

----Cancel Appointment----
create proc CancelAppoint
@patid varchar(20)
as
delete Schedules where Patientid=@patid
