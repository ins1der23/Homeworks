from random import randint

first_size = input("Введите размер первого списка ")
while not first_size.isdigit() or int(first_size) < 0:
    print('Вы ввели неверные данные')
    first_size = input("Введите положительное число ")
second_size = input("Введите размер второго списка ")
while not second_size.isdigit() or int(second_size) < 0:
    print('Вы ввели неверные данные')
    first_size = input("Введите положительное число ")

first_list = [int(input('Введите число ')) for i in range(int(first_size))]
print(first_list)
second_list = [int(input('Введите число ')) for i in range(int(second_size))]
print(second_list)
result_set = set(first_list).union(set(second_list))
print (result_set)
