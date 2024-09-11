namespace HumanFriends.Model;

class Cat : Pet
{
    public Cat(string name, int featureId) : base(name, featureId)
    {
        Kind = Kinds.Cat;
    }
}