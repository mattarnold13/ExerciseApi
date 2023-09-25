CREATE DATABASE IF NOT EXISTS db;
USE db;

CREATE TABLE ExerciseList (
	ID INT NOT NULL AUTO_INCREMENT,
    ExerciseType char(25) NOT NULL,
    ExerciseDate DATE,
    ExerciseTime NUMERIC(4,0),
    ExerciseLevel NUMERIC(4,0),
    ExerciseReps NUMERIC(2,0),
    ExerciseSets NUMERIC(2,0),
    ExerciseWeight NUMERIC (3,0),
    ExerciseNotes VARCHAR(100),
    ExercisePerson Numeric(3,0),
    primary key (id)
);