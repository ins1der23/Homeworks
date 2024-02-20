import datetime
from Model.Note import Note

# класс для работы с заметками
class Notes:

    def __init__(self):
        self._notelist = []
        self.is_empty

    @property
    def notelist(self):
        return self._notelist

    @property
    def is_empty(self):
        if len(self.notelist) == 0:
            return True
        else:
            return False



# получить заметк по id
    def get_by_id(self, id) -> Note:
        if self.is_empty:
            return None
        else:
            for note in self._notelist:
                if id == note.id:
                    return note

# добавить заметку
    def add(self, header: str, body: str):
        changetime = datetime.datetime.now()
        self._notelist.append(Note(header, body, changetime))

# изменить заметку
    def change(self, note: Note):
        for line in self._notelist:
            if line.id == note.id:
                self._notelist.remove(line)
                self._notelist.append(note)

# удалить заметку
    def delete(self, note: Note):
        self._notelist.remove(note)

# поиск заметок по тексту
    def search(self, word: str) -> list[Note]:
        output = []
        for note in self._notelist:
            if word.lower() in note.__str__():
                output.append(note)
        return output
    
# фильтрация заметок по дате
    def filter(self, changetime : datetime) -> list[Note]:
        output = []
        for note in self._notelist:
            if note.changetime >= changetime:
                output.append(note)
        return output
