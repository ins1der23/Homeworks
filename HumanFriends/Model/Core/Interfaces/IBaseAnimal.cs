namespace HumanFriends.Model;
interface IBaseAnimal : IComparable<IBaseAnimal>
{

    int Id { get; }
    public Kinds Kind { get; }
    string Name { get; }
    DateTime DoB { get; }
    bool Vaccination { get; }
    Features Feature { get; }
    List<AnimalCommnds> Commands { get; }


    void Vaccinate();
    string CommandsToString();
    void AddCommand(AnimalCommnds command) => Commands.Add(command);
    void ShowCommands() => Commands.ForEach(x => Console.WriteLine(x));
  
}