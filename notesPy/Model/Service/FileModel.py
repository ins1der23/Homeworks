import datetime
from Model.Note import Note
from Model.Service.Notes import Notes

# класс для работы с файлом заметок, наследуется от Notes
class FileModel(Notes):

    def __init__(self, path: str):
        super().__init__()
        self.path = path
        self.empty_file_err = UnboundLocalError("File is empty")


# получить все заметки из файла
    def get_all(self) -> list[Note]:
        if self.__open_file():
            return self.notelist
        else:
            return None

# открыть файл
    def __open_file(self) -> bool:
        try:
            with open(self.path, "r", encoding="UTF-8") as file:
                data = file.readlines()
                for line in data:
                    _, header, body, changetime, *_ = line.strip().split(";")
                    changetime = datetime.datetime.strptime(changetime, '%Y-%m-%d %H:%M:%S.%f')
                    self.notelist.append(Note(header, body, changetime))
            return True
        except UnboundLocalError:
            print(self.empty_file_err)
        except IOError as error:
            print(error)
        return False


# сохранить в файл
    def save_list(self):
        data = ""
        for note in self.notelist:
            data += f"{note.id};{note.header};{note.body};{note.changetime}\n"
        try:
            with open(self.path, "w", encoding="UTF-8") as file:
                file.write(data)
        except IOError as error:
            print(error)

   