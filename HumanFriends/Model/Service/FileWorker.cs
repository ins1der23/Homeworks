namespace HumanFriends.Service;
class FileWorker(string path) : IDataWorker // класс для работы файлами
{
    private readonly string _path = path;
    private readonly FileInfo _file = new(path);
    private bool _disposed = false;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    public void CheckPath() // проверка наличия файла и его создание в случае отстутсвтия
    {
        if (!_file.Exists)
            using (_file.Create())
                Console.WriteLine($"{_path} is created");
    }

    public string Read() // чтение из файла в string
    {
        string temp = string.Empty;
        if (_file.Exists)
            using (_reader = new(_path))
                temp += _reader.ReadLine();
        return temp;
    }

    public List<string> ReadToStrings() // чтение из файла в List<string>
    {
        List<string> temp = [];
        if (_file.Exists)
        {
            using (_reader = new(_path))
            {
                string? line;
                while ((line = _reader.ReadLine()) != null) temp.Add(line);
            }
        }
        return temp;
    }

    public void Write(string text, bool append = false) // запись в файл string
    {
        if (_file.Exists)
            using (_writer = new(_path, append))
                _writer.WriteLine(text);
    }

    public void Delete() // удаление файла (кроме файла с базой)
    {
        if (_file.Exists && _path != Settings.dbPath)
            _file.Delete();
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


