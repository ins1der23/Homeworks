from random import getrandbits
coins = int(input('Введите количество монет '))
eagles = 0
tails = 0
while coins < 2:
    print('На столе должны лежать хотя бы две монеты')
    coins = int(input('Введите количество монет '))
for i in range(coins):
    coin = getrandbits(1)
    print(coin, end=" ")
    if coin:
        eagles += 1
    else:
        tails += 1

print (f"\nНа столе лежат {eagles} 'орел', {tails} 'решка'")
if eagles <= tails:
    print (f'Нужно перевернуть {eagles} монет(ы)')
else:
    print(f'Нужно перевернуть {tails} монет')