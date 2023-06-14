def input_integer(lower_bound: int, upper_bound: int) -> int:
    some_number = input(f"Введите число от {lower_bound} до {upper_bound} ")
    while not some_number.isdigit() or (int(some_number) < lower_bound or int(some_number) > upper_bound):
        print("Все криво!")
        some_number = input(f"Введите число от {lower_bound} до {upper_bound} ")
    return int(some_number)


def progression_recursive(first: int, diff: int, count: int, result: list) -> list:
    if count == 0:
        return result
    else:
        result.insert(0, first + (count-1) * diff)
        count -= 1
        return progression_recursive(first, diff, count, result)


print("Введите первый элемент прогрессии: ")
first = input_integer(1, 10)
print("Введите разность прогрессии: ")
diff = input_integer(1, 5)
print("Введите количество элементов прогрессии: ")
count = input_integer(1, 100)
progression = []
print(progression := progression_recursive(first, diff, count, progression))
