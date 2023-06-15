from typing import Callable

def print_operation_table(operation: Callable, num_rows: int = 6, num_columns: int = 6) -> None:
    table = [[f'{operation(x,y)} ' for x in range(1, num_columns+1)]
           for y in range(1, num_rows+1)]
    res = ''
    for line in table:
        res+= ''.join(line)+'\n'
    print(res)
    return None
    '''Функции вычисление и печати значений таблицы по заданному lambda выражению, 
    принимающая в качестве аргументов номер строки и столбца'''

print_operation_table(lambda x, y: x * y, 5,6)