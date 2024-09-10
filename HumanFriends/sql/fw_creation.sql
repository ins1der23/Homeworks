-- В ранее подключенном MySQL создать базу данных с названием "Human Friends".
-- Создать таблицы, соответствующие иерархии из вашей диаграммы классов.
-- Заполнить таблицы данными о животных, их командах и датами рождения.

DROP DATABASE IF EXISTS HumanFriends;
CREATE DATABASE HumanFriends;
USE HumanFriends;

CREATE TABLE CommonId(
Id SERIAL PRIMARY KEY
); 

CREATE TABLE Kinds(
Id SERIAL PRIMARY KEY,
`Name` VARCHAR(50) UNIQUE
);

INSERT INTO Kinds(Id, `Name`) VALUES
(1,'Собака'),
(2,'Кошка'),
(3,'Хомяк'),
(4,'Лошадь'),
(5,'Верблюд'),
(6,'Осел');


CREATE TABLE Breeds(
Id SERIAL PRIMARY KEY,
`Name` VARCHAR(50) UNIQUE
);

INSERT INTO Breeds(Id, `Name`) VALUES
(1,'Дог'),
(2,'Спаниэль'),
(3,'Такса'),
(4,'Вьетнамcкий дворовой'),
(5,'Шотландский вислоухий'),
(6,'Английский лупоглазый'),
(7,'Арабская'),
(8,'Донская'),
(9,'Пони');

CREATE TABLE Commands(
Id SERIAL PRIMARY KEY,
`Name` VARCHAR(50) UNIQUE
);

INSERT INTO Commands(Id, `Name`) VALUES
(1,'Сесть'),
(2,'Встать'),
(3,'Принести'),
(4,'Дать лапу'),
(5,'Издать звук'),
(6,'Атаковать'),
(7,'Поскрести'),
(8,'Свернуться'),
(9,'Спрятаться'),
(10, 'Шаг'),
(11, 'Рысь'),
(12, 'Галлоп'),
(13, 'Загрузить'),
(14, 'Идти'),
(15, 'Бежать'),
(16, 'Пнуть');

CREATE TABLE Features(
Id SERIAL PRIMARY KEY,
`Name` VARCHAR(50) UNIQUE
);

INSERT INTO Features(Id, `Name`) VALUES
(1,'Дворовая'),
(2,'Охотник на мышей'),
(3,'Бегает в колесе'),
(4,'Иноходец'),
(5,'Двугорбый'),
(6,'Боец');

CREATE TABLE AnimalsFeatures(
AnimalId BIGINT UNSIGNED NOT NULL,
FeatureId BIGINT UNSIGNED NOT NULL,
FOREIGN KEY (AnimalId) REFERENCES CommonId(Id) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (FeatureId) REFERENCES Features(id) ON UPDATE CASCADE ON DELETE CASCADE
);


CREATE TABLE AnimalsCommands(
AnimalId BIGINT UNSIGNED NOT NULL,
CommandId BIGINT UNSIGNED NOT NULL,
FOREIGN KEY (AnimalId) REFERENCES CommonId(Id) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (CommandId) REFERENCES Commands(id) ON UPDATE CASCADE ON DELETE CASCADE
);


CREATE TABLE Pets(
Id BIGINT UNSIGNED PRIMARY KEY UNIQUE NOT NULL,
KindId BIGINT UNSIGNED,
`Name` VARCHAR(50),
DOB DATE,
Vaccination BOOLEAN DEFAULT 0,
BreedId BIGINT UNSIGNED,
FOREIGN KEY (Id) REFERENCES CommonId(Id) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (KindId) REFERENCES Kinds(Id) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (BreedId) REFERENCES Breeds(Id) ON UPDATE CASCADE ON DELETE CASCADE);

INSERT INTO CommonId(Id) VALUES
(1),(2),(3),(4),(5),(6),(7),(8),(9);
INSERT INTO Pets (Id, KindId, `Name`,  DOB, BreedId) VALUES
(1, 1, 'Черныш', '2020-1-1', 1 ), 
(2, 1, 'Беляш', '2021-04-23', 2), 
(3, 1, 'Сосиска', '2022-03-25', 3),
(4,2, 'Чуи', '2018-04-06', 4), 
(5,2, 'Локи', '2021-07-15', 5), 
(6, 2,'Варька', '2017-03-22', 6),
(7, 3,'Смельчак', '2023-07-13', NULL), 
(8, 3,'Быстряк', '2022-09-26', NULL), 
(9, 3,'Сопун', '2024-02-14', NULL);
INSERT INTO AnimalsCommands(AnimalId,CommandId) VALUES
(1,1),(1,2),(1,4),
(2,1),(2,5),
(3,2),(3,3),
(4,7),(4,8),
(5,5),(5,8),
(6,8),
(7,8),(7,9),
(8,9),
(9,8);
INSERT INTO AnimalsFeatures(AnimalId,FeatureId) VALUES
(2,1),
(3,1),
(6,2),
(7,3),
(8,3);



CREATE TABLE PackAnimals(
Id BIGINT UNSIGNED PRIMARY KEY UNIQUE NOT NULL,
KindId BIGINT UNSIGNED,
`Name` VARCHAR(50),
DOB DATE,
Vaccination BOOLEAN DEFAULT 0,
BreedId BIGINT UNSIGNED,
MaxLoad INT,
FOREIGN KEY (Id) REFERENCES CommonId(Id) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (KindId) REFERENCES Kinds(Id) ON UPDATE CASCADE ON DELETE CASCADE,
FOREIGN KEY (BreedId) REFERENCES Breeds(Id) ON UPDATE CASCADE ON DELETE CASCADE
);

INSERT INTO CommonId(Id) VALUES
(10),(11),(12),(13),(14),(15),(16);
INSERT INTO PackAnimals (Id, KindId, `Name`,  DOB, MaxLoad, BreedId) VALUES
(10, 4, 'Бурка','2017-03-15',90,7), 
(11, 4, 'Верный','2014-11-03',95, 8), 
(12, 4, 'Апполон','2013-01-10',110, 9),
(13, 5, 'Кузя', '2016-02-07',145, NULL), 
(14, 5, 'Джонни', '2019-03-23',160, NULL),
(15, 6, 'Ванька', '2022-01-01', 70, NULL),
(16, 6, 'Фроська', '2017-12-31',95, NULL);
INSERT INTO AnimalsCommands(AnimalId,CommandId) VALUES
(10,10),(10,11),
(11,12),
(12,10),(12,12),
(13,13),(13,14),(13,15),
(14,13),(14,14),
(15,13),(15,14),(15,16),
(16,13),(16,14);
INSERT INTO AnimalsFeatures(AnimalId,FeatureId) VALUES
(11,4),
(14,5),
(15,6);

DELIMITER //
CREATE TRIGGER pack_animals_no_del_tr
BEFORE DELETE
   ON PackAnimals FOR EACH ROW
   BEGIN
         SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'DELETE CANCELLED';
END; //
DELIMITER ;

DELIMITER //
CREATE TRIGGER pets_no_del_tr
BEFORE DELETE
   ON Pets FOR EACH ROW
   BEGIN
         SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'DELETE CANCELLED';
END; //
DELIMITER ;



