
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace HumanFriends.Model;
abstract class Pet : IPet

{
    public static readonly List<Kind> kinds = [Kind.Dog, Kind.Cat, Kind.Hamster];
    public int Id { get; private set; }
    private Kind kind;
    public Kind Kind
    {
        get
        {
            return kind;
        }
        protected set
        {
            if (Enum.IsDefined(typeof(Kind), value) && kinds.Contains(value)) kind = value;
            else throw new EnumException();
        }
    }
    public string Name { get; protected set; }
    public DateTime DoB { get; protected set; }
    public bool Vaccination { get; protected set; }
    private Feature feature;
    public Feature Feature
    {
        get
        {
            return feature;
        }
        protected set
        {
            if (Enum.IsDefined(typeof(Feature), value) || value == 0) feature = value;
            else throw new EnumException();
        }
    }
    public HashSet<AnimalCommand> Commands { get; set; }
    public bool Happy { get; protected set; }



    protected Pet(string name, DateTime doB, bool vaccination, int featureId,HashSet<AnimalCommand> commands, bool happy, int id = 0)
    {
        if (string.IsNullOrEmpty(name) || doB > DateTime.Today) throw new ParametersException();
        using Counter cnt = Counter.GetInstance();
        Id = id == 0 ? cnt.Id : id;
        if (id != 0) cnt.SetId(id);
        Name = name;
        DoB = doB;
        Vaccination = vaccination;
        Feature = (Feature)featureId;
        Commands = commands;
        Happy = happy;
    }
    public void Caress() => Happy = true;
    public void Unhappy() => Happy = false;

    public bool Vaccinate()
    {
        if (Vaccination) return false;
        Vaccination = true;
        return true;
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

    public abstract void Change(IBaseAnimal animal);

}