using Core.Repositories;

namespace Infrastructure.Repositories;

public class OrderMemoryRepository : IOrderRepository
{
    private readonly JsonContext _context;

    public OrderMemoryRepository(JsonContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public List<Order> GetAll()
    {
        return _context.Orders;
    }
}