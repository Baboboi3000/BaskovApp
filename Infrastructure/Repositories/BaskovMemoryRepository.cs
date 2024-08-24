using Core.Repository;

namespace Infrastructure.Repositories;

public class UserMemoryRepository : IUserRepository
{
    private readonly List<User> _user = [];

    public void Add(User user)
    {
        _user.Add(user);
    }

    public List<User> GetAll()
    {
        return _user;
    }
    
    public void Remove(User user)
    {
        _user.Remove(user);
    }
}

