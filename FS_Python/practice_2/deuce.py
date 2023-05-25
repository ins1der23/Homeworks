some_number = int(input('Введите какое-то число '))
if some_number >= 1:
    n = 1
    while n <= some_number:
        print(n, end = " ")
        n *= 2
else:
    print('Нечего тут показывать')