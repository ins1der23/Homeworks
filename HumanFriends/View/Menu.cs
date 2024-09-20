class Menu(string[] choices, string name)
{
    private readonly string _name = name;
    private readonly string[] _choices = choices;

    public int Size => _choices.Length;

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
        for (int i = 0; i < _choices.Length; i++)
            output += $"  {i + 1,-5}{_choices[i]}\n";
        return $"{_name}\n{divider}\n{output}";
    }
}