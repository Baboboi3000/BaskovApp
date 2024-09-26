
namespace App
{
    public class ItemsApp
    {
        JsonContext _memoryContext;

        IItemRepository _itemRepository;

        ItemHandler _itemHandler;
        public ItemsApp()
        {
            _memoryContext = new JsonContext();
            _itemRepository = new ItemMemoryRepository(_memoryContext);
            _itemHandler = new(_itemRepository);
        }
        public bool Sisa(string action)
        {

            while (true)
            {

                if (action == "items add")
                {
                    Console.WriteLine("Введите название предмета");
                    var name = Console.ReadLine();
                    var itemInput = new ItemInput(name);
                    var id = _itemHandler.AddItem(itemInput);
                    Console.WriteLine("Id предмета" + id);
                }
                else if (action == "items get")
                {
                    var items = _itemHandler.GetAll();
                    if (items == null || items.Count == 0)
                    {
                        Console.WriteLine("Предметов нет");
                        Console.WriteLine();
                        continue;
                    }
                    foreach (var item in items)
                    {
                        Console.WriteLine($"Id: {item.Id}");
                    }
                }
                else if (action == "item add users")
                {
                    var userId = int.Parse(Console.ReadLine()!);
                    var itemId = int.Parse(Console.ReadLine()!);
                }

            }
        }
    }
}
