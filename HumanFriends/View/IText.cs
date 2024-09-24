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

    string Choose { get; }
    string ChooseOrEmpty { get; }
    string EmptyToReturn { get; }
    string EmptyToNext { get; }

    string FlagTranslate(bool flag);
    string KindTranslate(Kind kind);
    string FeatureTranslate(Feature feature);
    string BreedTranslate(Breed breed);
    string CommandTranslate(AnimalCommand command);


}


