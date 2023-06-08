def random_int_list(size: int, lower_bound: int, upper_bound: int, ) -> list:
    from random import randint
    return [randint(lower_bound, upper_bound) for i in range(size)]
    '''Создание списка случайных int от lower_bound до upper_bound размером size '''


print(some_list := random_int_list(20, -5, 5))
print (unique := list(set(some_list)))
