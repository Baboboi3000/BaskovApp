using Core.Entities;

namespace Core.Repositories;

public interface IItemRepository
{
    void Add(Item item);

    List<Item> GetAll();

    void Remove(Item item);
    
}
