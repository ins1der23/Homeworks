from View.Command import Command
from View.UiText import UiText

# Класс для консольного интерфейса
class ConsoleView:

    def __init__(self):
        self.__ui_text = UiText()
        self.__input_string = ""
        self.__command = Command()

    @property
    def ui_text(self):
        return self.__ui_text

    def __set_input_string(self, message: str):
        self.__input_string = input(message)

    def get_string(self) -> str:
        self.__input_string = input(self.__ui_text.input_string)
        return self.__input_string

    def get_command(self) -> Command:
        self.__set_input_string(self.__ui_text.input_command)
        try:
            self.__command.parse_command(self.__input_string)
        except Exception as ex:
            print(ex)
        return self.__command

    def clear_console(self):
        print("\033c", end="")

    def show_list(self, somelist: list, message: str = ""):
        if len(somelist) != 0:
            print("\n" + "-" * 67)
            for note in somelist:
                print(note)
            print("-" * 67)
        else:
            print(message)

    def show_string(self, message: str):
        length = len(message)
        print("\n" + "-" * length)
        print(message)
        print("-" * length + "\n")
