using System.Dynamic;

namespace HumanFriends.View;
class TextRus : IText
{
    public string[] MainMenu { get; }
    public string MainMenuText { get; }
    public string MainMenuName { get; }
    public string Choose { get; }

    public TextRus()
    {
        MainMenu = ["Показать список животных",
                    "Выход"];
        MainMenuText = @"Введите номер животного, чтобы его выбрать, или оставьте 
                        поле пустым для возврата в главное меню и нажмите ENTER";
        MainMenuName = "Главное меню";
        Choose = "Выберите пункт меню  нажмите ENTER";
    }
}