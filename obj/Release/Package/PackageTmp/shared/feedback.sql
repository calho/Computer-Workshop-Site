DROP DATABASE IF EXISTS TMA3P3_Feedback;

CREATE DATABASE TMA3P3_Feedback;

USE TMA3P3_Feedback;

DROP table if exists feedback;

CREATE TABLE if not exists feedback
(
   ID int NOT NULL AUTO_INCREMENT PRIMARY KEY,
   date varchar(50),
   name varchar(50),
   fb varchar(50)
);


