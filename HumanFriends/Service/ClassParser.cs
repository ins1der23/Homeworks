using HumanFriends.Model;

namespace HumanFriends.Service;

class ClassParser
{
    private string CheckString(string someString, out string[] checkedStrings, out int kindId) // определяем строку в нужный тип
    {
        string[] strings = someString.Split(";");
        try
        {
            kindId = Convert.ToInt32(strings[1]);
        }
        catch (System.Exception)
        {
            throw;
        }
        checkedStrings = strings;
        return kindId switch
        {
            1 => strings.Length == 9 ? "Dog" : "Wrong data",
            2 => strings.Length == 9 ? "Cat" : "Wrong data",
            _ => "Wrong data",
        };
    }



    public IBaseAnimal GetAnimal(string someString)
    {
        string kind = CheckString(someString, out string[] checkedStrings, out int kindId);
        try
        {
            int id = Convert.ToInt32(checkedStrings[0]);
            string name = checkedStrings[2];
            DateTime Dob = Convert.ToDateTime(checkedStrings[3]);
            bool vaccination = Convert.ToBoolean(checkedStrings[4]);
            int featureId = Convert.ToInt32(checkedStrings[5]);
        }
        catch (System.Exception)
        {
            throw;
        }


        switch (kind)
        {
            case "Dog":

                return new Dog()




            break;




            case "Wrong data": throw new FormatException();

        }








        return new Dog("John", 3, 6);
    }
}
