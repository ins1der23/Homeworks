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
            else Console.WriteLine("No such breed");
        }
    }
    public Dog(string name, int featureId, int breedId) : base(name, featureId)
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