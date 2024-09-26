
namespace App
{
    public class UsersApp  
    {
        JsonContext _memoryContext;

        IUserRepository _userRepository;

        UserHandler _userHandler;
        public UsersApp()
        {
            _memoryContext = new JsonContext();
            _userRepository = new UserMemoryRepository(_memoryContext);
            _userHandler = new(_userRepository);
        }
        public bool Pipisa(string action)
        {
           
            while (true)
            {
               
                if (action == "users get")
                {
                    var user = _userHandler.GetAll();
                    if (user == null || user.Count == 0)
                    {
                        Console.WriteLine("Пользователей нет");
                        Console.WriteLine();
                        continue;
                    }
                    
                }
                else if (action == "users create")
                {
                    Console.WriteLine("Введите имя и возраст");
                    var name = Console.ReadLine();
                    var age = int.Parse(Console.ReadLine());

                    var userInput = new UserInput(name, age);

                    _userHandler.AddUser(userInput);
                }
                else if (action == "users delete")
                {
                    Console.WriteLine("Введите Id");
                    var id = int.Parse(Console.ReadLine());

                    var userDelete = new UserDelete(id);

                    _userHandler.DeleteUser(userDelete);
                }
                
            }
        }
    }
}
