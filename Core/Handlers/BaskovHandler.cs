namespace Core.Handlers;

public record BaskovInput(string Name, int Age);
public record BaskovOutput(string Name, int Age, DateTime Created);

public class BaskovHandler
{
    private readonly IBaskovRepository _baskovrepository;
    public BaskovHandler(IBaskovRepository baskovrepository)
    {
        _baskovrepository = baskovrepository;
    }
    public void AddBaskov(BaskovInput baskovInput)
    {
        var lastById = _baskovrepository.GetAll().MaxBy(x => x.Id);
        int id = 1;

        if (lastById != null)
        {
            id = lastById.Id++;
        }
        var baskov = new Baskov
        {
            Id = id,
            Name = baskovInput.Name,
            Age = baskovInput.Age,
            Created = DateTime.UtcNow,
        };
        _baskovrepository.Add(baskov);
    }
    public List<BaskovOutput> GetAll()
    {
        var baskov = _baskovrepository.GetAll();
        return baskov.Select(baskov => new BaskovOutput(baskov.Name, baskov.Age, baskov.Created)).ToList();
    }
}

