namespace HumanFriends.Service;

interface IDataWorker : IDisposable
{
    void CheckPath(); // проверить путь для работы с дынными
    string Read(); // считать физическе данные в string
    List<string> ReadToStrings(); // считать физические данные в List<string>
    void Write(string text, bool append = false); // записать данные
    void Delete(); // удалить физические данные
    
     
}
