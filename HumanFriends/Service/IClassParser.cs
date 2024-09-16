using HumanFriends.Model;

namespace HumanFriends.Service;

interface IClassParser
{
    IBaseAnimal GetAnimal(string checkedString);
}