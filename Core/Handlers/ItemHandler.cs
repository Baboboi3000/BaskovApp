using Core.Repositories;

namespace Core.Handlers;
public record ItemInput(string Name);
public record ItemOutput(int Id, string Name);
public record AddItemToUser(int ItemId, int UserId);

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
    public string AddItemToUser(AddItemToUser addItemToUser)
    {
         
        return "Успешно добавлено";
    }
    public List<ItemOutput> GetAll()
    {
        var drivers = _itemRepository.GetAll();

        return drivers.Select(item => new ItemOutput(item.Id, item.Name)).ToList();
    }
}

    