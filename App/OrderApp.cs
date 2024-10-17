
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
        public  bool Handle(string action)
        {
            if(action == "order add")
            {
                Console.WriteLine("Введите id пользователя");
                var userId = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите id предмета");
                var itemId = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите название заказа");
                var name = Console.ReadLine();
                var orderCreate = new OrderCreate(name, itemId, userId);
               var id = _orderHandler.CreateOrder(orderCreate);
                Console.WriteLine("Заказ создан " + id );
                return true;
            }
            return false;
        }
    }
}
