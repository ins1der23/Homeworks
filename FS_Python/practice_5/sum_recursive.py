'''Функция получения случайного целого числа от lower_bound до upper_bound.'''
def random_int(lower_bound: int, upper_bound: int):
    from random import randint
    some_number = randint(lower_bound, upper_bound)
    return int(some_number)

'''Функция рекурсивного сложения двух чисел'''
def sum_recursive(first_num:int, second_num:int):
    if second_num == 0:
        return first_num
    else:
        first_num += 1
        second_num -= 1
        return int(sum_recursive(first_num, second_num))


first_num = random_int(1, 10)
second_num = random_int(1, 10)
print(f"{first_num} + {second_num} = {sum_recursive(first_num, second_num)}")