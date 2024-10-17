namespace Core.Repository;

public interface IUserRepository
{
    void Add(User user);

    List<User> GetAll();

    void Remove(User user);
}

