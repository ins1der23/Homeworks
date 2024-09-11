using HumanFriends.Model;

IPet dog1 = new Dog("er", 4);
IBaseAnimal cat1 = new Cat("", 4);
IBaseAnimal dog2 = new Dog("ert", 8);


dog1.AddCommand(Commands.Fetch);
dog1.AddCommand(Commands.Pounce);

Console.WriteLine(dog1.Name);
Console.WriteLine(dog2.Name);




dog1.ShowCommands();
dog1.Vaccinate();







