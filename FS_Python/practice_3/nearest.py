from random import randint

size = int(input('Введите количество чисел '))
while size < 1:
    print('Количество чисел должно быть больше 0')
    size = int(input('Введите количество чисел'))
some_numbers = [randint(-10, 10) for i in range(size)]
print(some_numbers)
to_find = int(input('Введите число, чтобы найдем самое близкое к нему '))
min_diff = abs(some_numbers[0] - to_find)
nearest = 0
for i in range(1, size):
    curr_diff = abs(some_numbers[i] - to_find)
    if curr_diff < min_diff:
        curr_diff, min_diff = min_diff, curr_diff
        nearest = some_numbers[i]
print(f'Ближайшее число к заданному это {nearest}')
