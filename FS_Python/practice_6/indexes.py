
def random_int(lower_bound: int, upper_bound: int):
    from random import randint
    some_number = randint(lower_bound, upper_bound)
    return int(some_number)
    '''Функция получения случайного целого числа от lower_bound до upper_bound.'''

def random_int_list(size: int, lower_bound: int, upper_bound: int, ) -> list:
    from random import randint
    return [randint(lower_bound, upper_bound) for i in range(size)]
    '''Создание списка случайных int от lower_bound до upper_bound размером size '''

def find_indexes(lower: int, upper: int, some_list: list) -> list:
    result = []
    for i in range(len(some_list)):
            if lower < some_list[i] < upper:
                 result.append(i)
    return result
    '''Поиск индексов чисел в дипазоне от lower до upper '''

lower = random_int(0, 10)
upper = random_int(0, 10)
if upper < lower:
    lower, upper = upper, lower
print(f"Зададим диапазон значений от {lower} до {upper}")
some_list = random_int_list(20, 0, 20)
print(some_list)
result = find_indexes(lower, upper, some_list)
           
print(result)
