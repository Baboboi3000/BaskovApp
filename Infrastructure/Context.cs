namespace Infrastructure;

public class JsonContext
{
    private const string _filePath = "context.json";
    private static JsonContext? _jsonContext;

    public static JsonContext GetInstance()
    {
        if (_jsonContext != null)
            return _jsonContext;

        var isExisted = File.Exists(_filePath);

        if (!isExisted)
        {
            File.Create(_filePath).Close();
            _jsonContext = new JsonContext();
            _jsonContext.SaveChanges();
            return _jsonContext;
        }
        else
        {
            var json = File.ReadAllText(_filePath);

            _jsonContext = JsonSerializer.Deserialize<JsonContext>(json);
            return _jsonContext;
        }
    }

    public List<User> Users { get; set; } = [];

    public List<Item> Items { get; set; } = [];

    public List<Order> Orders { get; set; } = [];

    public void SaveChanges()
    {

        var json = JsonSerializer.Serialize(_jsonContext, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });

        File.WriteAllText(_filePath, json);
    }
}