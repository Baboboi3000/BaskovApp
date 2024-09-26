using Core.Repositories;

namespace Core.Entities;

public record AddUserAndItemToOrder (int ItemId, int UserId, int OrderId);

public class OrderHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IItemRepository _itemRepository;

    public OrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public void AddUserAndItemToOrder()
    {
        _userRepository.GetAll().First(x => x.Id == 1);
        _itemRepository.GetAll().First(x => x.Id == 1);
        User user = new User();
        Item item = new Item();

        Order order = new Order { Id = 1, User = user };
        order.Items.Add(item);
    }
}