
namespace App
{
    public class UsersApp
    {
        JsonContext _memoryContext;

        IUserRepository _userRepository;

        UserHandler _userHandler;
        public UsersApp()
        {
            _memoryContext =  JsonContext.GetInstance();
            _userRepository = new UserMemoryRepository(_memoryContext);
            _userHandler = new(_userRepository);
        }
        public bool Handle(string action)
        {


            if (action == "users get")
            {
                var users = _userHandler.GetAll();
                if (users == null || users.Count == 0)
                {
                    Console.WriteLine("Пользователей нет");
                    Console.WriteLine();
                }
                else
                {
                    foreach (var user in users)
                    {
                        Console.WriteLine($"Id: {user.Id}, Имя: {user.Name}, Возраст {user.Age}, Время создания: {user.Created}");
                    }
                }
                return true;
            }
            else if (action == "users create")
            {
                Console.WriteLine("Введите имя и возраст");
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                var userInput = new UserInput(name, age);

                _userHandler.AddUser(userInput);
                return true;
            }
            else if (action == "users delete")
            {
                Console.WriteLine("Введите Id");
                var id = int.Parse(Console.ReadLine());

                var userDelete = new UserDelete(id);

                _userHandler.DeleteUser(userDelete);
                return true;
            }
            return false;
        }
    }
}
