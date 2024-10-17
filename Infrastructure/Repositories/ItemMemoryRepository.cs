using Core.Repositories;

namespace Infrastructure.Repositories;

public class ItemMemoryRepository : IItemRepository
{
    private readonly JsonContext _context;

    public ItemMemoryRepository(JsonContext context)
    {
        _context = context;
    }

    public void Add(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
    }

    public List<Item> GetAll()
    {
        return _context.Items;
    }
    public void Remove(Item item)
    {
        _context.Items.Remove(item);
        _context.SaveChanges();
    }
}
