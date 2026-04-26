create database BDVitrinaCarros

go 

use BDVitrinaCarros

go

create table tbl_vehiculo
(
	int_id_vehiculo int primary key identity(1,1),
	modelo varchar(30) not null, 
	fecha date,
	precio float
)

go 

create table tbl_marca
(
	int_id_vehiculo int, 
	nombre varchar(30) not null,
	primary key(int_id_vehiculo, nombre)
)

go

alter table tbl_marca
add foreign key(int_id_vehiculo) references tbl_vehiculo(int_id_vehiculo)

select * from tbl_marca

insert into tbl_vehiculo values ('2000', '02/10/2019', 1000000)

select  int_id_vehiculo, modelo, year(fecha) as año, precio from tbl_vehiculo


select int_id_vehiculo, modelo from tbl_vehiculo 

insert into tbl_marca values (1, '2000')

select v.int_id_vehiculo as id_vehiculo, v.modelo as modelo,year(v.fecha) as fecha, v.precio as precio, m.nombre as marca
from tbl_vehiculo v inner join tbl_marca m
on m.int_id_vehiculo = v.int_id_vehiculo
order by m.nombre DESC

select v.int_id_vehiculo as id_vehiculo, v.modelo,year(v.fecha) as anio, v.precio as precio, m.nombre as marca
from tbl_vehiculo v inner join tbl_marca m
on m.int_id_vehiculo = v.int_id_vehiculo
where m.nombre = 'BMW'


