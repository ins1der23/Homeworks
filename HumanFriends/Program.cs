using HumanFriends.Model;
using HumanFriends.Service;

IDataWorker dbWorker = new FileWorker(Config.dbPath);
dbWorker.CheckPath();


List<Commands> commands = [Commands.Sound, Commands.Sit];
List<Commands> commands2 = [];
DateTime date = new(2020, 2, 23);

// IBaseAnimal dog1 = new Dog("Bob", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);
// IBaseAnimal cat1 = new Cat("", 4);
// IBaseAnimal dog2 = new Dog("John", 3, 6);

IClassParser parser = new ClassParser();


// IBaseAnimal dog2 = new Dog("John", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);
// IBaseAnimal dog3 = new Dog("Cake", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);

// string dbString = string.Empty;

// dbString = dog1.ToString() + "\n" + dog2.ToString() + "\n" + dog3.ToString();
// dog1.AddCommand(Commands.Fetch);
// dog1.AddCommand(Commands.Pounce);

List<string> dbList = dbWorker.ReadToStrings();


List<IBaseAnimal> baseAnimals = [];



dbList.ForEach(x => baseAnimals.Add(parser.GetAnimal(x)));
baseAnimals.ForEach(x => Console.WriteLine(x));





// Console.WriteLine(dbString);




// dbWorker.Dispose();
IDataWorker fileWorker = new FileWorker(Config.counterPath);
dbWorker.Delete();
fileWorker.Delete();













