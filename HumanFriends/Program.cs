using HumanFriends.Model;
using HumanFriends.Service;

IPet dog1 = new Dog("Bob", 4, (int)Breeds.Mastiff);
IBaseAnimal cat1 = new Cat("", 4);
IBaseAnimal dog2 = new Dog("John", 3, 6);

ClassParser parser = new();

parser.GetAnimal(dog2.ToString());

dog1.AddCommand(Commands.Fetch);
dog1.AddCommand(Commands.Pounce);

Console.WriteLine(dog1);
Console.WriteLine(dog2);












