create table Page (
	Id int Primary Key not null Identity(1,1),
	NumePagina nvarchar(50) not null,
	NumarAccesari int not null,
);
go
insert into Page
(NumePagina, NumarAccesari)
values
('HomeIndex',0),
('HomeAbout',0),
('HomeContact',0)
