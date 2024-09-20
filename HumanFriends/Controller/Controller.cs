using HumanFriends.Controller;
using HumanFriends.Model;
using HumanFriends.View;

class Controller
{
    private IView view = new ConsoleView();
    private IModel model = new FileModel();
    void Run()
    {
        CtrlCommands command = view.MainMenu();
        switch (command)
        {
            case CtrlCommands.Get:
                List<IBaseAnimal> animals = model.GetAnimals();
                command = view.ListMenu(animals, out IBaseAnimal baseAnimal);
                IBaseAnimal animal = baseAnimal;
                switch (command)
                {
                    case CtrlCommands.Add:
                        model.AddAnimal(animal);
                        break;
                    case CtrlCommands.Delete:
                        model.DelAnimal(animal);
                        break;
                    case CtrlCommands.Change:
                        model.ChangeAnimal(animal);
                        break;
                    case CtrlCommands.Exit:
                        break;
                }
                break;
            case CtrlCommands.Exit:
                break;
        }
    }
}