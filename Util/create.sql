CREATE DATABASE IF NOT EXISTS db;
USE db;

CREATE TABLE ExerciseList (
	ID INT NOT NULL AUTO_INCREMENT,
    ExerciseMachineID INT NOT NULL,
    ExerciseDate INT,
    ExerciseTime INT,
    ExerciseLevel INT,
    ExerciseReps INT,
    ExerciseSets INT,
    ExerciseWeight INT,
    ExerciseNotes VARCHAR(100),
    ExercisePersonID INT,
    primary key (id)
);

CREATE TABLE userlist (
  ID int NOT NULL AUTO_INCREMENT,
  FirstName varchar(45) DEFAULT NULL,
  LastName varchar(45) DEFAULT NULL,
  Email varchar(45) DEFAULT NULL,
  Password varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
)

CREATE TABLE machinetypes (
  ID int NOT NULL AUTO_INCREMENT,
  Description varchar(45) DEFAULT NULL,
  MachineNumber int DEFAULT NULL,
  SeatPosition int DEFAULT NULL,
  LegArmPosition int DEFAULT NULL,
  UserID int DEFAULT NULL,
  PRIMARY KEY (`ID`)
)

