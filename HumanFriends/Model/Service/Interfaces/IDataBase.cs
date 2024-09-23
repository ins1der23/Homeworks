using HumanFriends.Model;

namespace HumanFriends.Service;

interface IDataBase
{
    List<IBaseAnimal> DbList { get; }
    void AddAnimal(IBaseAnimal animal);
    IBaseAnimal? GetById(int animalId);
}
