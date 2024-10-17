
using Core.Handlers;

namespace App
{
    public class ItemsApp
    {
        JsonContext _memoryContext;

        IItemRepository _itemRepository;

        ItemHandler _itemHandler;
        public ItemsApp()
        {
            _memoryContext = JsonContext.GetInstance();
            _itemRepository = new ItemMemoryRepository(_memoryContext);
            _itemHandler = new(_itemRepository);
        }
        public bool Handle(string action)
        {

            if (action == "items add")
            {
                Console.WriteLine("Введите название предмета");
                var name = Console.ReadLine();
                var itemInput = new ItemInput(name);
                var id = _itemHandler.AddItem(itemInput);
                Console.WriteLine("Id предмета " + id);
                return true;
            }
            else if (action == "items get")
            {
                var items = _itemHandler.GetAll();
                if (items == null || items.Count == 0)
                {
                    Console.WriteLine("Предметов нет");
                    Console.WriteLine();
                }
                foreach (var item in items)
                {
                    Console.WriteLine($"Id: {item.Id}");
                }
                return true;
            }
            else if (action == "items delete")
            {
                Console.WriteLine("Введите Id");
                var id = int.Parse(Console.ReadLine());

                var itemDelete = new ItemDelete(id);

                _itemHandler.DeleteItem(itemDelete);
                Console.WriteLine("Предмет успешно удален");
                return true;
            }
            else if (action == "item add users")
            {
                var userId = int.Parse(Console.ReadLine()!);
                var itemId = int.Parse(Console.ReadLine()!);
                return true;
            }
            return false;
        }
    }
}
