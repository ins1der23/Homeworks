from random import randint

size = int(input('Введите количество чисел '))
while size < 1:
    print('Количество чисел должно быть больше 0')
    size = int(input('Введите количество чисел'))
some_numbers = [randint(-5, 5) for i in range(size)]
print(some_numbers)
to_find = int(input('Введите искомое число '))
counter = 0
for i in some_numbers:
    if i == to_find:
        counter += 1
print(f'Число {to_find} встречается {counter} раз')