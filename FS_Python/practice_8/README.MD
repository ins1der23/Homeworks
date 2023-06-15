Добавил сохранение файла и удаление контакта

Добавил метод input_return_int для ввода int id, чтобы программа не вылетала при вводе нверных данных.

Добавил метод reassign_id для переназначения id после удаления,  а также присвоения id str значения после добавления нового контакта.  Так как после добавления контакта при попытке поиска элемента по значению программа вылетала с такой ошибкой:

"File "c:\repo\homeworks\FS_Python\practice_8\model.py", line 34, in search
    if word.lower() in value.lower():
                       ^^^^^^^^^^^
AttributeError: 'int' object has no attribute 'lower'"
