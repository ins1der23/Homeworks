-- Создать новую таблицу для животных в возрасте от 1 до 3 лет и вычислить
-- их возраст с точностью до месяца.

USE HumanFriends;
DROP TABLE IF EXISTS YoungAnimals;
DROP FUNCTION IF EXISTS GetAge;

CREATE TABLE YoungAnimals AS
   SELECT 
		Pets.Id,
        Pets.KindId,
        Pets.`Name`,
        Pets.DOB,
        Pets.Vaccination,
        Pets.BreedId,
        NULL AS 'MaxLoad'
	FROM  Pets
	WHERE DOB BETWEEN DATE_SUB(NOW(), INTERVAL 3 YEAR) AND DATE_SUB(NOW(), INTERVAL 1 YEAR)
	UNION
    SELECT 
		PackAnimals.Id,
        PackAnimals.KindId,
        PackAnimals.`Name`,
        PackAnimals.DOB,
        PackAnimals.Vaccination,
        PackAnimals.BreedId,
        PackAnimals.MaxLoad AS 'MaxLoad'
	FROM  PackAnimals
	WHERE DOB BETWEEN DATE_SUB(NOW(), INTERVAL 3 YEAR) AND DATE_SUB(NOW(), INTERVAL 1 YEAR);
   
ALTER TABLE YoungAnimals
ADD FOREIGN KEY (Id) REFERENCES CommonId(Id) ON UPDATE CASCADE ON DELETE CASCADE,
ADD FOREIGN KEY (KindId) REFERENCES Kinds(Id) ON UPDATE CASCADE ON DELETE CASCADE,
ADD FOREIGN KEY (BreedId) REFERENCES Breeds(Id) ON UPDATE CASCADE ON DELETE CASCADE;

DELIMITER //
CREATE FUNCTION GetAge(DOB DATETIME)
RETURNS VARCHAR(50)
DETERMINISTIC
BEGIN
	DECLARE output VARCHAR(50);
	DECLARE temp INT;
	DECLARE months INT;
    DECLARE years INT;
    SET temp = timestampdiff(MONTH,DOB, NOW());
    SET years = temp DIV 12;
    SET months = temp - years*12;
    SET output = CONCAT(years,' г.', months, ' мес.');--  ',months,'мес';
	RETURN output;
END// 
DELIMITER ;

SELECT 
    YoungAnimals.Id,
    Kinds.Name AS 'Вид',
    YoungAnimals.Name,
    YoungAnimals.DOB,
    GetAge(DOB) AS 'Возраст', 
    IF (YoungAnimals.Vaccination = 0, 'Нет', 'Есть') AS 'Прививка'
    
FROM YoungAnimals
LEFT JOIN Kinds ON Kinds.Id = KindId ;
