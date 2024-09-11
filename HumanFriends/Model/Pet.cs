
namespace HumanFriends.Model;
abstract class Pet : IPet
{
    public int Id { get; private set; }
    public Kinds Kind { get; protected set; }
    public string Name { get; private set; }
    public DateTime DoB { get; private set; }
    public bool Vaccination { get; private set; }
    private Features feature;
    public Features Feature
    {
        get
        {
            return feature;
        }
        private set
        {
            if (Enum.IsDefined(typeof(Features), value)) feature = value;
            else Console.WriteLine("No such feature");
        }
    }
    public List<Commands> Commands { get; private set; } 
    public bool Happy { get; private set; }


    public Pet(string name, int featureId)
    {
        using Counter cnt = new();
        Id = Counter.Id;
        Name = name;
        Feature = (Features)featureId;
        Commands = [];
    }
    
    public void Caress() => Happy = true;
    public void Unhappy() => Happy = false;

    public void Vaccinate()
    {
        if (Vaccination)
        {
            Console.WriteLine("Already vaccinated");
            return;
        };
        Vaccination = true;
        Console.WriteLine("Vaccination done");
    }
}