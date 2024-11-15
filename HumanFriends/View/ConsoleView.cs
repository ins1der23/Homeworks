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

    public CtrlCommands MainMenu() // главное меню
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

    public CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal? animal) // меню для списка животных
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

    private CtrlCommands ChgOrDelMenu(IBaseAnimal animal) // менюи для выбора изменения или удаления
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

    public IBaseAnimal ChangeMenu(IBaseAnimal animal) // консольный интерфейс изменения животного
    {
        int id = animal.Id;
        Kind kind = animal.Kind;
        string name = NameMenu();
        DateTime doB = DateMenu();
        bool vaccination = VaccinationMenu();
        int featureId = FeatureMenu(kind);
        List<AnimalCommand> commands = AnimalCommandsMenu(animal.Commands);
        bool happy = HappyMenu(kind);
        int currentLoad = LoadMenu(animal);
        int breedId = 0;
        switch (kind)
        {
            case Kind.Dog:
                if (animal is Dog dog) breedId = (int)dog.Breed;
                return new Dog(name, doB, vaccination, featureId, commands, happy, breedId, id);
            case Kind.Cat:
                if (animal is Cat cat) breedId = (int)cat.Breed;
                return new Cat(name, doB, vaccination, featureId, commands, happy, breedId, id);
            case Kind.Hamster:
                return new Hamster(name, doB, vaccination, featureId, commands, happy, id);
            case Kind.Horse:
                if (animal is Horse horse) breedId = (int)horse.Breed;
                return new Horse(name, doB, vaccination, featureId, commands, breedId, currentLoad, id);
            case Kind.Camel:
                return new Camel(name, doB, vaccination, featureId, commands, currentLoad, id);
            case Kind.Donkey:
                return new Camel(name, doB, vaccination, featureId, commands, currentLoad, id);
            default:
                return animal;
        }
    }


    private int LoadMenu(IBaseAnimal animal) // меню ввода текущей загрузки животного
    {

        int maxLoad;
        int currentLoad = 0;
        if (animal is IPackAnimal iPackAnimal)
        {
            maxLoad = iPackAnimal.MaxLoad;
            bool flag = true;
            while (flag)
            {
                currentLoad = Utils.GetInteger($"Введите текущую загрузку животного от 0 до {maxLoad}");
                if (currentLoad >= 0 && currentLoad <= maxLoad) flag = false;
                else Console.WriteLine("Введены неверные данные");
            }
        }
        return currentLoad;
    }


    private string AnimalLongStrg(IBaseAnimal animal) // получение из IBaseAnimal строки с оcновной информацией о животном
    {
        string commands = string.Join(",", EnumToStrgLst(animal.Commands));
        string vaccination = animal.Vaccination ? _text.Vaccinated : "";

        string outptut = $"Id: {animal.Id}, {_text.KindTranslate(animal.Kind)}, {animal.Name,-5}, {animal.DoB.ToShortDateString()}, {vaccination}\n";

        if (animal is Pet)
        {
            switch (animal.Kind)
            {
                case Kind.Dog:
                    Dog dog = (Dog)animal;
                    string happy = dog.Happy ? _text.Happy : "";
                    outptut += $"{_text.BreedTranslate(dog.Breed)}, {_text.FeatureTranslate(animal.Feature)}, {happy}\n{_text.Commands}: {commands}";
                    break;
                case Kind.Cat:
                    Cat cat = (Cat)animal;
                    happy = cat.Happy ? _text.Happy : "";
                    outptut += $"{_text.BreedTranslate(cat.Breed)}, {_text.FeatureTranslate(animal.Feature)}, {happy}\n{_text.Commands}: {commands}";
                    break;
                case Kind.Hamster:
                    Hamster hamster = (Hamster)animal;
                    happy = hamster.Happy ? _text.Happy : "";
                    outptut += $"{_text.FeatureTranslate(animal.Feature)}, {happy}\n{_text.Commands}: {commands}";
                    break;
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
        Console.WriteLine(featureId);
        Console.ReadLine();
        List<AnimalCommand> commands = AnimalCommandsMenu();
        int breedId = BreedMenu(kind);
        bool happy = HappyMenu(kind);
        return kind switch
        {
            Kind.Dog => new Dog(name, doB, vaccination, featureId, commands, happy, breedId),
            Kind.Cat => new Cat(name, doB, vaccination, featureId, commands, happy, breedId),
            Kind.Hamster => new Hamster(name, doB, vaccination, featureId, commands, happy),
            Kind.Horse => new Horse(name, doB, vaccination, featureId, commands, breedId),
            Kind.Camel => new Camel(name, doB, vaccination, featureId, commands),
            Kind.Donkey => new Donkey(name, doB, vaccination, featureId, commands),
            _ => throw new NotImplementedException(),
        };
    }

    public string SearchMenu() // меню поиска животного
    {
        return Utils.GetString(_text.SearchInput);
    }


    private Kind KindMenu() => (Kind)EnumMenu<Kind>(_text.ChooseKind, true);
    private string NameMenu() => Utils.GetString(_text.InputName);
    private DateTime DateMenu() => Utils.GetDate(_text.InputDoB);
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
            flag = SimpleQuestionMenu(_text.AddCommands, false);
            if (flag)
            {
                commandId = EnumMenu<AnimalCommand>(_text.ChooseCommand, false);
                if (commandId != 0) commands.Add((AnimalCommand)commandId);
            }
        }
        return commands;
    }

    private int FeatureMenu(Kind kind)
    {
        switch (kind)
        {
            case Kind.Dog:
                _choice = EnumMenu(_text.ChooseFeature, false, Dog.features);
                int featureId = (_choice != 0) ? (int)Dog.features[_choice - 1] : 0;
                return featureId;
            case Kind.Cat:
                _choice = EnumMenu(_text.ChooseFeature, false, Cat.features);
                featureId = (_choice != 0) ? (int)Cat.features[_choice - 1] : 0;
                return featureId;
            case Kind.Hamster:
                _choice = EnumMenu(_text.ChooseFeature, false, Hamster.features);
                featureId = (_choice != 0) ? (int)Hamster.features[_choice - 1] : 0;
                return featureId;
            case Kind.Horse:
                _choice = EnumMenu(_text.ChooseFeature, false, Horse.features);
                featureId = (_choice != 0) ? (int)Horse.features[_choice - 1] : 0;
                return featureId;
            case Kind.Camel:
                _choice = EnumMenu(_text.ChooseFeature, false, Camel.features);
                featureId = (_choice != 0) ? (int)Camel.features[_choice - 1] : 0;
                return featureId;
            case Kind.Donkey:
                _choice = EnumMenu(_text.ChooseFeature, false, Donkey.features);
                featureId = (_choice != 0) ? (int)Donkey.features[_choice - 1] : 0;
                return featureId;
            default: return 0;
        };
    }
    private bool HappyMenu(Kind kind) => Pet.kinds.Contains(kind) && SimpleQuestionMenu(_text.Happy);

    private int BreedMenu(Kind kind)
    {
        switch (kind)
        {
            case Kind.Dog:
                _choice = EnumMenu(_text.ChooseBreed, true, Dog.breeds);
                int breedId = (int)Dog.breeds[_choice - 1];
                return breedId;
            case Kind.Cat:
                _choice = EnumMenu(_text.ChooseBreed, true, Cat.breeds);
                breedId = (int)Cat.breeds[_choice - 1];
                return breedId;
            case Kind.Horse:
                _choice = EnumMenu(_text.ChooseBreed, true, Horse.breeds);
                breedId = (int)Horse.breeds[_choice - 1];
                return breedId;
            default: return 0;
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