import math

mult = int(input('Введите произведение чисел '))
sum = int(input('Введите сумму чисел '))
flag = mult < 0  or sum < 0
while flag:
    print('Сумма и произведение должны быть положительными числами')
    mult = int(input('Введите произведение чисел '))
    sum = int(input('Введите сумму чисел '))
    flag = mult < 0  or sum < 0
to_root = ((sum/2)**2 - mult)
if to_root >= 0:
    diff = math.sqrt(to_root)
    flag = diff - int(diff) == 0 or diff - int(diff) == 0.5
    if flag:
        first = int(sum/2 - diff)
        second = int(sum/2 + diff)
        print(f'Первое число = {first} \nВторое число = {second}')
    else: print("Задача не имеет решения в натуральных числах")
else:
   print('Задача не имеет решения')

