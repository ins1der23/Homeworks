using HumanFriends.Model;

namespace HumanFriends.View;
class TextRus : IText
{
    public List<string> MainMenu { get; }
    public string MainMenuName { get; }

    public string ListMenuName { get; }

    public List<string> SortMenu { get; }
    public string SortMenuName { get; }

    public string Choose { get; }
    public string ChooseOrZero { get; }

    public TextRus()
    {
        MainMenu = ["Показать список животных",
                    "Выход"];
        MainMenuName = "Главное меню";
        ListMenuName = "Список животных";
        SortMenu = ["По имени животного",
                    "По дате рождения",
                    "По id"];
        SortMenuName = "Сортировать список:";


        Choose = "Выберите пункт меню и нажмите ENTER";
        ChooseOrZero = "Введите порядковый номер для выбора или оставьте поле пустым для возврата в главное меню и нажмите ENTER";
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
            Feature.Fighter => "Боей",
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