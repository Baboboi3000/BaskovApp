namespace Core.Entities;

public record OrderCreate(string Name, List<int> ItemsIds, int UserId);
public record OrderOutput(int Id, string Name);
public class OrderHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IItemRepository _itemRepository;

    public OrderHandler(IOrderRepository orderRepository, IUserRepository userRepository, IItemRepository itemRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _itemRepository = itemRepository;
    }
    public int CreateOrder(OrderCreate orderCreate)
    {
        var lastById = _orderRepository.GetAll().MaxBy(x => x.Id);

        int id = 1;

        if (lastById != null)
        {
            id = lastById.Id + 1;
        }
        var order = new Order
        {
            Id = id,
            Name = orderCreate.Name,
        };

        // Поиск пользователя по ID
        var userToAdd = _userRepository.GetAll().Find(user => user.Id == orderCreate.UserId);

        if (userToAdd == null)
        {
            throw new Exception("Пользователь не найден!!!");
        }

        order.User = userToAdd;

        // Поиск предмета в репозитории по ID
        var itemToAdd = _itemRepository.GetAll().Where(x=>orderCreate.ItemsIds.Contains(x.Id));

        if (itemToAdd != null)
        {
            order.Items.AddRange(itemToAdd);
        }
        


        _orderRepository.Add(order);
        return order.Id;
    }
    public List<OrderOutput> GetAll()
    {
        var orders = _orderRepository.GetAll();

        return orders.Select(order => new OrderOutput(order.Id, order.Name)).ToList();
    }
}