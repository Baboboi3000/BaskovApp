namespace Core.Entities;

public class Order
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Item> Items { get; set; } = new List<Item>();

    public User User { get; set; }

    public override bool Equals(object? obj)
    {
        var other = obj as Order;
        return other.Id == Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
    public static bool operator ==(Order? order1, Order? order2)
    {
        if (order1 is null && order2 is null)
        {
            return true;
        }
        else if (order1 is not null && order2 is not null)
        {
            return order1.Id == order2.Id;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(Order? order1, Order? order2)
    {

        if (order1 is null && order2 is null)
        {
            return false;
        }
        else if (order1 is not null && order2 is not null)
        {
            return order1.Id != order2.Id;
        }
        else
        {
            return true;
        }
    }

}

