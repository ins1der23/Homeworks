using HumanFriends.Service;
namespace HumanFriends.Model;

class Counter : IDisposable
{
    
    private bool _disposed;
    private readonly string _path;
    private readonly FileInfo _file;
    private  StreamReader? _reader;
    private readonly StreamWriter? _writer;
    private readonly string _temp;
    public static int Id { get; private set; }
    private FileWorker fileWorker;

    public Counter(string path)
    {
        _file = new FileInfo(path);

        using (fileWorker = new FileWorker(path))






        _path = path;
        
        _temp = string.Empty;
        if (_file.Exists)
        {
            using (_reader = new(_path))
                _temp += _reader.ReadLine();
            bool check = int.TryParse(_temp, out int res);
            if (check) Id = res;
        }
        else
        {
            using (_file.Create())
                Console.WriteLine("Файл счетчика не найден. Нумерация будет начата заново");
        }
        Id++;
        if (_file.Exists)
        {
            using (_writer = new(_path, false))
                _writer.WriteLine(Id);
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
            _reader?.Close();
            _writer?.Close();
        }
        Console.WriteLine("Counter disposed");
        _disposed = true;
    }
    ~Counter()
    {
        CleanUp(false);
    }

}
