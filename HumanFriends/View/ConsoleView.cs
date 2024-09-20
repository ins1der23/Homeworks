using HumanFriends.Controller;
using HumanFriends.Model;
using HumanFriends.View;

class ConsoleView : IView
{
    private Menu? _menu;
    private readonly IText _text = new TextRus();
    private bool _clear;
    private string _textString = string.Empty;



    public CtrlCommands MainMenu()
    {
        _menu = new Menu(_text.MainMenu, _text.MainMenuName);
        int choice = MenuToChoice(_text.Choose, true);
        return choice switch
        {
            1 => CtrlCommands.Get,
            _ => CtrlCommands.Exit,
        };
    }

    public CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal animal)
    {
        throw new NotImplementedException();
    }





    private void ShowMenu() => Console.WriteLine(_menu);

    private void ShowString(string text, bool clear = false)
    {
        _clear = clear;
        if (_clear) Console.Clear();
        Console.WriteLine(text);

    }
    private int GetInteger(string textString)
    {
        _textString = textString;
        int num = 0;
        bool flag = true;
        do
        {
            Console.Write($"{_textString}: ");
            flag = int.TryParse(Console.ReadLine(), out num) || num == 0;
        } while (!flag);
        return num;
    }

    private int MenuToChoice(string invite, bool noNull, bool clear = true)
    {
        if (_menu is null) throw new NullReferenceException();
        _clear = clear;
        bool flag = false;
        int choice = 0;
        while (!flag)
        {
            if (clear) Console.Clear();
            ShowMenu();
            choice = GetInteger(invite);
            if (noNull)
            {
                if (choice > 0 && choice <= _menu.Size) flag = true;
            }
            else
            {
                if (choice >= 0 && choice <= _menu.Size) flag = true;
            }
        }
        return choice;
    }
}