using Core.Entities;

namespace Core.Handlers;
public record ItemInput(string Name);
public record ItemOutput(int Id, string Name);
public record ItemDelete(int Id);

public class ItemHandler
{
    private readonly IItemRepository _itemRepository;

    public ItemHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }  

    public int AddItem(ItemInput itemInput)
    {
        var lastById = _itemRepository.GetAll().MaxBy(x => x.Id);

        int id = 1;

        if (lastById != null)
        {
            id = lastById.Id + 1;
        }

        var item = new Item
        {
            Id = id,
            Name = itemInput.Name,
        };
        _itemRepository.Add(item);
        return id;
    }
    public List<ItemOutput> GetAll()
    {
        var items = _itemRepository.GetAll();

        return items.Select(item => new ItemOutput(item.Id, item.Name)).ToList();
    }
    public void DeleteItem(ItemDelete itemDelete)
    {
        var item = new Item
        {
            Id = itemDelete.Id,
        };
        _itemRepository.Remove(item);
    }
}

    