using HumanFriends.Model;
using HumanFriends.Service;
using HumanFriends.View;

IView view = new ConsoleView();
view.MainMenu();



// IDataWorker dbWorker = new FileWorker(Settings.dbPath);
// IClassParser parser = new ClassParser();
// IDataBase dataBase = new DataBase();



// dbWorker.CheckPath(); // проверяем/создаем файл с базой
// dbWorker.ReadToStrings().ForEach(x => dataBase.AddAnimal(parser.GetAnimal(x))); // заполняем dataBase с диска
// Console.WriteLine(dataBase.ToString());




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




// dbWorker.Dispose();
// IDataWorker fileWorker = new FileWorker(Settings.counterPath);
// fileWorker.Delete();













