
namespace HumanFriends.Model;
class Dog : IPet
{
    public int Id { get; set; } = Counter.Id;
    public string Name { get; set; } = String.Empty;
    public DateTime DoB { get; set; }
    public bool Vaccination { get; set; }
    public int FeatureId { get; set; }
    public List<Command> Commands { get; set; } = [];

    public Dog()
    {
        using Counter cnt = new("counter.txt");
        Id = Counter.Id;
    }


}