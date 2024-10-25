using HumanFriends.Model;

namespace HumanFriends.Service;

interface IDataBase
{
    List<IBaseAnimal> DbList { get; }
    void AddAnimal(IBaseAnimal animal);
    public void ChangeAnimal(IBaseAnimal animal);
    void DelAnimal(IBaseAnimal animal);
    public List<IBaseAnimal> GetAnimals(string searchString, string sortingMode);
    IBaseAnimal? GetById(int animalId);
}
