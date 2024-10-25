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
            _choice = Utils.GetInteger(invite);
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
            2 => CtrlCommands.Find,
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
        int id = animal.Id;
        Kind kind = animal.Kind;
        string name = NameMenu();
        DateTime doB = DateMenu();
        bool vaccination = VaccinationMenu();
        int featureId = FeatureMenu(kind);
        List<AnimalCommand> commands = AnimalCommandsMenu(animal.Commands);
        bool happy = HappyMenu(kind);
        switch (kind)
        {
            case Kind.Dog:
                Dog dog = (Dog)animal;
                int breedId = (int)dog.Breed;
                return new Dog(name, doB, vaccination, featureId, commands, happy, breedId, id);

        }







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





    public string SortMenu() // меню выбора способа сортировки
    {
        Console.Clear();
        _menu = new Menu(_text.SortMenu, _text.SortMenuName);
        MenuToChoice(_text.EmptyToReturn, false);
        return _choice switch
        {
            1 => "name",
            2 => "date",
            _ => "id"
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
        int breedId = BreedMenu(kind);
        bool happy = HappyMenu(kind);
        return kind switch
        {
            Kind.Dog => new Dog(name, doB, vaccination, featureId, commands, happy, breedId),
            Kind.Cat => new Cat(name, doB, vaccination, featureId, commands, happy, breedId),
            _ => throw new NotImplementedException(),
        };
    }

    public string SearchMenu() // меню добавления животного
    {
        return Utils.GetString("Введите текст для поиска");
    }




    private Kind KindMenu() => (Kind)EnumMenu<Kind>("Выберите тип животного", true);
    private string NameMenu() => Utils.GetString("Введите имя животного");
    private DateTime DateMenu() => Utils.GetDate("Введите дату рождения в в формате гггг-мм-дд ");
    private bool VaccinationMenu() => SimpleQuestionMenu(_text.Vaccinated);

    private List<AnimalCommand> AnimalCommandsMenu(List<AnimalCommand>? old = null)
    {
        bool flag = true;
        List<AnimalCommand> commands = [];
        if (old != null) commands = old;
        int commandId;
        while (flag)
        {
            Console.Clear();
            commands.ForEach(x => Console.WriteLine(_text.CommandTranslate(x)));
            flag = SimpleQuestionMenu("Добавить команды:", false);
            if (flag)
            {
                commandId = EnumMenu<AnimalCommand>("Выберите команду или оставьте поле пустым для возврата", false);
                if (commandId != 0) commands.Add((AnimalCommand)commandId);
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
    private bool HappyMenu(Kind kind) => Pet.kinds.Contains(kind) && SimpleQuestionMenu("Счастлив?");

    private int BreedMenu(Kind kind)
    {
        return kind switch
        {
            Kind.Dog => EnumMenu("Выберите породу животного", true, Dog.breeds),
            Kind.Cat => EnumMenu("Выберите породу животного", true, Cat.breeds),
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
        if (choices == null) _menu = new Menu(EnumToStrgLst(Utils.GetValues<T>()), header);
        else _menu = new Menu(EnumToStrgLst(choices), header);
        if (noNull) MenuToChoice(_text.Choose, noNull);
        else MenuToChoice(_text.ChooseOrEmpty, noNull);
        return _choice;
    }



    private List<string> EnumToStrgLst<T>(List<T> enums) where T : Enum // обобщенный метод перевода Enum животных
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
}