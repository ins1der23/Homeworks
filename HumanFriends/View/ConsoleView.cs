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



    public CtrlCommands MainMenu()
    {
        Console.Clear();
        _menu = new Menu(_text.MainMenu, _text.MainMenuName);
        MenuToChoice(_text.Choose, true);
        return _choice switch
        {
            1 => CtrlCommands.Get,
            _ => CtrlCommands.Exit,
        };
    }

    public CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal? animal)
    {
        Console.Clear();
        AnimalShortStrgLst(animals);
        animal = null;
        if (_someList is null) return CtrlCommands.Exit;
        _menu = new Menu(_someList, _text.ListMenuName);
        MenuToChoice(_text.EmptyToNext, false);
        if (_choice == 0) return CtrlCommands.Add;
        animal = animals[_choice - 1];
        return CtrlCommands.Get;
    }

    public string? SortMenu() // меню выбора способа сортировки
    {
        Console.Clear();
        _menu = new Menu(_text.SortMenu, _text.SortMenuName);
        MenuToChoice(_text.EmptyToReturn, false);
        return _choice switch
        {
            1 => "name",
            2 => "date",
            3 => "id",
            _ => null,
        };
    }

    public IBaseAnimal AddAnimalMenu()
    {
        Kind kind = (Kind)EnumMenu<Kind>("Выберите тип животного", true);
        string name = GetName("Введите имя животного");
        DateTime doB = GetDate("Введите дату рождения в в формате гггг-мм-дд ");
        bool vaccination = SimpleQuestionMenu("Вакцинирован?");
        int featureId;
        List<AnimalCommand> commands = [];
        if (Pet.kinds.Contains(kind))
        {
            bool happy = SimpleQuestionMenu("Счастлив?");
            int breedId;
            switch (kind)
            {
                case Kind.Dog:
                    featureId = EnumMenu<Feature>("Выберите свойство животного", false, Dog.features);
                    breedId = EnumMenu<Breed>("Выберите породу животного", true, Dog.breeds);
                    return new Dog(name, doB, vaccination, featureId, commands, happy, breedId);
                default: throw new NotImplementedException();
            }
        }
        else
        {
            throw new NotImplementedException();
        }



    }

    private bool SimpleQuestionMenu(string question)
    {
        Console.Clear();
        _menu = new Menu(_text.SimpleQstMenu, question);
        MenuToChoice(_text.Choose, true);
        if (_choice == 1) return true;
        return false;
    }

    private int EnumMenu<T>(string header, bool noNull, List<T>? breeds = null) where T : Enum // меню для выбора Enum возвращает int представление Enum
    {
        Console.Clear();
        if (breeds == null) _menu = new Menu(EnumToStrgLst(GetValues<T>()), header);
        else _menu = new Menu(EnumToStrgLst(breeds), header);
        MenuToChoice(_text.ChooseOrEmpty, noNull);
        return _choice;
    }


    private void MenuToChoice(string invite, bool noNull, bool clear = true) // метод вывода  меню и получения от пользователя выбора 
    {
        if (_menu is null) throw new NullReferenceException();
        bool flag = false;
        while (!flag)
        {
            if (_clear) Console.Clear();
            Console.WriteLine(_menu);
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

    List<string> EnumToStrgLst<T>(List<T> breeds) where T : Enum // обобщенный метод перевода Enum животных
    {
        List<string> outptut = [];
        foreach (var item in breeds)
        {
            if (item is AnimalCommand command) outptut.Add(_text.CommandTranslate(command));
            else if (item is Breed breed) outptut.Add(_text.BreedTranslate(breed));
            else if (item is Kind kind) outptut.Add(_text.KindTranslate(kind));
            else if (item is Feature feature) outptut.Add(_text.FeatureTranslate(feature));
            else throw new ArgumentException("Wrong enum");
        }
        return outptut;
    }



    private void AnimalShortStrgLst(List<IBaseAnimal> animals) // преобразование списка IBaseAnimal  в список строк с соновной инофрмацией о животном
    {
        _someList.Clear();
        animals.ToList().ForEach(animal => _someList.Add(AnimalShortStrg(animal)));
    }

    private string AnimalShortStrg(IBaseAnimal animal) // получение из IBaseAnimal  строки с соновной инофрмацией о животном
    {
        _output = $"| Id: {animal.Id} | {_text.KindTranslate(animal.Kind)} | {animal.Name,-5} | {animal.DoB.ToShortDateString()} | Привит: {_text.FlagTranslate(animal.Vaccination),-3} |";
        return _output;
    }

    private void ShowString(string text, bool clear = false)
    {
        _clear = clear;
        if (_clear) Console.Clear();
        Console.WriteLine(text);
    }







    private List<T> GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>().ToList<T>(); // преобразование Enum в список 

    private void GetInteger(string textString) // присвоение int значения _choice с клавиатуры
    {
        bool flag;
        do
        {
            Console.Write($"{textString}: ");
            flag = int.TryParse(Console.ReadLine(), out _choice) || _choice == 0;
            Console.Clear();
        } while (!flag);
    }

    private string GetName(string textString) // получние заполненной string c именем  животного с клавиатуры
    {
        Console.Clear();
        string output;
        bool flag;
        do
        {
            Console.Write($"{textString}: ");
            output = string.Empty + Console.ReadLine();
            if (output.Equals(string.Empty)) flag = false;
            else
            {
                flag = true;
                foreach (char ch in output)
                {
                    if (!char.IsLetter(ch)) flag = false;
                }
            }
        } while (!flag);
        return output;
    }

    private DateTime GetDate(string text)
    {
        Console.Clear();
        DateTime date = new();
        bool flag = true;
        do
        {
            Console.Write($"{text}: ");
            flag = DateTime.TryParse(Console.ReadLine(), out date);
        } while (!flag);
        return date;
    }

}