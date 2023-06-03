from random import randint


some_number = randint(0,1000)/1000 + randint(1,100) * randint(-1,2)
print(some_number, type(some_number))
some_number = str(abs(some_number))
some_number = some_number.replace('.','')
print(some_number, type(some_number))
sum = 0
for digit in some_number:
    sum += int(digit)
    print(sum)