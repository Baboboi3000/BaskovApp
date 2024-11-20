namespace Core.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override bool Equals(object? obj)
    {
        var other = obj as Item;
        return other.Id == Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
    public static bool operator ==(Item? item1, Item? item2)
    {
        if (item1 is null && item2 is null)
        {
            return true;
        }
        else if (item1 is not null && item2 is not null)
        {
            return item1.Id == item2.Id;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(Item? item1, Item? item2)
    {

        if (item1 is null && item2 is null)
        {
            return false;
        }
        else if (item1 is not null && item2 is not null)
        {
            return item1.Id != item2.Id;
        }
        else
        {
            return true;
        }
    }
}