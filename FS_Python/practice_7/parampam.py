def get_string() -> str:
    some_string = input('Давайте проверим. Пишите стихотворение\n')
    while some_string.isdigit():
        some_string = input('Пишите стихотворение\n')
    return some_string
    ''' Получение с клавиатуры всех символов кроме цифр'''


def find_rhythm(any_string: str) -> bool:
    vowels = 'уеыаоэяию'
    vowel_count = list(map(lambda x: sum(x.count(vowel) for vowel in vowels), any_string.lower().split()))
    return  vowel_count.count(vowel_count[0]) == len(vowel_count)
    '''Проверка слов в строке на одинаковое количество гласных'''


some_string = get_string()
print ('Парам пам-пам') if find_rhythm(some_string) else print('Пам парам')

