DROP table if exists TMA3_default;
DROP table if exists TMA3_orders;
DROP table if exists TMA3_reviews;

DROP table if exists TMA3_users;

if not exists (select * from sysobjects where name='TMA3_users' and xtype='U')
    create table TMA3_users (
        ID int NOT NULL identity(1,1) PRIMARY KEY,
        username varchar(50),
        password varchar(50),
        question varchar(254),
        answer varchar(254)
    );

insert into TMA3_users (username, password, question, answer) values ('admin','admin','question','answer');

DROP table if exists TMA3_components;

if not exists (select * from sysobjects where name='TMA3_components' and xtype='U')
    create table TMA3_components (
        ID int NOT NULL identity(1,1) PRIMARY KEY,
        item varchar(50),
        price float,
        type varchar(50),
        description varchar(144),
        url varchar(144)
    );

insert into TMA3_components (item, price, type, description, url) values ('HB basic', 1, 'COMP', '', '');
insert into TMA3_components (item, price, type, description, url) values ('Orange 21-iMac', 2, 'COMP', '', '');
insert into TMA3_components (item, price, type, description, url) values ('Orange 27-iMac', 3, 'COMP', '', '');
insert into TMA3_components (item, price, type, description, url) values ('Dhell 3000', 4, 'COMP', '', '');
insert into TMA3_components (item, price, type, description, url) values ('ROG gamer', 5, 'COMP', '', '');
insert into TMA3_components (item, price, type, description, url) values ('Microhard surface', 6, 'COMP', '', '');

insert into TMA3_components (item, price, type, description, url) values ('4 GB RAM', 75, 'RAM', 'Single stick of 4 GB RAM', '../../shared/RAM.jfif');
insert into TMA3_components (item, price, type, description, url) values ('8 GB RAM', 100, 'RAM', 'Single stick of 8 GB RAM', '../../shared/RAM.jfif');
insert into TMA3_components (item, price, type, description, url) values ('16 GB RAM', 150, 'RAM', 'Single stick of 16 GB RAM', '../../shared/RAM.jfif');
insert into TMA3_components (item, price, type, description, url) values ('32 GB RAM', 200, 'RAM', 'Single stick of 32 GB RAM', '../../shared/RAM.jfif');

insert into TMA3_components (item, price, type, description, url) values ('256 GB SSD', 75, 'HD', '256 GB SSD hard drive', '../../shared/HD.jfif');
insert into TMA3_components (item, price, type, description, url) values ('512 GB SSD', 100, 'HD', '512 GB SSD hard drive', '../../shared/HD.jfif');
insert into TMA3_components (item, price, type, description, url) values ('512 GB HDD', 50, 'HD', '512 GB HDD hard drive', '../../shared/HD.jfif');
insert into TMA3_components (item, price, type, description, url) values ('1 TB HDD', 115, 'HD', '1 TB HDD hard drive', '../../shared/HD.jfif');
insert into TMA3_components (item, price, type, description, url) values ('256 GB SSD 256 GB HDD', 125, 'HD', '256 GB SSD 256 GB HDD hard drive', '../../shared/HD.jfif');

insert into TMA3_components (item, price, type, description, url) values ('i3 7100', 150, 'CPU', 'i3 7100 CPU', '../../shared/CPU.jfif');
insert into TMA3_components (item, price, type, description, url) values ('i5 7500', 200, 'CPU', 'i5 7500 CPU', '../../shared/CPU.jfif');
insert into TMA3_components (item, price, type, description, url) values ('i5 7600K', 250, 'CPU', 'i5 7600K CPU', '../../shared/CPU.jfif');
insert into TMA3_components (item, price, type, description, url) values ('i7 7700', 300, 'CPU', 'i7 7700 CPU', '../../shared/CPU.jfif');
insert into TMA3_components (item, price, type, description, url) values ('i7 7700K', 350, 'CPU', 'i7 7700K CPU', '../../shared/CPU.jfif');

insert into TMA3_components (item, price, type, description, url) values ('21-inch', 150, 'D', '21 - inch monitor display', '../../shared/Display.jfif');
insert into TMA3_components (item, price, type, description, url) values ('24-inch', 200, 'D', '24 - inch monitor display', '../../shared/Display.jfif');
insert into TMA3_components (item, price, type, description, url) values ('27-inch', 300, 'D', '27 - inch monitor display', '../../shared/Display.jfif');
insert into TMA3_components (item, price, type, description, url) values ('32-inch', 500, 'D', '32 - inch monitor display', '../../shared/Display.jfif');
insert into TMA3_components (item, price, type, description, url) values ('27-inch gamers', 750, 'D', '27 - inch gamers monitor display', '../../shared/Display.jfif');
insert into TMA3_components (item, price, type, description, url) values ('32-inch gamers', 1300, 'D', '32 - inch gamers monitor display', '../../shared/Display.jfif');

insert into TMA3_components (item, price, type, description, url) values ('Windows 10', 200, 'OS', 'Windows OS', '../../shared/Windows.png');
insert into TMA3_components (item, price, type, description, url) values ('Mac OS', 250, 'OS', 'Mac OS', '../../shared/Apple.jfif');
insert into TMA3_components (item, price, type, description, url) values ('Linux', 0, 'OS', 'Linux OS', '../../shared/Linux.jfif');

insert into TMA3_components (item, price, type, description, url) values ('PCIe 7.1', 100, 'SC', 'PCIe 7.1 sound card', '../../shared/SC.jfif');
insert into TMA3_components (item, price, type, description, url) values ('PCIe 5.1', 50, 'SC', 'PCIe 5.1 sound card', '../../shared/SC.jfif');
insert into TMA3_components (item, price, type, description, url) values ('Blaster PCIe', 200, 'SC', 'Blaster PCIe sound card', '../../shared/SC.jfif');



if not exists (select * from sysobjects where name='TMA3_default' and xtype='U')
    create table TMA3_default (
        ID int NOT NULL identity(1,1) PRIMARY KEY,
        itemID int,
        RAM int,
        HD int,
        CPU int,
        D int,
        OS int,
        SC int,
        foreign key (itemID) references TMA3_components(id)
    )

insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (1,7,13,16,21,27,31); 
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (2,8,14,17,21,28,30); 
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (3,8,14,19,23,28,30);
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (4,9,12,19,24,27,30);
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (5,10,15,20,25,27,32);
insert into TMA3_default (itemID,RAM,HD,CPU,D,OS,SC) values (6,9,15,19,24,27,30); 



if not exists (select * from sysobjects where name='TMA3_orders' and xtype='U')
    create table TMA3_orders (
        ID int NOT NULL identity(1,1) PRIMARY KEY,
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

if not exists (select * from sysobjects where name='TMA3_reviewss' and xtype='U')
    create table TMA3_reviews (
        ID int NOT NULL identity(1,1) PRIMARY KEY,
        item varchar(50),
   		date varchar(50),
   		name varchar(50),
   		review varchar(50),
   		score float
    );
