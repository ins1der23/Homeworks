-- Объединить все созданные таблицы в одну, сохраняя информацию о
-- принадлежности к исходным таблицам.

SELECT 
'Pets' AS 'SourceTable',
Pets.Id AS Id,
Kinds.Name AS 'Вид',
Pets.Name AS 'Имя',
Pets.DOB AS 'Дата рождения',
IF (Pets.Vaccination = 0, 'Нет', 'Есть') AS 'Прививка',
IFNULL(Breeds.Name, 'Никакая') AS 'Порода',
'Непременимо' AS 'Загрузка',
IFNULL(Features.Name, 'Нет') AS 'Свойство',
GROUP_CONCAT(Commands.Name SEPARATOR ', ') AS 'Выученные команды'
FROM Pets 
LEFT JOIN Kinds ON Kinds.Id = Pets.KindId
LEFT JOIN Breeds ON Breeds.Id = Pets.BreedId
LEFT JOIN AnimalsFeatures ON AnimalsFeatures.AnimalId = Pets.Id
LEFT JOIN Features ON Features.Id  = AnimalsFeatures.FeatureId
LEFT JOIN AnimalsCommands ON AnimalsCommands.AnimalId = Pets.Id
LEFT JOIN Commands ON Commands.Id  = AnimalsCommands.CommandId
GROUP BY Pets.Id, Features.Name

UNION
SELECT 
'PackAnimals' AS 'SourceTable',
PackAnimals.Id AS Id,
Kinds.Name AS 'Вид',
PackAnimals.Name AS 'Имя',
PackAnimals.DOB AS 'Дата рождения',
IF (PackAnimals.Vaccination = 0, 'Нет', 'Есть') AS 'Прививка',
IFNULL(Breeds.Name, 'Никакая') AS 'Порода',
PackAnimals.MaxLoad AS 'Загрузка',
IFNULL(Features.Name, 'Нет') AS 'Свойство',
GROUP_CONCAT(Commands.Name SEPARATOR ', ') AS 'Выученные команды'
FROM PackAnimals 
LEFT JOIN Kinds ON Kinds.Id = PackAnimals.KindId
LEFT JOIN Breeds ON Breeds.Id = PackAnimals.BreedId
LEFT JOIN AnimalsFeatures ON AnimalsFeatures.AnimalId = PackAnimals.Id
LEFT JOIN Features ON Features.Id  = AnimalsFeatures.FeatureId
LEFT JOIN AnimalsCommands ON AnimalsCommands.AnimalId = PackAnimals.Id
LEFT JOIN Commands ON Commands.Id  = AnimalsCommands.CommandId
GROUP BY PackAnimals.Id, Features.Name

UNION
SELECT 
'YoungAnimals' AS 'SourceTable',
YoungAnimals.Id AS Id,
Kinds.Name AS 'Вид',
YoungAnimals.Name AS 'Имя',
YoungAnimals.DOB AS 'Дата рождения',
IF (YoungAnimals.Vaccination = 0, 'Нет', 'Есть') AS 'Прививка',
IFNULL(Breeds.Name, 'Никакая') AS 'Порода',
IFNULL(YoungAnimals.MaxLoad, 'Непременимо') AS 'Загрузка',
IFNULL(Features.Name, 'Нет') AS 'Свойство',
GROUP_CONCAT(Commands.Name SEPARATOR ', ') AS 'Выученные команды'
FROM YoungAnimals 
LEFT JOIN Kinds ON Kinds.Id = YoungAnimals.KindId
LEFT JOIN Breeds ON Breeds.Id = YoungAnimals.BreedId
LEFT JOIN AnimalsFeatures ON AnimalsFeatures.AnimalId = YoungAnimals.Id
LEFT JOIN Features ON Features.Id  = AnimalsFeatures.FeatureId
LEFT JOIN AnimalsCommands ON AnimalsCommands.AnimalId = YoungAnimals.Id
LEFT JOIN Commands ON Commands.Id  = AnimalsCommands.CommandId
GROUP BY YoungAnimals.Id, Kinds.Name, YoungAnimals.Name, YoungAnimals.DOB, YoungAnimals.Vaccination, Breeds.Name,YoungAnimals.MaxLoad, Features.Name
;








