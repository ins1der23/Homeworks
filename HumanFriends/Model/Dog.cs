namespace HumanFriends.Model;

class Dog : Pet
{
    private Breeds breed;
    public Breeds Breed
    {
        get
        {
            return breed;
        }
        private set
        {
            if (Enum.IsDefined(typeof(Breeds), value)) breed = value;
            else throw new EnumException();
        }
    }
    public Dog(string name, DateTime doB, bool vaccination, int featureId, List<Commands> commands, bool happy, int breedId, int id = 0)
    : base(name, doB, vaccination, featureId, commands, happy, id)
    {
        Kind = Kinds.Dog;
        Breed = (Breeds)breedId;
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
        if (Id == dog.Id &&
            Kind == dog.Kind &&
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



}