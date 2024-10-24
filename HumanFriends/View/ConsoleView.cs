using System.Diagnostics;
using HumanFriends.Controller;
using HumanFriends.Model;

namespace HumanFriends.View;
class ConsoleView(IText Language) : IView
{
    private Menu? _menu;
    private readonly IText _text = Language;
    private bool _clear;
    private int _choice;

    private readonly List<string> _someList = []; // список с пунктами  меню


    private void MenuToChoice(string invite, bool noNull, bool clear = true) // основной метод вывода меню и получения от пользователя выбора 
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

    public CtrlCommands MainMenu()
    {
        Console.Clear();
        _menu = new Menu(_text.MainMenu, _text.MainMenuName);
        MenuToChoice(_text.Choose, true);
        return _choice switch
        {
            1 => CtrlCommands.Get,
            3 => CtrlCommands.Add,
            _ => CtrlCommands.Exit,
        };
    }

    public CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal? animal)
    {
        Console.Clear();
        AnimalShortStrgLst(animals);
        animal = null;
        if (_someList is null) return CtrlCommands.Exit;
        while (true)
        {
            _menu = new Menu(_someList, _text.ListMenuName);
            MenuToChoice(_text.EmptyToReturn, false);
            if (_choice == 0) return CtrlCommands.Exit;
            animal = animals[_choice - 1];
            CtrlCommands command = ChgOrDelMenu(animal);
            if (command is CtrlCommands.Change || command is CtrlCommands.Delete) return command;
        }
    }

    private CtrlCommands ChgOrDelMenu(IBaseAnimal animal)
    {
        Console.Clear();

        Console.WriteLine(AnimalLongStrg(animal));

        _menu = new Menu(_text.ChgOrDelMenu, "");
        MenuToChoice(_text.EmptyToReturn, false);
        return _choice switch
        {
            1 => CtrlCommands.Change,
            2 => CtrlCommands.Delete,
            _ => CtrlCommands.Exit
        };
    }

    public IBaseAnimal ChangeMenu(IBaseAnimal animal)
    {
        Kind kind = animal.Kind;
        string name = GetName("Введите имя животного");
        DateTime doB = GetDate("Введите дату рождения в в формате гггг-мм-дд ");
        bool vaccination = SimpleQuestionMenu(_text.Vaccinated);
        int featureId;




        return animal;
    }




    private string AnimalLongStrg(IBaseAnimal animal) // получение из IBaseAnimal строки с оcновной информацией о животном
    {
        string commands = string.Join(",", EnumToStrgLst(animal.Commands));
        string vaccination = animal.Vaccination ? _text.Vaccinated : "";

        string outptut = $"Id: {animal.Id}, {_text.KindTranslate(animal.Kind)}, {animal.Name,-5}, {animal.DoB.ToShortDateString()}, {vaccination}\n";

        if (animal is Pet)
        {

            if (animal.GetType() == typeof(Dog))
            {
                Dog dog = (Dog)animal;
                string happy = dog.Happy ? _text.Happy : "";
                outptut += $"{_text.BreedTranslate(dog.Breed)}, {_text.FeatureTranslate(animal.Feature)}, {happy}\n{_text.Commands}: {commands}";
            }
        }
        else
        {

        }




        return outptut;
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

    public IBaseAnimal AddAnimalMenu() // меню добавления животного
    {
        Kind kind = KindMenu();
        string name = NameMenu();
        DateTime doB = DateMenu();
        bool vaccination = VaccinationMenu();
        int featureId = FeatureMenu(kind);
        List<AnimalCommand> commands = AnimalCommandsMenu();
        int breedId;
        if (Pet.kinds.Contains(kind))
        {
            bool happy = SimpleQuestionMenu("Счастлив?");
            switch (kind)
            {
                case Kind.Dog:
                    breedId = EnumMenu("Выберите породу животного", true, Dog.breeds);
                    return new Dog(name, doB, vaccination, featureId, commands, happy, breedId);
                default: throw new NotImplementedException();
            }
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private Kind KindMenu() => (Kind)EnumMenu<Kind>("Выберите тип животного", true);
    private string NameMenu() => GetName("Введите имя животного");
    private DateTime DateMenu() => GetDate("Введите дату рождения в в формате гггг-мм-дд ");
    private bool VaccinationMenu() => SimpleQuestionMenu(_text.Vaccinated);

    private List<AnimalCommand> AnimalCommandsMenu()
    {
        bool flag = true;
        List<AnimalCommand> commands = [];
        int commandId;
        while (flag)
        {
            Console.Clear();
            commands.ForEach(x => Console.WriteLine(_text.CommandTranslate(x)));
            flag = SimpleQuestionMenu("Добавить команды:", false);
            if (flag)
            {
                commandId = EnumMenu<AnimalCommand>("Выберите команду", true);
                commands.Add((AnimalCommand)commandId);
            }
        }
        return commands;
    }

    private int FeatureMenu(Kind kind)
    {
        return kind switch
        {
            Kind.Dog => EnumMenu("Выберите свойство животного", false, Dog.features),
            Kind.Cat => EnumMenu("Выберите свойство животного", false, Cat.features),
            _ => 0
        };
    }









    private bool SimpleQuestionMenu(string question, bool clear = true) // меню для вопроса да/нет
    {
        if (clear) Console.Clear();
        _menu = new Menu(_text.SimpleQstMenu, question);
        MenuToChoice(_text.Choose, true);
        if (_choice == 1) return true;
        return false;
    }

    private int EnumMenu<T>(string header, bool noNull, List<T>? choices = null) where T : Enum // меню для выбора из Enum, возвращает int представление Enum
    {
        Console.Clear();
        if (choices == null) _menu = new Menu(EnumToStrgLst(GetValues<T>()), header);
        else _menu = new Menu(EnumToStrgLst(choices), header);
        if (noNull) MenuToChoice(_text.Choose, noNull);
        else MenuToChoice(_text.ChooseOrEmpty, noNull);
        return _choice;
    }



    List<string> EnumToStrgLst<T>(List<T> enums) where T : Enum // обобщенный метод перевода Enum животных
    {
        List<string> outptut = [];
        foreach (var item in enums)
        {
            if (item is AnimalCommand command) outptut.Add(_text.CommandTranslate(command));
            else if (item is Breed breed) outptut.Add(_text.BreedTranslate(breed));
            else if (item is Kind kind) outptut.Add(_text.KindTranslate(kind));
            else if (item is Feature feature) outptut.Add(_text.FeatureTranslate(feature));
            else throw new ArgumentException("Wrong enum");
        }
        return outptut;
    }



    private List<string> AnimalShortStrgLst(List<IBaseAnimal> animals) // преобразование List<IBaseAnimal> в List<string> с оcновной инофрмацией о животном
    {
        _someList.Clear();
        animals.ToList().ForEach(animal => _someList.Add(AnimalShortStrg(animal)));
        return _someList;
    }

    private string AnimalShortStrg(IBaseAnimal animal) // получение из IBaseAnimal строки с оcновной информацией о животном
    {
        return $"| Id: {animal.Id} | {_text.KindTranslate(animal.Kind)} | {animal.Name,-5} | {animal.DoB.ToShortDateString()} | {_text.Vaccinated}: {_text.FlagTranslate(animal.Vaccination),-3} |";
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

    private string GetName(string textString) // получение заполненной string c именем  животного с клавиатуры
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