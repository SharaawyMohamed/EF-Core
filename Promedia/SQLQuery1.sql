create Database Promedia;
use Promedia;

Create Table Student(
Id int primary key identity(1,1),
FirstName nvarchar(20) not null,
LastName nvarchar(20) not null,
NationalId char(14)not null,
BirthOfDate date not null,
Address nvarchar(50) not null,
Gender char(1) not null
)

create procedure SP_GetAllStudents
with encryption
as
select * from Student

create or alter procedure SP_GetStudentById (@Id int)
with encryption
as 
select * from Student
where @Id=Id

create or alter procedure SP_DeleteStudentById (@Id int)
with encryption
as
  delete from Student
  where @Id=Id

create or alter procedure SP_UpdateStudent(
  @Id int,
  @FName nvarchar(20),
  @LName nvarchar(20),
  @NationalId char(14),
  @BirthDate date,
  @Address nvarchar(50),
  @Gender char(1)
  )
with encryption 
as
  update Student
  set FirstName=@FName,
  LastName=@LName,
  NationalId=@NationalId,
  BirthOfDate=@BirthDate,
  Address=@Address,
  Gender=@Gender
  where Id=@Id


create or alter procedure SP_AddStudent(
@FName nvarchar(20),
@LName nvarchar(20),
@NationalId char(14),
@BirthDate date,
@Address nvarchar(50),
@Gender char(1))
with encryption
as
  insert into 
  Student (FirstName,LastName,NationalId, BirthOfDate, Address, Gender)
  values(@FName, @LName, @NationalId, @BirthDate, @Address, @Gender)

create or alter procedure SP_ValidNationalId(@NationalId char(14))
with encryption 
as 
select COUNT(*)
from Student
where NationalId=@NationalId


