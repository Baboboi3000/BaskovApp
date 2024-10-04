namespace Core.Entities;

public class Order
{
    public int Id { get; set; }
      
    public User User { get; set; }
    public List<Item> Items { get; set; }

}

