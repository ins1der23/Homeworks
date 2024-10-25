using HumanFriends.Model;

namespace HumanFriends.Service;

class DataBase : IDataBase // класс для работы с базой данных животных
{
    public List<IBaseAnimal> DbList { get; } = [];
    public void AddAnimal(IBaseAnimal animal) => DbList.Add(animal); // добавляем животное в DbList

    public void ChangeAnimal(IBaseAnimal animal) // достаем животное из DbList, удаляем, меняем, записываем обратно в DbList
    {
        IBaseAnimal toChange = GetById(animal.Id) ?? throw new NullReferenceException();
        DbList.Remove(toChange);
        toChange.Change(animal);
        DbList.Add(toChange);
    }
    public void DelAnimal(IBaseAnimal animal) => DbList.Remove(animal); // удаляем животное из DbList
    

    public IBaseAnimal? GetById(int animalId) => DbList.Where(x => x.Id == animalId).FirstOrDefault();

    public override string ToString()
    {
        string output = string.Empty;
        DbList.OrderBy(x => x).ToList().ForEach(x => output += x.ToString() + "\n");
        return output;
    }

}