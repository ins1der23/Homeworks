using HumanFriends.Model;

namespace HumanFriends.View;
interface IText
{
    List<string> MainMenu { get; }
    string MainMenuName { get; }
    List<string> SortMenu { get; }
    string SortMenuName { get; }
    string ListMenuName { get; }
    List<string> SimpleQstMenu { get; }
    List<string> ChgOrDelMenu { get; }

    string Choose { get; }
    string ChooseOrEmpty { get; }
    string EmptyToReturn { get; }

    public string Vaccinated { get; }
    public string Commands { get; }
    public string Happy { get; }
    

    string FlagTranslate(bool flag);
    string KindTranslate(Kind kind);
    string FeatureTranslate(Feature feature);
    string BreedTranslate(Breed breed);
    string CommandTranslate(AnimalCommand command);


}


