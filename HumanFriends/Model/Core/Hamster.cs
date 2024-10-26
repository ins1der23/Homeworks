namespace HumanFriends.Model;

class Hamster : Pet
{
    public static readonly List<Feature> features = [Feature.Wheelrun];

    public Hamster(string name, DateTime doB, bool vaccination, int featureId, List<AnimalCommand> commands, bool happy, int id = 0)
   : base(name, doB, vaccination, featureId, commands, happy, id)
    {
        Kind = Kind.Hamster;
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
        Hamster hamster = (Hamster)obj;
        if (Kind == hamster.Kind &&
            Name.Equals(hamster.Name) &&
            DoB.Equals(hamster.DoB) &&
            Vaccination == hamster.Vaccination &&
            Feature.Equals(hamster.Feature) &&
            Commands.Equals(hamster.Commands))
            return true;
        return false;

    }

    // override object.GetHashCode
    public override int GetHashCode() => base.GetHashCode();

    public override void Change(IBaseAnimal animal)
    {
        if (animal is not Hamster hamster) throw new ParametersException();
        Name = hamster.Name != string.Empty ? hamster.Name : Name;
        DoB = hamster.DoB;
        Vaccination = hamster.Vaccination;
        Feature = hamster.Feature;
        Commands = hamster.Commands;
        Happy = hamster.Happy;
    }
}