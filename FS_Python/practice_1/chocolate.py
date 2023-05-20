rows = int(input('Высота шоколадки = '))
columns = int(input('Ширина шоколадки = '))
print('Сколько нужно отломить?')
blocks = int(input())
if blocks % rows == 0 or blocks % columns == 0:
    print('Можно отломить за один раз')
else:
    print('За один раз отломить не получится')
