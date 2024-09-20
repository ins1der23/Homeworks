namespace HumanFriends.Model;

class ParametersException : Exception
{
    public ParametersException()
        : base("Invalid animal parameters") { }
}