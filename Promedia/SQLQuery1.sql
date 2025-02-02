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
