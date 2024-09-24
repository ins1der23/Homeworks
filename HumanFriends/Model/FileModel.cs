using System.Security.Cryptography.X509Certificates;
using HumanFriends.Model;
using HumanFriends.Service;

namespace HumanFriends.Model;

class FileModel : IModel
{

    IDataWorker dbWorker = new FileWorker(Settings.dbPath);
    IClassParser parser = new ClassParser();
    IDataBase dataBase = new DataBase();


    public FileModel()
    {
        dbWorker.CheckPath(); // проверяем/создаем файл с базой
        dbWorker.ReadToStrings().ForEach(x => dataBase.AddAnimal(parser.GetAnimal(x))); // заполняем dataBase с диска





        // List<Commands> commands = [Commands.Sound, Commands.Sit];
        // List<Commands> commands2 = [];
        // DateTime date = new(2020, 2, 23);

        // IBaseAnimal dog1 = new Dog("Bob", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);
        // IBaseAnimal cat1 = new Cat("", 4);
        // IBaseAnimal dog2 = new Dog("John", 3, 6);




        // IBaseAnimal dog2 = new Dog("John", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);
        // IBaseAnimal dog3 = new Dog("Cake", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);

        // string dbString = string.Empty;

        // dbString = dog1.ToString() + "\n" + dog2.ToString() + "\n" + dog3.ToString();
        // dog1.AddCommand(Commands.Fetch);
        // dog1.AddCommand(Commands.Pounce);




        // baseAnimals.ForEach(x => Console.WriteLine(x));





        // Console.WriteLine(dbString);




        dbWorker.Dispose();
        IDataWorker fileWorker = new FileWorker(Settings.counterPath);
        fileWorker.Delete();
    }

    public void AddAnimal(IBaseAnimal animal)
    {
        Console.WriteLine(animal.ToString());
        Console.ReadLine();
        
        
    }

    public IBaseAnimal ChangeAnimal(IBaseAnimal animal)
    {
        throw new NotImplementedException();
    }

    public void DelAnimal(IBaseAnimal animal)
    {
        throw new NotImplementedException();
    }

    public IBaseAnimal GetAnimal(int animalId) => dataBase.GetById(animalId) ?? throw new NullReferenceException();
    public List<IBaseAnimal> GetAnimals(string sortingMOde = "id")
    {
        return sortingMOde switch
        {
            "id" => dataBase.DbList.OrderBy(x => x.Id).ToList() ?? throw new NullReferenceException(),
            "date" => dataBase.DbList.OrderBy(x => x).ToList() ?? throw new NullReferenceException(),
            "name" => dataBase.DbList.OrderBy(x => x.Name).ToList() ?? throw new NullReferenceException(),
            _ => dataBase.DbList ?? throw new NullReferenceException(),
        };
    }

}