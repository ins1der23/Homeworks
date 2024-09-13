
using System.Runtime.InteropServices;
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
            else throw new EnumException();
        }
    }
    public List<Commands> Commands { get; private set; }
    public bool Happy { get; private set; }


    public Pet(string name, DateTime doB, bool vaccination, int featureId, List<Commands> commands, bool happy, int id = 0)
    {
        using Counter cnt = new();
        if (id == 0) Id = Counter.Id;
        Name = name;
        DoB = doB;
        Vaccination = vaccination;
        Feature = (Features)featureId;
        Commands = commands;
        Happy = happy;
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

    public string CommandsToString() => string.Join(",", Commands.Cast<int>().ToList());

    public override string ToString()
    {

        return $"{Id};{(int)Kind};{Name};{DoB.ToShortDateString()};{Convert.ToInt32(Vaccination)};{(int)Feature};{CommandsToString()};{Convert.ToInt32(Happy)}";
    }


    public abstract override bool Equals(object? obj);

    public override int GetHashCode()
    {
        return Id.GetHashCode() +
        Kind.GetHashCode() +
        Name.GetHashCode() +
        DoB.GetHashCode() +
        Vaccination.GetHashCode() +
        feature.GetHashCode() +
        Commands.GetHashCode() +
        Happy.GetHashCode();
    }


}