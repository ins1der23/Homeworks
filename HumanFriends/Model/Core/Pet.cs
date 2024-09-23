
using System.Runtime.InteropServices;
namespace HumanFriends.Model;
abstract class Pet : IPet
{
    public int Id { get; private set; }
    public Kind Kind { get; protected set; }
    public string Name { get; private set; }
    public DateTime DoB { get; private set; }
    public bool Vaccination { get; private set; }
    private Feature feature;
    public Feature Feature
    {
        get
        {
            return feature;
        }
        private set
        {
            if (Enum.IsDefined(typeof(Feature), value)) feature = value;
            else throw new EnumException();
        }
    }
    public List<AnimalCommand> Commands { get; private set; }
    public bool Happy { get; private set; }


    protected Pet(string name, DateTime doB, bool vaccination, int featureId, List<AnimalCommand> commands, bool happy, int id = 0)
    {
        if (string.IsNullOrEmpty(name) || doB > DateTime.Today) throw new ParametersException();
        using Counter cnt = Counter.GetInstance();
        // Id = id == 0 ? Counter.Id : id;
        if (id != 0) cnt.SetId(id);

        Id = cnt.Id;
        Name = name;
        DoB = doB;
        Vaccination = vaccination;
        Feature = (Feature)featureId;
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
        return Kind.GetHashCode() +
        Name.GetHashCode() +
        DoB.GetHashCode() +
        Vaccination.GetHashCode() +
        feature.GetHashCode() +
        Commands.GetHashCode() +
        Happy.GetHashCode();
    }

   
    public int CompareTo(IBaseAnimal? other) // метод сравнения по DoB и Id
    {
        ArgumentNullException.ThrowIfNull(other);
        if (DoB == other.DoB)
        {
            if (Id == other.Id) return 0;
            else if (Id > other.Id) return 1;
            else return -1;
        }
        if (DoB > other.DoB) return 1;
        else return -1;
    }
}