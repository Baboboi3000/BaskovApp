namespace Core.Entities;

public class Order
{
    public int Id { get; set; }

    public string Name {  get; set; }   

    public List<Item> Items { get; set; }

    public List<User> Users { get; set; }

}

