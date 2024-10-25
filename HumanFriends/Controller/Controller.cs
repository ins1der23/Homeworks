using HumanFriends.Controller;
using HumanFriends.Model;
using HumanFriends.Service;
using HumanFriends.View;

class Controller(IText Language)
{

    private IView view = new ConsoleView(Language);
    private IModel model = new FileModel();

    public void Run()
    {
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");

        bool flag = true;
        while (flag)
        {
            CtrlCommands command = view.MainMenu();
            switch (command)
            {
                case CtrlCommands.Get:
                    string? sortingMode = view.SortMenu();
                    if (sortingMode is null) break;
                    AnimalsListActions("", sortingMode);
                    break;
                case CtrlCommands.Find:
                    string searchString = view.SearchMenu();
                    AnimalsListActions(searchString, "name");
                    break;
                case CtrlCommands.Add:
                    IBaseAnimal animal = view.AddAnimalMenu();
                    model.AddAnimal(animal);
                    break;
                case CtrlCommands.Exit:
                    FileWorker fileWorker = new(Settings.counterPath); //удаляем временные файлы
                    fileWorker.Delete();
                    fileWorker.Dispose();
                    flag = false;
                    break;
            }
        }
    }
    public void AnimalsListActions(string searchString, string sortingMode)
    {
        List<IBaseAnimal> animals = model.GetAnimals(searchString, sortingMode);
        CtrlCommands command = view.ListMenu(animals, out IBaseAnimal? baseAnimal);
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
    }


}