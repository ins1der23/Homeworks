using HumanFriends.Controller;
using HumanFriends.Model;

namespace HumanFriends.View;
class ConsoleView(IText Language) : IView
{
    private Menu? _menu;
    private readonly IText _text = Language;
    private bool _clear;
    private int _choice;
    private string _output = string.Empty;
    private readonly List<string> _someList = [];



    public CtrlCommands MainMenu(out string sortingMode)
    {
        Console.Clear();
        _menu = new Menu(_text.MainMenu, _text.MainMenuName);
        sortingMode = string.Empty;
        MenuToChoice(_text.Choose, true);
        switch (_choice)
        {
            case 1:
                sortingMode = SortMenu();
                return CtrlCommands.Get;
            default:
                return CtrlCommands.Exit;
        }
    }

    public CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal? animal)
    {
        Console.Clear();
        AnimalShortStrgLst(animals);
        animal = null;
        if (_someList is null) return CtrlCommands.Exit;
        _menu = new Menu(_someList, _text.MainMenuName);
        MenuToChoice(_text.ChooseOrZero, false);
        animal = animals[_choice];

        return CtrlCommands.Exit;

        // animal = new BaseAnimal();
        // return CtrlCommands.Exit;

    }

    private string SortMenu() // меню выбора способа сортировки
    {
        Console.Clear();
        _menu = new Menu(_text.SortMenu, _text.SortMenuName);
        MenuToChoice(_text.ChooseOrZero, false);
        return _choice switch
        {
            1 => "name",
            2 => "date",
            3 => "id",
            _ => ""
        };
    }

    private void AnimalShortStrgLst(List<IBaseAnimal> animals)
    {
        _someList.Clear();
        animals.ToList().ForEach(animal => _someList.Add(AnimalShortStrg(animal)));
    }

    private string AnimalShortStrg(IBaseAnimal animal)
    {
        _output = $"| Id: {animal.Id} | {_text.KindTranslate(animal.Kind)} | {animal.Name,-5} | {animal.DoB.ToShortDateString()} | Привит: {_text.FlagTranslate(animal.Vaccination),-3} |";
        return _output;
    }
    private void ShowMenu() => Console.WriteLine(_menu);

    private void ShowString(string text, bool clear = false)
    {
        _clear = clear;
        if (_clear) Console.Clear();
        Console.WriteLine(text);

    }
    private void GetInteger(string textString)
    {
        bool flag;
        do
        {
            Console.Write($"{textString}: ");
            flag = int.TryParse(Console.ReadLine(), out _choice) || _choice == 0;
        } while (!flag);
    }

    private void MenuToChoice(string invite, bool noNull, bool clear = true)
    {
        if (_menu is null) throw new NullReferenceException();
        bool flag = false;
        while (!flag)
        {
            if (_clear) Console.Clear();
            ShowMenu();
            GetInteger(invite);
            if (noNull)
            {
                if (_choice > 0 && _choice <= _menu.Size) flag = true;
            }
            else
            {
                if (_choice >= 0 && _choice <= _menu.Size) flag = true;
            }
        }
    }
}