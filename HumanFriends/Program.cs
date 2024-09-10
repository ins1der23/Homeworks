using HumanFriends.Model;

IPet dog1 = new Dog
{
    Name = "er"
};

IPet dog2 = new Dog
{
    Name = "ert"
};

dog1.AddCommand(Command.Fetch);
dog1.AddCommand(Command.Pounce);

dog1.ShowCommands();

Console.WriteLine(Counter.Id);






