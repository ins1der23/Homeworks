def random_cell() -> str:
    from random import randint
    letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H']
    return letters[randint(0, 7)] + str(randint(1, 8))


chess_cage = random_cell().lower()
print(chess_cage)
sum = 0
chess_letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h']
for i in range(len(chess_cage)):
    if chess_cage[i] in chess_letters:
        sum += chess_letters.index(chess_cage[i])
    else:
        sum += int(chess_cage[i])
result = sum % 2 == 0
if result: print("White")
else: print ("Black")