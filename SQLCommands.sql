CREATE DATABASE BookingImage;

USE BookingImage;


CREATE TABLE Image
(
  ImageBase varchar(max) NOT NULL,
  RoomId int NOT NULL,
  Id INT IDENTITY(1,1) PRIMARY KEY,
)