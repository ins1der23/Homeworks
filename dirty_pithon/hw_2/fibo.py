
def fibo(fibo_num: int) -> list:
    fibo_list = [None] * (2 * fibo_num + 1)
    fibo_list[fibo_num] = 0
    m = 0
    n = 1
    fibo = 1
    for i in range(1, fibo_num + 1):
        fibo_list[fibo_num + i] = fibo
        fibo_list[fibo_num - i] = -fibo
        fibo = m + n
        m = n
        n = fibo
    return fibo_list
    ''' Получение ряда чисел Фибоначчи и НегаФибоначчи'''


print(result := fibo(8))
