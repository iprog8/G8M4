create database MVC
go

create table Utilizator 
(
	Id int primary key not null Identity(1,1),
	Nume nvarchar(50) not null,
);
go

create table Poza 
(
	Id int primary key not null Identity(1,1),
	PozaUrl nvarchar (250) not null,
);
go

ALTER TABLE Poza
ADD PostareId int foreign key references Postare(Id); 

create table Postare
(
	Id int primary key not null Identity(1,1),
	Titlu nvarchar (100) null,
	Descriere nvarchar (500) null,
	PozaId int foreign key references Poza(Id) null,
	UtilizatorId int foreign key references Utilizator(Id),
);
go

insert into Utilizator
(Nume)
values
('Alex'),
('Marius'),
('Cristi')
go

insert into Postare
(UtilizatorId, Titlu, Descriere)
values
(1, 'Postare1','Descriere1'),
(2, 'Postare2','Descriere2'),
(3, 'Postare3', 'Descriere3')
go

insert into Poza
(PozaUrl)
values
('D:\html\G8M4\G8M4\Teme\Bogdan G\L02\EntityFrameWorkDbFirst\EntityFrameWorkDbFirst\Images\1.jpg'),
('D:\html\G8M4\G8M4\Teme\Bogdan G\L02\EntityFrameWorkDbFirst\EntityFrameWorkDbFirst\Images\2.jpg'),
('D:\html\G8M4\G8M4\Teme\Bogdan G\L02\EntityFrameWorkDbFirst\EntityFrameWorkDbFirst\Images\3.jpg')
go