using HumanFriends.Service;
namespace HumanFriends.Model;

class Counter : IDisposable
{
    private readonly IDataWorker? _dataWorker;
    public static int Id { get; private set; }
    private bool _disposed;


    public Counter(string mode = "file") // создание Counter по умолчанию в файловом режиме
    {
        string path = Config.counterPath;
        try
        {
            if (mode == "file") _dataWorker = new FileWorker(path);
            _dataWorker?.Check();
            // string temp = string.Empty;
            // temp += _dataWorker?.Read();
            // bool check = int.TryParse(temp, out int res);
            // if (check) Id = res;
            Id++;
            _dataWorker?.Write(Id.ToString());
            _dataWorker?.Dispose();
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }

    public void Dispose()
    {
        CleanUp(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void CleanUp(bool disposing)
    {
        if (_disposed)
        {
            return;
        }
        if (disposing)
        {
            _dataWorker?.Dispose();
        }
        _disposed = true;
    }
    ~Counter()
    {
        CleanUp(false);
    }

}
