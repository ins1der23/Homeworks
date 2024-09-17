using HumanFriends.Model;

namespace HumanFriends.Service;

class DataBase : IDataBase
{
    private readonly List<IBaseAnimal> _dbList = [];
    public void AddAnimal(IBaseAnimal animal) => _dbList.Add(animal);

    public override string ToString()
    {
        string output = string.Empty;
        _dbList.OrderBy(x => x).ToList().ForEach(x => output += x.ToString() + "\n");
        return output;
    }

}