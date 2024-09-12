namespace HumanFriends.Model;
interface IPet : IBaseAnimal
{
    bool Happy { get; }
    void Caress();
    void Unhappy();

     

}