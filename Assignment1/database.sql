use dbenergy;


create table users(
id char(36) not null,
username varchar(45),
password varchar(45), 
type varchar(45),
nume varchar(45), 
address varchar(45), 
age int,
primary key(id)
);
create table devices(
id char(36) not null,
name varchar(45),
description varchar(45),
address varchar(45),
maxHConsumption varchar(45),
primary key(id)
);

create table userDevices(
idUser char(36) not null,
idDevice char(36) not null,
address varchar(45),
foreign key(idUser) references users(id),
foreign key(idDevice) references devices(id)
);



INSERT into users(id, username, password, type,nume, address, age)
values
(uuid(),'user','parola','admin','user1','str Trandafirilor',32);

