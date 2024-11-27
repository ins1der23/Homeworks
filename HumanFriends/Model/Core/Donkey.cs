namespace HumanFriends.Model;

class Donkey : PackAnimal
{
    public static readonly List<Feature> features = [Feature.Fighter];

    public Donkey(string name, DateTime doB, bool vaccination, int featureId, HashSet<AnimalCommand> commands, int currentLoad = 0, int id = 0)
   : base(name, doB, vaccination, featureId, commands, currentLoad, id)
    {
        Kind = Kind.Donkey;
        MaxLoad = 70;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Donkey donkey = (Donkey)obj;
        if (Kind == donkey.Kind &&
            Name.Equals(donkey.Name) &&
            DoB.Equals(donkey.DoB) &&
            Vaccination == donkey.Vaccination &&
            Feature.Equals(donkey.Feature) &&
            Commands.Equals(donkey.Commands) &&
            MaxLoad == donkey.MaxLoad &&
            CurrentLoad == donkey.CurrentLoad)
            return true;
        return false;

    }

    // override object.GetHashCode
    public override int GetHashCode() => base.GetHashCode();

    public override void Change(IBaseAnimal animal)
    {
        if (animal is not Donkey donkey) throw new ParametersException();
        Name = donkey.Name != string.Empty ? donkey.Name : Name;
        DoB = donkey.DoB;
        Vaccination = donkey.Vaccination;
        Feature = donkey.Feature;
        Commands = donkey.Commands;
        MaxLoad = donkey.MaxLoad;
        CurrentLoad = donkey.CurrentLoad;
    }
}