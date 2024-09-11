namespace HumanFriends.Model;

class Dog : Pet
{
    public Breeds Breed { get; set; }
    public Dog(string name, int featureId, int breedId) : base(name, featureId)
    {
        Kind = Kinds.Dog;
        Breed = (Breeds)breedId;
    }
}