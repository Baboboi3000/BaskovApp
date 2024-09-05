using Core.Entities;
using Core.Repository;

namespace Infrastructure.Repositories;

public class UserMemoryRepository : IUserRepository
{
    private readonly JsonContext _context;

    public UserMemoryRepository(JsonContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public List<User> GetAll()
    {
        return _context.Users;
    }

    public void Remove(User user)
    {
       return _context.Remove(user);
    }
}

