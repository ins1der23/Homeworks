
def random_int(lower_bound: int, upper_bound: int):
    from random import randint
    some_number = randint(lower_bound, upper_bound)
    return int(some_number)
    '''Получение целого числа от lower_bound до upper_bound'''

res = ''
some_number = random_int(1,10)
print(some_number)
while some_number > 0:
    flag = some_number % 2 == 0
    some_number = some_number // 2
    if flag:
        res = f'0{res}'
    else:
        res = f'1{res}'

print(res)
