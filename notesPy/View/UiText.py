
# Текст для интерфефейса
class UiText:

    def __init__(self):

        self.__commands = [
            "GETALL - показать все заметки",
            "SEARCH text - отобрать заметки, содержащие текст",
            "FILTER dd-mm-yyyy - отобрать заметки, содержащие текст",
            "ADD header - добавить заметку c указанным заголовком",
            "CHOOSE id - показать заметку по id",
            "CHANGE id  - изменить заметку по id",
            "DELETE id - удалить заметку по id",
            "EXIT - выход из программы",
        ]

        self.__nofile = "Отстутсвует файл с заметками"
        self.__input_command = "Введите команду: "
        self.__search_string = "Поиск заметки"
        self.__input_string = "Введите текст: "
        self.__input_noteheader = "Заголовок заметки"
        self.__input_notetext = "Текст заметки"
        self.__note_not_found = "Заметка не найдена"
        self.__nothing_found = "Ничего не найдено"
        self.__no_notes = "Нет заметок"

    @property
    def commands(self):
        return self.__commands
    @property
    def nofile(self):
        return self.__nofile
    @property
    def input_command(self):
        return self.__input_command
    @property
    def search_string(self):
        return self.__search_string
    @property
    def input_string(self):
        return self.__input_string
    @property
    def input_noteheader(self):
        return self.__input_noteheader
    @property
    def input_notetext(self):
        return self.__input_notetext
    @property
    def note_not_found(self):
        return self.__note_not_found
    @property
    def nothing_found(self):
        return self.__nothing_found
    @property
    def no_notes(self):
        return self.__no_notes