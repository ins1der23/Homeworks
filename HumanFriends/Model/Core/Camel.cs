namespace HumanFriends.Model;

class Camel : PackAnimal
{
    public static readonly List<Feature> features = [Feature.Twohumped];

    public Camel(string name, DateTime doB, bool vaccination, int featureId, HashSet<AnimalCommand> commands, int currentLoad = 0, int id = 0)
   : base(name, doB, vaccination, featureId, commands, currentLoad, id)
    {
        Kind = Kind.Camel;
        MaxLoad = 80;
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
        Camel camel = (Camel)obj;
        if (Kind == camel.Kind &&
            Name.Equals(camel.Name) &&
            DoB.Equals(camel.DoB) &&
            Vaccination == camel.Vaccination &&
            Feature.Equals(camel.Feature) &&
            Commands.Equals(camel.Commands) &&
            MaxLoad == camel.MaxLoad &&
            CurrentLoad == camel.CurrentLoad)
            return true;
        return false;

    }

    // override object.GetHashCode
    public override int GetHashCode() => base.GetHashCode();

    public override void Change(IBaseAnimal animal)
    {
        if (animal is not Camel camel) throw new ParametersException();
        Name = camel.Name != string.Empty ? camel.Name : Name;
        DoB = camel.DoB;
        Vaccination = camel.Vaccination;
        Feature = camel.Feature;
        Commands = camel.Commands;
        MaxLoad = camel.MaxLoad;
        CurrentLoad = camel.CurrentLoad;
    }
}