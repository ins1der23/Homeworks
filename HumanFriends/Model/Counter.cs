using HumanFriends.Service;
namespace HumanFriends.Model;

class Counter : IDisposable
{

    private static Counter? _counter;
    private readonly IDataWorker? _dataWorker;
    public int Id { get; private set; }
    private bool _disposed;
    private Counter(string mode = "file") // создание Counter по умолчанию в файловом режиме
    {
        string path = Config.counterPath;
        try
        {
            if (mode == "file") _dataWorker = new FileWorker(path);
            _dataWorker?.CheckPath();
            string temp = string.Empty;
            temp += _dataWorker?.Read();
            bool check = int.TryParse(temp, out int res);
            if (check) Id = res;
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

    public static Counter GetInstance()
    {
        _counter ??= new Counter();
        return _counter;
    }

    public void SetId(int id) => Id = id;

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
        _counter = null;
        _disposed = true;
    }
    ~Counter()
    {
        CleanUp(false);
    }

}
