from Model.Service.FileModel import FileModel
from View.ConsoleView import ConsoleView


class Controller:

    def __init__(self, model: FileModel, view: ConsoleView):
        self.model = model
        self.view = view

    def run(self):
        self.view.clear_console()
        notes = self.model.get_all()
        if notes == None:
            self.view.show_string(self.view.ui_text.nofile)
            return
        flag = True
        while flag:
            self.view.show_list(self.view.ui_text.commands)
            command = self.view.get_command()
            print(command)
            if command.imperative != "":
                match command.imperative:
                    case "GETALL":
                        self.view.clear_console()
                        self.view.show_list(notes, self.view.ui_text.no_notes)
                    case "SEARCH":
                        self.view.clear_console()
                        result = self.model.search(command.attribute)
                        self.view.show_list(result, self.view.ui_text.nothing_found)
                    case "FILTER":
                        self.view.clear_console()
                        result = self.model.filter(command.attribute)
                        self.view.show_list(result, self.view.ui_text.nothing_found)
                    case "ADD":
                        self.view.clear_console()
                        self.view.show_string(self.view.ui_text.input_notetext)
                        body = self.view.get_string()
                        self.model.add(command.attribute, body)
                        self.model.save_list()
                    case "CHOOSE":
                        self.view.clear_console()
                        note = self.model.get_by_id(command.attribute)
                        if note == None:
                            print(self.view.ui_text.note_not_found)
                        else:
                            print(note)
                    case "CHANGE":
                        self.view.clear_console()
                        note = self.model.get_by_id(command.attribute)
                        if note == None:
                            print(self.view.ui_text.note_not_found)
                        else:
                            self.view.show_string(self.view.ui_text.input_noteheader)
                            header = self.view.get_string()
                            self.view.show_string(self.view.ui_text.input_notetext)
                            body = self.view.get_string()
                            note.change(header, body)
                            self.model.change(note)
                            self.model.save_list()
                    case "DELETE":
                        self.view.clear_console()
                        note = self.model.get_by_id(command.attribute)
                        if note == None:
                            print(self.view.ui_text.note_not_found)
                        else:
                            self.model.delete(note)
                            self.model.save_list()
                    case "EXIT":
                        flag = False
