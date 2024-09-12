using HumanFriends.Model;

namespace HumanFriends.Service;

interface IClassParser 
{
    bool CheckString(string someString);
    IBaseAnimal GetAnimal(string checkedString);
}