using HumanFriends.Model;

namespace HumanFriends.Service;

class DataBase : IDataBase
{
    public List<IBaseAnimal> DbList { get; } = [];
    public void AddAnimal(IBaseAnimal animal) => DbList.Add(animal);
    public IBaseAnimal? GetById(int animalId) => DbList.Where(x => x.Id == animalId).FirstOrDefault();

    // public override string ToString()
    // {
    //     string output = string.Empty;
    //     DbList.OrderBy(x => x).ToList().ForEach(x => output += x.ToString() + "\n");
    //     return output;
    // }

}