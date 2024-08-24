using Core.Entities;
using Core.Handlers;
using System.ComponentModel.Design;
var user1 = new User
{
    Id = 1,
    Age = 2,
};
var user2 = new User
{
    Id = 1,
    Age = 2,
};
var equal = user1.Equals(user2);
var equal2 = user1 == user2;

IUserRepository userRepository = new UserMemoryRepository();
UserHandler baskovHandler = new(userRepository);

Console.WriteLine("Пользователи - users");
Console.WriteLine("Создать пользователя - create");
Console.WriteLine("Удалить пользователя - delete");
Console.WriteLine("Получить всех пользователей - get");
while (true)
{
    var action = Console.ReadLine().ToLower().Trim();
    Console.WriteLine();

    if (action == "users get")
    {
        var baskov = baskovHandler.GetAll();
        if (baskov == null || baskov.Count == 0)
        {
            Console.WriteLine("Пользователей нет");
            Console.WriteLine();
            continue;
        }
        foreach (var item in baskov)
        {
            Console.WriteLine($"Id: {item.Id} Имя: {item.Name} Возраст: {item.Age} Время создания: {item.Created}");
        }
    }
    else if (action == "users create")
    {
        Console.WriteLine("Введите имя и возраст");
        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        var baskovInput = new UserInput(name, age);

        baskovHandler.AddUser(baskovInput);
    }
    else if (action == "users delete")
    {
        Console.WriteLine("Введите Id");
        var id = int.Parse(Console.ReadLine());

        var baskovDelete = new UserDelete(id);

        baskovHandler.DeliteUser(baskovDelete);
    }
    else
    {
        Console.WriteLine("ебобо?");
        continue;
    }
    Console.WriteLine();
}
