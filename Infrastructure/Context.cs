using System.Text.Json;
using System.Xml.Linq;

namespace Infrastructure;

public class JsonContext
{
    private const string _filePath = "context.json";
    private static JsonContext _memoryContext;

    public static JsonContext GetInstance()
    {
        if (_memoryContext != null)
            return _memoryContext;

        var isExisted = File.Exists(_filePath);

        if (!isExisted)
        {
            File.Create(_filePath).Close();
            _memoryContext = new JsonContext();
            _memoryContext.SaveChanges();
            return _memoryContext;
        }
        else
        {
            var json = File.ReadAllText(_filePath);

            _memoryContext = JsonSerializer.Deserialize<JsonContext>(json);
            return _memoryContext;
        }
    }

    public List<User> Users { get; set; } = [];

    public List<Item> Items { get; set; } = [];

    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_memoryContext, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        File.WriteAllText(_filePath, json);
    }
}