namespace HumanFriends.Model;
interface IBaseAnimal : IComparable<IBaseAnimal>
{

    int Id { get; }
    public Kind Kind { get; }
    string Name { get; }
    DateTime DoB { get; }
    bool Vaccination { get; }
    Feature Feature { get; }
    HashSet<AnimalCommand> Commands { get; set; }

    bool Vaccinate();
    string CommandsToString();
    void Change(IBaseAnimal animal);








}