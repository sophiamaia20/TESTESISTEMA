use master 
go 
create database SistemaTeste
use SistemaTeste

create table Veiculo (
PlacaVeiculo int identity (1,1) primary key, 
TipoCombustivel varchar (30),
NomeVeiculo varchar (100), 
) 

create table Posto (
PostoId int identity (1,1) primary key,
PostoNome varchar (100), 
) 

create table Motorista (
 CPF int identity (1,1) primary key,
 NomeCompleto varchar (200), 
 CategoriaCarteira varchar (100), 
 ) 

 CREATE TABLE TipoCombustivel (
  tipo varchar(100) primary key,
);

insert into TipoCombustivel (tipo) values ('Etanol')
insert into TipoCombustivel (tipo) values ('Gasolina Comum')
insert into TipoCombustivel (tipo) values ('Gasolina Aditivada')
insert into TipoCombustivel (tipo) values ('Diesel')

create table OrdemServiço ( 
OrdemID int identity(1,1) primary key,
MotoristaCPF int foreign key references Motorista(CPF),
dataservico date, 
QuantidadeCombustivel float,
Servicodesc varchar (200),
)




select *from Posto 
 





