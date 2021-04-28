CREATE DATABASE feesctidb

USE feesctidb
GO

CREATE TABLE [Inscricao] (     
	[Id] int identity(1,1) not null, 
	[Nome] varchar(50) not null, 
	[CPF] varchar(50) not null,
	[DataNascimento] date not null,
	[Status] varchar(50) not null,
	[MotivoStatusNegado] varchar(200),
	primary key(Id)
)

CREATE TABLE [Account] (     
	[Id] int not null, 
	[Username] varchar(50) not null, 
	[Password] varchar(50) not null,
	primary key(Id)
)

INSERT INTO Account(Id, Username, [Password]) VALUES (0, 'administrador', 'administrador123');
