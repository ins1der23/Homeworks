using HumanFriends.Controller;
using HumanFriends.Model;
using HumanFriends.View;

class Controller(IText Language)
{


    // public static IController Controller { get;}
    private IView view = new ConsoleView(Language);
    private IModel model = new FileModel();
    public void Run()

    {
        bool flag = true;
        while (flag)
        {
            CtrlCommands command = view.MainMenu();
            switch (command)
            {
                case CtrlCommands.Get:
                    string? sortingMode = view.SortMenu();
                    if (sortingMode is null) break;
                    List<IBaseAnimal> animals = model.GetAnimals(sortingMode);
                    command = view.ListMenu(animals, out IBaseAnimal? baseAnimal);
                    IBaseAnimal? animal = baseAnimal;
                    switch (command)
                    {
                        case CtrlCommands.Delete:
                            if (animal is null) break;
                            model.DelAnimal(animal);
                            break;
                        case CtrlCommands.Change:
                            if (animal is null) break;
                            animal = view.ChangeMenu(animal);
                            model.ChangeAnimal(animal);
                            break;
                        case CtrlCommands.Exit:
                            break;
                    }
                    break;
                case CtrlCommands.Find:
                    break;
                case CtrlCommands.Add:
                    animal = view.AddAnimalMenu();
                    model.AddAnimal(animal);
                    break;
                case CtrlCommands.Exit:
                    flag = false;
                    break;
            }
        }

    }
}