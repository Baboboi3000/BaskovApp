using Core.Handlers;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class UsersApp   // создать метод
    {
        public static void Pipisa()
        {
            JsonContext memoryContext = JsonContext.GetInstance();

            IUserRepository userRepository = new UserMemoryRepository(memoryContext);

            UserHandler userHandler = new(userRepository);
            while (true)
            {
                var action = Console.ReadLine().ToLower().Trim();


                if (action == "users get")
                {
                    var user = userHandler.GetAll();
                    if (user == null || user.Count == 0)
                    {
                        Console.WriteLine("Пользователей нет");
                        Console.WriteLine();
                        continue;
                    }
                    foreach (var item in user)
                    {
                        Console.WriteLine($"Id: {item.Id} Имя: {item.Name} Возраст: {item.Age} Время создания: {item.Created}");
                    }
                }
                else if (action == "users create")
                {
                    Console.WriteLine("Введите имя и возраст");
                    var name = Console.ReadLine();
                    var age = int.Parse(Console.ReadLine());

                    var userInput = new UserInput(name, age);

                    userHandler.AddUser(userInput);
                }
                else if (action == "users delete")
                {
                    Console.WriteLine("Введите Id");
                    var id = int.Parse(Console.ReadLine());

                    var userDelete = new UserDelete(id);

                    userHandler.DeleteUser(userDelete);
                }
                else
                {
                    Console.WriteLine("ебобо?");
                    continue;
                }
                Console.WriteLine();
            }
        }
    }
}
