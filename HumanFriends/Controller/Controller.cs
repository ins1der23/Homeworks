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
            CtrlCommands command = view.MainMenu(out string sortingMode);
            switch (command)
            {
                case CtrlCommands.Get:
                    if (sortingMode.Equals(string.Empty)) break;
                    List<IBaseAnimal> animals = model.GetAnimals(sortingMode);
                    command = view.ListMenu(animals, out IBaseAnimal? baseAnimal);
                    if (baseAnimal is null) break;
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
                    flag = false;
                    break;
            }
        }

    }
}