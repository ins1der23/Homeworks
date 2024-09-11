namespace HumanFriends.Service;
class FileWorker(string path) : IDataWorker
{
    private readonly string _path = path;
    private readonly FileInfo _file = new(path);
    private StreamReader? _reader;
    private StreamWriter? _writer;
    private string? _temp;
    private bool _disposed = false;

    public void Check() // проверка наличия файла и его создание в случае отстутсвтия
    {
        try
        {
            if (!_file.Exists)
                using (_file.Create())
                    Console.WriteLine($"{_path} is created");
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public string Read() // чтение из файла в string
    {
        _temp = string.Empty;
        if (_file.Exists)
            using (_reader = new(_path))
                _temp += _reader.ReadLine();
        else throw new FileNotFoundException();
        return _temp;
    }

    public void Write(string text, bool append = false) // запись в файл string
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


