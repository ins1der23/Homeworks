from msvcrt import getch
import keyboard

class Animal:
    def voice(self):
        pass


class Human:
    count_uid = 1

    def __init__(self, name, age, work) -> None:
        self.uid = Human.count_uid
        self.name = name
        self.age = age
        self.work = work
        Human.count_uid += 1

    def __str__(self) -> str:
        return f'{self.uid:<3} {self.name:<10} {self.age:<3} {self.work:<10}'

    def hello(self):
        return f'Человек {self.name} говорит ПРИВЕТ'

fields = ('', '', '')
print(len(fields))

print(fields[0])
print(fields[1])
print(fields[2])


def check_fields(fields: tuple) -> bool:
    flag = True
    for item in  fields:
        if (item != ''): 
            flag = True
            break
        else: flag = False
    return flag

print(check_fields(fields))

menu = ['Показать все контакты',
        'Создать новый контакт',
        'Найти контакт',
        'Изменить контакт',
        'Удалить контакт',
        'Сохранить изменения',
        'Выход']


enum_menu = (list(enumerate(menu, 1)))
print(enum_menu)
result = ''
for key, value in enum_menu:
    result += f"{key}. {value}\n"

print(result)


print("Нажмите ")
def readch():
    while True:
        ch = getch()
        if ch == b'\r': return True
        elif ch == b'\x1b': return False

print(readch())





