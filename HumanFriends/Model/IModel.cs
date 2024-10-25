namespace HumanFriends.Model;

interface IModel
{
    List<IBaseAnimal> GetAnimals(string sortingMode);
    void AddAnimal(IBaseAnimal animal);
    IBaseAnimal GetAnimal(int animalId);
    void ChangeAnimal(IBaseAnimal animal);
    void DelAnimal(IBaseAnimal animal);
}