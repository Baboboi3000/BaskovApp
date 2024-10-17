using Core.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace Core.Entities;

public record OrderCreate(string Name, int ItemId, int UserId);
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
        _orderRepository.Add(order);
        int userId;
        if (int.TryParse(Console.ReadLine(), out userId))
        {
            // Поиск пользователя по ID
            var userToAdd = _userRepository.GetAll().Find(user => user.Id == id);

            if (userToAdd != null)
            {
                order.Users.Add(userToAdd);
            }
        }
        int itemId;
        if (int.TryParse(Console.ReadLine(), out itemId))
        {
            // Поиск предмета в репозитории по ID
            var itemToAdd = _itemRepository.GetAll().Find(item => item.Id == id);

            if (itemToAdd != null)
            {
                order.Items.Add(itemToAdd);
            }
        }
            return order.Id;
    }
    public List<OrderOutput> GetAll()
    {
        var orders = _orderRepository.GetAll();

        return orders.Select(order => new OrderOutput(order.Id, order.Name)).ToList();
    }
}