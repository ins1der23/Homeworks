from string import punctuation


some_sentence = 'te, net,'


def palindrome_check(some_string: str) -> bool:
    from string import punctuation
    some_string = some_string.replace(' ', '')
    for sym in punctuation:
        some_string = some_string.replace(sym, '')
    print(some_string)
    reverted = some_string[::-1]
    print(reverted)
    return some_string == some_string[::-1]

print(palindrome_check(some_sentence))