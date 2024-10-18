namespace Core.Entities;

public class Order
{
    public int Id { get; set; }

    public string Name {  get; set; }   

    public List<Item> Items { get; set; } = new List<Item>();

    public User User { get; set; }

}

