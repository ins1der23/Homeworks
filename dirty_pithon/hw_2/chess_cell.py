def random_cell() -> str:
    from random import randint
    letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H']
    return letters[randint(0, 7)] + str(randint(1, 8))
    ''' Функция получения случайной клетки шахматной доски'''

def cage_color(cage_coord: str) -> bool:
    sum = 0
    chess_letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h']
    for i in range(len(chess_cage)):
        if chess_cage[i] in chess_letters:
            sum += chess_letters.index(chess_cage[i])
        else:
            sum += int(chess_cage[i])
    return sum % 2 == 0
    '''Функция определения цвета клетки шахматной доски'''


print(chess_cage := random_cell().lower())
print("White" if cage_color(chess_cage) else "Black")
