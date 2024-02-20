import datetime

# класс для комманды UI, команда состоит из императива и атрибута
class Command:
    commands = ["GETALL", "SEARCH", "FILTER", "ADD", "CHOOSE", "CHANGE", "DELETE", "EXIT"]

    def __init__(self) -> None:
        self.__imperative = "" 
        self.__attribute = ""
        self.__command_exception = Exception("Wrong command")

    @property
    def imperative(self):
        return self.__imperative

    @property
    def attribute(self):
        return self.__attribute

# парсинг команды из ввденной строки
    def parse_command(self, input_string: str):
        i = 0
        command_str = ""
        while i < len(input_string):
            if input_string[i].isalpha():
                command_str += input_string[i].capitalize()
                i += 1
            else:
                break
        attribute = input_string[i + 1 :]
        if self.__set_command(command_str, attribute):
            pass
        else:
            raise self.__command_exception
        
# сеттер комманды
    def __set_command(self, command, attribute) -> bool:
        if command in self.commands:
            if command == "CHOOSE" or command == "CHANGE" or command == "DELETE":
                try:
                    self.__attribute = int(attribute)
                    self.__imperative = command
                    return True
                except ValueError:
                    pass
            elif command == "FILTER":
                try:
                    self.__attribute = datetime.datetime.strptime(attribute, '%d-%m-%Y')
                    self.__imperative = command
                    return True
                except Exception:
                    pass
            else:
                self.__imperative = command
                self.__attribute = attribute
                return True
        return False

    def __str__(self) -> str:
        return f"{self.__imperative} {self.__attribute}"
