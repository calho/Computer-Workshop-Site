DROP DATABASE IF EXISTS TMA3P4_users;

CREATE DATABASE TMA3P4_users;

USE TMA3P4_users;

DROP table if exists TMA3_users;

CREATE TABLE if not exists TMA3_users
(
   ID int NOT NULL AUTO_INCREMENT PRIMARY KEY,
   username varchar(50),
   password varchar(50),
   question varchar(254),
   answer varchar(254)
);

insert into TMA3_users (username, password, question, answer) values ('admin','admin','question','answer');

DROP table if exists TMA3_components;

CREATE TABLE if not exists TMA3_components
(
   ID int NOT NULL AUTO_INCREMENT PRIMARY KEY,
   item varchar(50),
   price float,
   type varchar(50)
);

insert into TMA3_components (item, price, type) values ('HB basic', 1, 'COMP');
insert into TMA3_components (item, price, type) values ('Orange 21-iMac', 2, 'COMP');
insert into TMA3_components (item, price, type) values ('Orange 27-iMac', 3, 'COMP');
insert into TMA3_components (item, price, type) values ('Dhell 3000', 4, 'COMP');
insert into TMA3_components (item, price, type) values ('ROG gamer', 5, 'COMP');
insert into TMA3_components (item, price, type) values ('Microhard surface', 6, 'COMP');

insert into TMA3_components (item, price, type) values ('4 GB', 75, 'RAM');
insert into TMA3_components (item, price, type) values ('8 GB', 100, 'RAM');
insert into TMA3_components (item, price, type) values ('16 GB', 150, 'RAM');
insert into TMA3_components (item, price, type) values ('32 GB', 200, 'RAM');

insert into TMA3_components (item, price, type) values ('256 GB SSD', 75, 'HD');
insert into TMA3_components (item, price, type) values ('512 GB SSD', 100, 'HD');
insert into TMA3_components (item, price, type) values ('512 GB HDD', 50, 'HD');
insert into TMA3_components (item, price, type) values ('1 TB HDD', 115, 'HD');
insert into TMA3_components (item, price, type) values ('256 GB SSD 256 GB HDD', 125, 'HD');

insert into TMA3_components (item, price, type) values ('i3 7100', 150, 'CPU');
insert into TMA3_components (item, price, type) values ('i5 7500', 200, 'CPU');
insert into TMA3_components (item, price, type) values ('i5 7600K', 250, 'CPU');
insert into TMA3_components (item, price, type) values ('i7 7700', 300, 'CPU');
insert into TMA3_components (item, price, type) values ('i7 7700K', 350, 'CPU');

insert into TMA3_components (item, price, type) values ('21-inch', 150, 'D');
insert into TMA3_components (item, price, type) values ('24-inch', 200, 'D');
insert into TMA3_components (item, price, type) values ('27-inch', 300, 'D');
insert into TMA3_components (item, price, type) values ('32-inch', 500, 'D');
insert into TMA3_components (item, price, type) values ('27-inch gamers', 750, 'D');
insert into TMA3_components (item, price, type) values ('32-inch gamers', 1300, 'D');

insert into TMA3_components (item, price, type) values ('Windows 10', 200, 'OS');
insert into TMA3_components (item, price, type) values ('Mac OS', 250, 'OS');
insert into TMA3_components (item, price, type) values ('Linux', 0, 'OS');

insert into TMA3_components (item, price, type) values ('PCIe 7.1', 100, 'SC');
insert into TMA3_components (item, price, type) values ('PCIe 5.1', 50, 'SC');
insert into TMA3_components (item, price, type) values ('Blaster PCIe', 200, 'SC');


DROP table if exists TMA3_default;

CREATE TABLE if not exists TMA3_default
(
   ID int NOT NULL AUTO_INCREMENT PRIMARY KEY,
   itemID int,
   RAM int,
   HD int,
   CPU int,
   D int,
   OS int,
   SC int,
   foreign key (itemID) references TMA3_components(id)
);

insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (1,7,13,16,21,27,31); 
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (2,8,14,17,21,28,30); 
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (3,8,14,19,23,28,30);
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (4,9,12,19,24,27,30);
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (5,10,15,20,25,27,32);
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (6,9,15,19,24,27,30); 


DROP table if exists TMA3_orders;

CREATE TABLE if not exists TMA3_orders
(
   ID int NOT NULL AUTO_INCREMENT PRIMARY KEY,
   UID int,
   COMP int,
   RAM int,
   HD int,
   CPU int,
   D int,
   OS int,
   SC int,
   foreign key (UID) references TMA3_users(id)
);


