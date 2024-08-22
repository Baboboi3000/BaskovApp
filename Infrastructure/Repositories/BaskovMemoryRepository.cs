using Core.Repository;

namespace Infrastructure.Repositories;

public class BaskovMemoryRepository : IBaskovRepository
{
    private readonly List<Baskov> _baskov = [];

    public void Add(Baskov baskov)
    {
        _baskov.Add(baskov);
    }

    public List<Baskov> GetAll()
    {
        return _baskov;
    }
    
    public void Remove(Baskov baskov)
    {
        _baskov.Remove(baskov);
    }
}

