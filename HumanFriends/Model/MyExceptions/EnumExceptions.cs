namespace HumanFriends.Model;



class EnumException : Exception
{
    public EnumException()
        : base("No such element") { }
}