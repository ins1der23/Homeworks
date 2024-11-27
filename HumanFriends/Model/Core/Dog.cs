namespace HumanFriends.Model;

class Dog : Pet
{
    public static readonly List<Breed> breeds = [Breed.Mastiff, Breed.Spaniel, Breed.Dachshund];
    public static readonly List<Feature> features = [Feature.Outdoor];
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
    public Dog(string name, DateTime doB, bool vaccination, int featureId, HashSet<AnimalCommand> commands, bool happy, int breedId, int id = 0)
   : base(name, doB, vaccination, featureId, commands, happy, id)
    {
        Kind = Kind.Dog;
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
        Dog dog = (Dog)obj;
        if (Kind == dog.Kind &&
            Name.Equals(dog.Name) &&
            DoB.Equals(dog.DoB) &&
            Vaccination == dog.Vaccination &&
            Feature.Equals(dog.Feature) &&
            Commands.Equals(dog.Commands) &&
            Breed.Equals(dog.Breed))
            return true;
        return false;

    }

    // override object.GetHashCode
    public override int GetHashCode() => base.GetHashCode() + Breed.GetHashCode();

    public override void Change(IBaseAnimal animal)
    {
        if (animal is not Dog dog) throw new ParametersException();
        Name = dog.Name != string.Empty ? dog.Name : Name;
        DoB = dog.DoB;
        Vaccination = dog.Vaccination;
        Feature = dog.Feature;
        Commands = dog.Commands;
        Happy = dog.Happy;
        Breed = dog.breed;
    }
}