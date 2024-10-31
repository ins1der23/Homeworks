namespace HumanFriends.Model;
interface IPackAnimal : IBaseAnimal
{
    int MaxLoad { get; }
    int CurrentLoad { get; }
    bool Load(int weight);

}