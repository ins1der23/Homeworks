namespace HumanFriends.Model;
interface IBaseAnimal
{

    int Id { get; }
    public Kinds Kind { get; }
    string Name { get; }
    DateTime DoB { get; }
    bool Vaccination { get; }
    Features Feature { get; }
    List<Commands> Commands { get; }
    

    void Vaccinate();
    void AddCommand(Commands command) => Commands.Add(command);
    void ShowCommands() => Commands.ForEach(x => Console.WriteLine(x));



}