some_number = int(input('Введите трехзначное число, посчитаем сумму цифр: '))
if some_number < 100 or some_number > 999:
    print('Вы ввели не трехзначное число')
else:
    first = some_number // 100
    second = some_number // 10 % 10
    third = some_number % 10
    sum = first + second + third
    print(f'Сумма цифр числа {sum}')