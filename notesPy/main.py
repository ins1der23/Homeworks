from Controller import Controller
from Model.Service.FileModel import FileModel
from View.ConsoleView import ConsoleView

view = ConsoleView()
model = FileModel("notes.csv")
controller = Controller(model, view)
controller.run()



