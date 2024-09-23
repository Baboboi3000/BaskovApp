namespace Core.Entities;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Created { get; set; }

    public List<Order> Orders { get; set; }

public override bool Equals(object? obj)
    {
        var other = obj as User;
        return other.Id == Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
    public static bool operator ==(User? user1, User? user2)
    {
        if (user1 is null && user2 is null)
        {
            return true;
        }
        else if (user1 is not null && user2 is not null)
        {
            return user1.Id == user2.Id;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(User? user1, User? user2)
    {

        if (user1 is null && user2 is null)
        {
            return false;
        }
        else if (user1 is not null && user2 is not null)
        {
            return user1.Id != user2.Id;
        }
        else
        {
            return true;
        }
    }

}


