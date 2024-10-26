using System.Linq.Expressions;
using HumanFriends.Model;
using HumanFriends.Service;
using HumanFriends.View;


IText Russian = new TextRus();
Controller main = new(Russian);
main.Run();












