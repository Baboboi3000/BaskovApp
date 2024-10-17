namespace Core.Repositories;

public interface IOrderRepository
{
    void Add(Order order); 

    List<Order> GetAll();
}
