namespace HumanFriends.Model;
interface IBaseAnimal
{
    protected string Name { get; set; }
    protected DateTime DoB { get; set; }
    protected bool Vaccination { get; set; }
    protected int FeatureId { get; set; }
    protected List<Command> Commands { get; set; }

    void AddCommand(Command command) => Commands.Add(command);
    void ShowCommands() => Commands.ForEach(x => Console.WriteLine(x));


}