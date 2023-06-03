from random import randint
from decimal import Decimal

some_number = randint(0,100)/100 + randint(1,100)
print(some_number)
some_number = int(Decimal(some_number - int(some_number)) * 10)
print(some_number)

