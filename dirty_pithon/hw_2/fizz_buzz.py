def random_int(lower_bound: int, upper_bound: int):
    from random import randint
    some_number = randint(lower_bound, upper_bound)
    return int(some_number)
    '''Функция получения случайного целого числа от lower_bound до upper_bound.'''


some_number = random_int(1, 99)
print(some_number)
fizz_list = []
for i in range(1, some_number+1):
    if i % 5 == 0 and i % 3 == 0:
        fizz_list.append("FizzBuzz")
    elif i % 5 == 0:
        fizz_list.append("Buzz")
    elif i % 3 == 0:
        fizz_list.append("Fizz")
    else: fizz_list.append(i)
print (fizz_list)


