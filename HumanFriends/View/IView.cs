using HumanFriends.Controller;
using HumanFriends.Model;

namespace HumanFriends.View;

interface IView
{
    CtrlCommands MainMenu();
    CtrlCommands ListMenu(List<IBaseAnimal> animals, out IBaseAnimal animal);
  }
