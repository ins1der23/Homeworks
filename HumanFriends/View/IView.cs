using HumanFriends.Controller;
using HumanFriends.Model;

namespace HumanFriends.View;

interface IView
{
  CtrlCommands MainMenu();
  CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal? animal);
  IBaseAnimal ChangeMenu(IBaseAnimal animal);
  IBaseAnimal AddAnimalMenu();
  string SearchMenu();
  string SortMenu();

}
