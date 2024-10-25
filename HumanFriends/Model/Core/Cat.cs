namespace HumanFriends.Model;

class Cat : Pet
{
    public static readonly List<Breed> breeds = [Breed.VietnameseStreet, Breed.EnglishPopeyed, Breed.ScottishFold];
    public static readonly List<Feature> features = [Feature.Mousehunt];
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


    public Cat(string name, DateTime doB, bool vaccination, int featureId, List<AnimalCommand> commands, bool happy, int breedId, int id = 0)
    : base(name, doB, vaccination, featureId, commands, happy, id)
    {
        Kind = Kind.Cat;
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
        throw new NotImplementedException();
    }
}