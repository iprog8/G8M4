create database MVC
go 
use MVC
go

create Table Utilizator (
	Id int Primary Key not null Identity(1,1),
	Nume nvarchar (50) not null,
);
go 

create Table Postare (
	Id int Primary Key not null Identity(1,1),
	UtilizatorId int not null references Utilizator(Id),
	Titlu nvarchar (25) null,
	Descriere nvarchar (250) null,
);
go

create Table Poza (
	Id int Primary Key not null Identity(1,1),
	PostareId int not null references Postare(Id),
	DrumSprePoza nvarchar (200) not null,
);
go

 insert into Utilizator 
 (Nume)
 values 
 ('Marian'),
 ('Ion'),
 ('Marcel')
 go

 insert into Postare 
 (UtilizatorId, Titlu, Descriere)
 values
 (1, 'Prima postare','Aceasta este prima mea postare'),
 (2, 'Sunt nou aici','Salut, sunt nou aici si as vrea sa facem cunostiinta!'),
 (3, 'Am nevoie de ajutor','Salut, am o problema cu pc-ul si as avea nevoie de putin ajutor')
 go

 insert into Poza 
 (PostareId, DrumSprePoza)
 values 
 (1, 'D:\Curs\My code\G8M4\Teme\Gabriel Hanu\L2\Images\primaPostare.jpg'),
 (2, 'D:\Curs\My code\G8M4\Teme\Gabriel Hanu\L2\Images\suntNouAici.jpg'),
 (3, 'D:\Curs\My code\G8M4\Teme\Gabriel Hanu\L2\Images\pcStricat.jpg'),
 (3, 'D:\Curs\My code\G8M4\Teme\Gabriel Hanu\L2\Images\ecranStricat.jpg')
 go

