namespace HumanFriends.Model;

class Horse : PackAnimal
{
    public static readonly List<Breed> breeds = [Breed.Arabic, Breed.Donskaya, Breed.Pony];
    public static readonly List<Feature> features = [Feature.Ambler];
    private Breed breed;
    public Breed Breed
    {
        get
        {
            return breed;
        }
        private set
        {
            if (Enum.IsDefined(typeof(Breed), value) && breeds.Contains(value)) breed = value;
            else throw new EnumException();
        }
    }
    public Horse(string name, DateTime doB, bool vaccination, int featureId, HashSet<AnimalCommand> commands, int breedId, int currentLoad = 0, int id = 0)
   : base(name, doB, vaccination, featureId, commands, currentLoad, id)
    {
        Kind = Kind.Horse;
        MaxLoad = 50;
        Breed = (Breed)breedId;
    }

    public override string ToString()
    {
        return base.ToString() + $";{(int)Breed}";
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Horse horse = (Horse)obj;
        if (Kind == horse.Kind &&
            Name.Equals(horse.Name) &&
            DoB.Equals(horse.DoB) &&
            Vaccination == horse.Vaccination &&
            Feature.Equals(horse.Feature) &&
            Commands.Equals(horse.Commands) &&
            MaxLoad == horse.MaxLoad &&
            CurrentLoad == horse.CurrentLoad &&
            Breed.Equals(horse.Breed))
            return true;
        return false;

    }

    // override object.GetHashCode
    public override int GetHashCode() => base.GetHashCode() + Breed.GetHashCode();

    public override void Change(IBaseAnimal animal)
    {
        if (animal is not Horse horse) throw new ParametersException();
        Name = horse.Name != string.Empty ? horse.Name : Name;
        DoB = horse.DoB;
        Vaccination = horse.Vaccination;
        Feature = horse.Feature;
        Commands = horse.Commands;
        MaxLoad = horse.MaxLoad;
        CurrentLoad = horse.CurrentLoad;
        Breed = horse.breed;
    }
}