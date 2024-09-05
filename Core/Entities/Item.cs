namespace Core.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Item> Items { get; set; }
}