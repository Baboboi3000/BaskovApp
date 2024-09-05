using Core.Entities;
using Core.Handlers;
using Core.Repositories;
using Infrastructure;
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

JsonContext memoryContext = JsonContext.GetInstance();

IUserRepository userRepository = new UserMemoryRepository(memoryContext);
IItemRepository itemRepository = new ItemMemoryRepository(memoryContext);

UserHandler userHandler = new(userRepository);
ItemHandler itemHandler = new(itemRepository);

Console.WriteLine("Пользователи - users");
Console.WriteLine("Создать пользователя - create");
Console.WriteLine("Удалить пользователя - delete");
Console.WriteLine("Получить всех пользователей - get");
Console.WriteLine("Предметы - items");
Console.WriteLine("Добавить предмет - add");
Console.WriteLine("Получить все предметы - get");
Console.WriteLine("Добавить предмет к пользователю - add users");

while (true)
{
    var action = Console.ReadLine().ToLower().Trim();
    Console.WriteLine();

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

        userHandler.DeliteUser(userDelete);
    }
    else if (action == "items add")
    {
        Console.WriteLine("Введите название предмета");
        var name = Console.ReadLine();
        var itemInput = new ItemInput(name);
        var id = itemHandler.AddItem(itemInput);
        Console.WriteLine("Id предмета" + id);
    }
    else if (action == "items get")
    {
        var items = itemHandler.GetAll();
        if (items == null || items.Count == 0)
        {
            Console.WriteLine("Предметов нет");
            Console.WriteLine();
            continue;
        }
        foreach(var item in items)
        {
            Console.WriteLine($"Id: {item.Id}");
        }
    }
    else if (action == "item add users")
    {
        var userId = int.Parse(Console.ReadLine()!);
        var itemId = int.Parse(Console.ReadLine()!);
    }
    else
    {
        Console.WriteLine("ебобо?");
        continue;
    }
    Console.WriteLine();
}
