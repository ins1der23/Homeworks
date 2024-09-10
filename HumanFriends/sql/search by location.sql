USE oilproject;
SELECT 
clients.phone,
cities.name,
locations.name
FROM Clients
LEFT JOIN addresses ON addresses.id = Clients.addressId
LEFT JOIN locations ON addresses.locationId = locations.Id
LEFT JOIN cities ON addresses.cityId = cities.Id
WHERE locations.name LIKE 'ВТУЗ городок' OR locations.name LIKE 'Пионерский'
