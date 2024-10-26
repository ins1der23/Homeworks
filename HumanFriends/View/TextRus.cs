using HumanFriends.Model;

namespace HumanFriends.View;
class TextRus : IText // класс для русского интерфейса
{
    public List<string> MainMenu { get; }
    public string MainMenuName { get; }
    public string ListMenuName { get; }
    public List<string> SortMenu { get; }
    public string SortMenuName { get; }
    public List<string> SimpleQstMenu { get; }
    public List<string> ChgOrDelMenu { get; }


    public string Choose { get; }
    public string ChooseOrEmpty { get; }
    public string EmptyToReturn { get; }


    public string Vaccinated { get; }
    public string Commands { get; }
    public string Happy { get; }
    public string SearchInput { get; }
    public string ChooseKind { get; }
    public string InputName { get; }
    public string InputDoB { get; }
    public string AddCommands { get; }
    public string ChooseCommand { get; }
    public string ChooseFeature { get; }
    public string ChooseBreed { get; }





    public TextRus()
    {
        MainMenu = ["Показать список всех животных", "Найти животное", "Добавить животное", "Выход"];
        MainMenuName = "Главное меню";
        ListMenuName = "Список животных";
        SortMenu = ["По имени животного", "По дате рождения", "По id"];
        SortMenuName = "Сортировать список:";
        SimpleQstMenu = ["Да", "Нет"];
        ChgOrDelMenu = ["Изменить животное", "Удалить животное"];
        Choose = "Выберите пункт меню и нажмите ENTER";
        ChooseOrEmpty = "Выберите пункт меню или оставьте поле пустым, если нет подходящего, и нажмите ENTER";
        EmptyToReturn = "Выберите пункт меню или оставьте поле пустым для возврата в предыдущее меню и нажмите ENTER";
        Vaccinated = "Привит";
        Commands = "Выученные команды";
        Happy = "Счастлив";
        SearchInput = "Введите текст для поиска";
        ChooseKind = "Выберите тип животного";
        InputName = "Введите имя животного";
        InputDoB = "Введите дату рождения в в формате гггг-мм-дд ";
        AddCommands = "Добавить команды:";
        ChooseCommand = "Выберите команду или оставьте поле пустым для возврата";
        ChooseFeature = "Выберите свойство животного";
        ChooseBreed = "Выберите породу животного";





    }

    public string FlagTranslate(bool flag) => flag == true ? "Да" : "Нет";
    public string KindTranslate(Kind kind)
    {
        return kind switch
        {
            Kind.Dog => "Собака",
            Kind.Cat => "Кошка",
            Kind.Hamster => "Хомяк",
            Kind.Horse => "Лошадь",
            Kind.Camel => "Верблюд",
            Kind.Donkey => "Осел",
            _ => string.Empty,
        };
    }

    public string FeatureTranslate(Feature feature)
    {
        return feature switch
        {
            Feature.Outdoor => "Уличный",
            Feature.Mousehunt => "Ловит мышей",
            Feature.Wheelrun => "Бегает в колесе",
            Feature.Ambler => "Иноходец",
            Feature.Twohumped => "Двугорбый",
            Feature.Fighter => "Боец",
            _ => string.Empty,
        };
    }

    public string BreedTranslate(Breed breed)
    {
        return breed switch
        {
            Breed.Mastiff => "Дог",
            Breed.Spaniel => "Спаниэль",
            Breed.Dachshund => "Такса",
            Breed.VietnameseStreet => "Вьетнамский уличный",
            Breed.EnglishPopeyed => "Английский лупоглазый",
            Breed.ScottishFold => "Шотландский вислоухий",
            Breed.Arabic => "Арбаская",
            Breed.Donskaya => "Донская",
            Breed.Pony => "Пони",
            _ => string.Empty,
        };
    }

    public string CommandTranslate(AnimalCommand command)
    {
        return command switch
        {
            AnimalCommand.Sit => "Сесть",
            AnimalCommand.Stay => "Встать",
            AnimalCommand.Fetch => "Принести",
            AnimalCommand.Paw => "Дать лапу",
            AnimalCommand.Sound => "Издать звук",
            AnimalCommand.Pounce => "Атаковать",
            AnimalCommand.Scratch => "Поскрести",
            AnimalCommand.Roll => "Свернуться",
            AnimalCommand.Hide => "Спрятаться",
            AnimalCommand.Pace => "Шаг",
            AnimalCommand.Trot => "Рысь",
            AnimalCommand.Canter => "Галлоп",
            AnimalCommand.Load => "Загрузить",
            AnimalCommand.Walk => "Идти",
            AnimalCommand.Run => "Бежать",
            AnimalCommand.Kick => "Пнуть",
            _ => string.Empty,
        };
    }
}