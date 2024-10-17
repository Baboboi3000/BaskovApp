namespace Core.Handlers;

public record UserInput(string Name, int Age);
public record UserOutput(int Id, string Name, int Age, DateTime Created);

public record UserDelete(int Id);

public class UserHandler
{
    private readonly IUserRepository _userRepository;
    public UserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void AddUser(UserInput userInput)
    {
        var lastById = _userRepository.GetAll().MaxBy(x => x.Id);
        int id = 1;

        if (lastById != null)
        {
            id = lastById.Id + 1;
        }
        var user = new User
        {
            Id = id,
            Name = userInput.Name,
            Age = userInput.Age,
            Created = DateTime.UtcNow,
        };
        _userRepository.Add(user);
    }
    public List<UserOutput> GetAll()
    {
        var user = _userRepository.GetAll();
        return user.Select(user => new UserOutput(user.Id, user.Name, user.Age, user.Created)).ToList();
    }
    public void DeleteUser(UserDelete userDelete)
    {
        var user = new User
        {
            Id = userDelete.Id,
        };
        _userRepository.Remove(user);
    }
}

