namespace HumanFriends.Model;

class Cat : Pet
{
    public Cat(string name, int featureId) : base(name, featureId)
    {
        Kind = Kinds.Cat;
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