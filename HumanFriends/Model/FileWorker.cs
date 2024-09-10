namespace HumanFriends.Service;
class FileWorker(string path) : IDisposable
{
    private readonly string _path = path;
    private readonly FileInfo _file = new(path);
    private StreamReader? _reader;
    private StreamWriter? _writer;
    private string? _temp;
    bool _disposed = false;


    public void Create()
    {
        if (_file.Exists!)
        {
            using (_file.Create())
                Console.WriteLine("File is created");
        }
    }

    public string Read()
    {
        _temp = string.Empty;
        if (_file.Exists)
            using (_reader = new(_path))
                _temp += _reader.ReadLine();
        else throw new FileNotFoundException();
        return _temp;
    }

    public void Write(string text, bool append = false)
    {
        if (_file.Exists)
            using (_writer = new(_path, append))
                _writer.WriteLine(text);
        else throw new FileNotFoundException();
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
        _disposed = true;
    }
    ~FileWorker()
    {
        CleanUp(false);
    }
}


