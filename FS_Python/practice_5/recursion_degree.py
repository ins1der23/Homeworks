'''Функция получения случайного целого числа от lower_bound до upper_bound.'''
def random_int(lower_bound: int, upper_bound: int):
    from random import randint
    some_number = randint(lower_bound, upper_bound)
    return int(some_number)


'''Функция ввода с клавиатуры целого числа от lower_bound до upper_bound. Нижняя граница по умолчанию  = -1000,
 верхняя = 1000'''
def input_int(lower_bound: int = -1000, upper_bound: int = 1000):
    some_number = input(f"Введите число от {lower_bound} до {upper_bound} ")
    while not some_number.isdigit() or int(some_number) < lower_bound or int(some_number) > upper_bound:
        print("Все криво!")
        some_number = input(
            f"Введите число от {lower_bound} до {upper_bound}\n")
    return int(some_number)


'''Функция рекурсивного возведения в степень. В качестве аргeментов вручную можно ввести только 
основание (basis) и степень (degree), result вручную вводить не стоит.'''
def degree_recursive(basis: int, degree: int, result=1):
    if degree == 0:
        return result
    else:
        result *= basis
        degree -= 1
        return int(degree_recursive(basis, degree, result))


basis = random_int(1, 10)
print(f"Сейчас мы будем возводить число {basis} в степень\nНужно будет ввести степень руками")
degree = input_int(0, 998)
print(f"Результат вычисления = {degree_recursive(basis, degree)}")
