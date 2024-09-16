namespace HumanFriends.Service;

interface IDataWorker : IDisposable
{
    void CheckPath();
    string Read();
    public List<string> ReadToStrings();
    void Write(string text, bool append = false);
    void Delete();
    
     
}
