
namespace App
{
    public class OrderApp
    {
        JsonContext _memoryContext;

        IOrderRepository _orderRepository;

        IUserRepository _userRepository;

        IItemRepository _itemRepository;

        OrderHandler _orderHandler;

        UserHandler _userHandler;

        ItemHandler _itemHandler;

        public OrderApp()
        {
            _memoryContext = JsonContext.GetInstance();
            _orderRepository = new OrderMemoryRepository(_memoryContext);
            _userRepository = new UserMemoryRepository(_memoryContext);
            _itemRepository = new ItemMemoryRepository(_memoryContext);
            _orderHandler = new(_orderRepository, _userRepository, _itemRepository);
        }
        public bool Handle(string action)
        {
            if (action == "order add")
            {
                Console.WriteLine("Введите id пользователя");

                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    Console.WriteLine("Id пользователя не число!!!");
                    return true;
                }

                Console.WriteLine("Введите id предметов через пробел");
                List<int> itemsIds = new List<int>();
                while (true)
                {
                    string str = Console.ReadLine();
                    if(str == "end")
                    {
                        break;
                    }
                    int itemId = int.Parse(str);
                    itemsIds.Add(itemId);
                }
                Console.WriteLine("Введите название заказа");
                var name = Console.ReadLine();
                var orderCreate = new OrderCreate(name, itemsIds, userId);
                var id = _orderHandler.CreateOrder(orderCreate);
                Console.WriteLine("Заказ создан c id " + id);
                return true;
            }
            return false;
        }
    }
}
