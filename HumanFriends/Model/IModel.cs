namespace HumanFriends.Model;

interface IModel
{
    List<IBaseAnimal> GetAnimals();
    void AddAnimal(IBaseAnimal animal);
    IBaseAnimal GetAnimal(int animalId);
    IBaseAnimal ChangeAnimal(IBaseAnimal animal);
    void DelAnimal(IBaseAnimal animal);
}