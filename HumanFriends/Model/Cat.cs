namespace HumanFriends.Model;

class Cat : Pet
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
    public Cat(int id, string name, DateTime doB, bool vaccination, int featureId, List<Commands> commands, bool happy, int breedId)
     : base(name, doB, vaccination, featureId, commands, happy, id)
    {
        Kind = Kinds.Cat;
        Breed = (Breeds)breedId;
    }

    public override bool Equals(object? obj)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}