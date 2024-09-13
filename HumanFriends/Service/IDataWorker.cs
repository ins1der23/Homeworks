namespace HumanFriends.Service;

interface IDataWorker : IDisposable
{
    void Check();
    string Read();
    void Write(string text, bool append = false);
    void Delete();
    
     
}
