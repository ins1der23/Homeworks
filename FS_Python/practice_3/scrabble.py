letters_dict = [
    {"letters": "AEIOULNSTR", "points": 1},
    {"letters": "DG", "points": 2},
    {"letters": "BCMP", "points": 3},
    {"letters": "FHVWY", "points": 4},
    {"letters": "K", "points": 5},
    {"letters": "JX", "points": 8},
    {"letters": "QZ", "points": 10},

    {"letters": "АВЕИНОРСТ", "points": 1},
    {"letters": "ДКЛМПУ", "points": 2},
    {"letters": "БГЁЬЯ", "points": 3},
    {"letters": "ЙЫ", "points": 4},
    {"letters": "ЖЗХЦЧ", "points": 5},
    {"letters": "ШЭЮ", "points": 8},
    {"letters": "ФЩЪ", "points": 10}
]
points = 0
some_word = input('Введите слово:\n').upper()
for char in some_word:
    for i in range(len(letters_dict)):
        if char in letters_dict[i]["letters"]:
            points += letters_dict[i]["points"]
print(f'У вас {points} очков!')
