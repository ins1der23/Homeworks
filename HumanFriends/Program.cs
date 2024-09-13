using HumanFriends.Model;
using HumanFriends.Service;

List<Commands> commands = [Commands.Sound, Commands.Sit];
List<Commands> commands2 = [];
DateTime date = new(2020, 2, 23);

IBaseAnimal dog1 = new Dog("Bob", date, true, (int)Features.Outdoor, commands2, true, (int)Breeds.Mastiff);
// IBaseAnimal cat1 = new Cat("", 4);
// IBaseAnimal dog2 = new Dog("John", 3, 6);

ClassParser parser = new();

parser.GetAnimal(dog1.ToString());

// dog1.AddCommand(Commands.Fetch);
// dog1.AddCommand(Commands.Pounce);

Console.WriteLine(dog1);













