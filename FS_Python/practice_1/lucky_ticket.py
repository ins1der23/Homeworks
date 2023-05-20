ticket = int(input('Введите шесть цифр номера билета: '))
if ticket < 100000 or ticket > 999999:
    print('Вы ввели не шесть цифр')
else:
    six = ticket % 10
    five = ticket // 10 % 10
    four = ticket // 100 % 10
    three = ticket // 1000 % 10
    two = ticket // 10000 % 10
    one = ticket // 100000
    lucky = one+two+three == four+five+six
    if lucky:
        print('Ура!!! Билет счастливый')
    else:
        print('Не повезло. Попробуй купить еще один')    
