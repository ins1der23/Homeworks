-- Удалить записи о верблюдах и объединить таблицы лошадей и ослов.

USE HumanFriends;

SELECT * FROM CommonId
JOIN PackAnimals ON PackAnimals.Id = CommonId.Id
JOIN Kinds ON Kinds.Id = PackAnimals.KindId
WHERE  Kinds.`Name` LIKE 'Осел' OR Kinds.`Name` LIKE 'Лошадь';

DELETE 
CommonId
FROM CommonId
JOIN PackAnimals ON PackAnimals.Id = CommonId.Id
JOIN Kinds ON Kinds.Id = PackAnimals.KindId
WHERE Kinds.`Name` LIKE 'Верблюд';







