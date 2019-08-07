
create database EFood
use EFood

create table TipoAB (
idTipo int identity(1,1),
Nombre varchar(25) not null,
Constraint pk_TipoAB primary key(idTipo))

create table TipoServicio(
idTipoServicio int identity(1,1),
idTipoAB int not null,
Nombre varchar(25) not null,
Constraint pk_TipoServicio primary key(idTipoServicio),
Constraint fk_TipoComida_TipoAB foreign key (idTipoAB) references TipoAB(idTipo))

create table Servicio(
idServicio int identity(1,1),
idTipoAB int not null,
idTipoServicio int null,
Nombre varchar(50),
descripcion text,
precio float,
tiempo int,
imagen text,
Constraint pk_Servicio primary key(idServicio),
Constraint fk_Servicio_TipoAB foreign key (idTipoAB) references TipoAB(idTipo),
Constraint fk_Servicio_TipoServicio foreign key(idTipoServicio) references TipoServicio(idTipoServicio))

create table Mesa(
idMesa int identity(1,1),
Nombre varchar(50),
Constraint pk_Mesa primary key(idMesa))

create table Orden(
idOrden int identity(1,1),
idMesa int not null,
Descripcion text,
Fecha Datetime,
Constraint pk_Orden primary key(idOrden),
Constraint fk_Orden_Mesa foreign key(idMesa) references Mesa(idMesa))

create table Detalle_Orden(
idOrden int not null,
idServicio int not null,
cantidad int not null,
Constraint pk_DetalleOrden primary key(idOrden,idServicio),
Constraint fk_DetalleOrden_idServicio foreign key (idServicio) references Servicio(idServicio))


/* Procedimiento para crear Tipo de Alimento & Bebida y Visualizarlo */
go
create procedure crearTipoAB(@nombre varchar(25))
as
begin
insert into TipoAB values(@nombre);
end

go
create procedure verTipoAB
as
begin
Select * from TipoAB
end
go

select* from TipoAB
/* Procedimiento para crear Tipo de Servicio y Visualizarlo */
go
create procedure crearTipoServicio(@idTipoAB int,@nombre varchar(25))
as
begin
insert into TipoServicio values(@idTipoAB,@nombre);
end
go


create procedure verTipoServicio
as
begin
Select tab.idTipo,tab.Nombre,ts.idTipoServicio,ts.Nombre from TipoServicio ts inner join
TipoAB tab on ts.idTipoAB = tab.idTipo
end



/* Procedimiento para crear Servicio y Visualizarlo */
go
create procedure crearServicio(@idTipoAB int,@idTipoServicio int,@nombre varchar(50),@descripcion text,@precio float,@tiempo int,@imagen text)
as
begin
insert into Servicio (idTipoAB,idTipoServicio,Nombre,descripcion,precio,tiempo,imagen)
 values(@idTipoAB,@idTipoServicio,@nombre,@descripcion,@precio,@tiempo,@imagen);
end

go
create procedure verServicio
as
begin
Select s.idServicio,tab.idTipo,tab.Nombre,ts.idTipoAB,tab.Nombre,s.Nombre,s.precio,s.tiempo,s.imagen from Servicio s inner join
TipoAB tab on s.idTipoAB = tab.idTipo inner join TipoServicio ts on ts.idTipoServicio = s.idTipoServicio
end


/* Procedimiento para crear Cliente y Visualizarlo */
go
create procedure crearMesa(@nombre varchar(50))
as
begin
insert into Mesa values(@nombre);
end

go
create procedure verMesa
as
begin
Select * from Mesa
end


/* Procedimiento para crear Orden y Visualizarlas */
go
create procedure crearOrden(@idMesa int,@descripcion text,@fecha time)
as
begin
insert into Orden (idMesa,Descripcion,Fecha) values(@idMesa,@descripcion,@fecha);
end



go
create procedure verOrden
as
begin
select o.idOrden,m.idMesa,m.Nombre,o.Descripcion,o.fecha from Orden o inner join
Mesa m on o.idMesa = m.idMesa
end

/* Procedimiento para crear Detalle de Orden y Visualizarlas */
go
create procedure crearDetalleOrden(@idOrden int,@idServicio int,@cantidad int)
as
begin
insert into Detalle_Orden values(@idOrden,@idServicio,@cantidad);
end

go
create procedure verDetalleOrden
as
begin
select do.idOrden,s.idServicio,s.Nombre,s.precio,do.cantidad,(do.cantidad * s.precio) as Total from
Detalle_Orden do inner join Servicio s on do.idServicio = s.idServicio
end


exec crearTipoAB 'Bebidas'
exec crearTipoServicio 1,'Vinos'
exec crearServicio 1,1,'Vino Tinto','Botella',750,10,'nada'
exec crearMesa 'Mesa 1'
exec crearOrden 1,'Freddy Soto','2017-06-20 09:34:00'
exec crearDetalleOrden 1,2,5
exec verTipoAB
exec verTipoServicio
exec verServicio
exec verMesa
exec verOrden
exec verDetalleOrden