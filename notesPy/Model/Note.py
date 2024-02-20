import datetime

# класс для заметки
class Note:

    # общий стчетчик для id заметок
    count_id = 1

    def __init__(self, header: str, body: str, changetime: datetime):
        self.__id = Note.count_id
        self.__header = header
        self.__body = body
        self.__changetime = changetime
        Note.count_id += 1

    @property
    def id(self):
        return self.__id
    
    @property
    def header(self):
        return self.__header
    
    @property
    def body(self):
        return self.__body
    
    @property
    def changetime(self):
        return self.__changetime

    def __str__(self) -> str:
        return f"{self.__id};{self.__header};{self.__body};{self.__changetime}"

    def change(self, header: str, body: str):
        self.__header = header
        self.__body = body
        self.__changetime = datetime.datetime.now()
