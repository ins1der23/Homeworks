namespace HumanFriends.View;

class Menu(List<string> choices, string name)  //класс для построения унифицированных меню
{
    private readonly string _name = name;
    private readonly List<string> _choices = choices;

    public int Size => _choices.Count;

    private string HeaderDivider()
    {
        string output = string.Empty;
        for (int i = 0; i < _name.Length; i++) output += "-";
        return output;
    }
    public override string ToString()
    {
        string output = string.Empty;
        string divider = HeaderDivider();
        for (int i = 0; i < _choices.Count; i++)
            output += $"  {i + 1,-3}{_choices[i]}\n";
        return $"{_name}\n{divider}\n{output}";
    }
}