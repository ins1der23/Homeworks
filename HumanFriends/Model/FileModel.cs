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
        try
        {
            dbWorker.CheckPath(); // проверяем/создаем файл с базой
            dbWorker.ReadToStrings().ForEach(x => dataBase.AddAnimal(parser.GetAnimal(x))); // заполняем dataBase с диска
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            FileWorker fileWorker = new(Settings.counterPath); //удаляем временные файлы
            fileWorker.Delete();
            fileWorker.Dispose();
            throw;
        }
        dbWorker.Dispose();
    }

    public void AddAnimal(IBaseAnimal animal)
    {
        dataBase.AddAnimal(animal);
        try
        {
            dbWorker.Write(dataBase.ToString() ?? "");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            FileWorker fileWorker = new(Settings.counterPath); //удаляем временные файлы
            fileWorker.Delete();
            fileWorker.Dispose();
            throw;
        }
    }

    public void ChangeAnimal(IBaseAnimal animal)  // метод изменения животного и записи в файл измененных данных 
    {
        dataBase.ChangeAnimal(animal);
        try
        {
            dbWorker.Write(dataBase.ToString() ?? "");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            FileWorker fileWorker = new(Settings.counterPath); //удаляем временные файлы
            fileWorker.Delete();
            fileWorker.Dispose();
            throw;
        }
    }

    public void DelAnimal(IBaseAnimal animal)
    {
        dataBase.DelAnimal(animal);
        try
        {
            dbWorker.Write(dataBase.ToString() ?? "");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            FileWorker fileWorker = new(Settings.counterPath); //удаляем временные файлы
            fileWorker.Delete();
            fileWorker.Dispose();
            throw;
        }
    }

    public IBaseAnimal GetAnimal(int animalId) => dataBase.GetById(animalId) ?? throw new NullReferenceException();
    public List<IBaseAnimal> GetAnimals(string searchString = "", string sortingMode = "name") => dataBase.GetAnimals(searchString, sortingMode);

}