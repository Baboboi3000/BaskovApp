namespace Core.Entities;

public class Order
{
    public int Id { get; set; }
      
    

    public List<Order> Orders { get; set; }
}

