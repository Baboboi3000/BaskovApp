using Core.Handlers;
using System.ComponentModel.Design;

IBaskovRepository baskovRepository = new BaskovMemoryRepository();
BaskovHandler baskovHandler = new(baskovRepository);

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
            Console.WriteLine($"{item.Name} {item.Age} {item.Created}");
        }
    }
    else if (action == "users create")
    {
        Console.WriteLine("Введите имя и возраст");
        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        var baskovInput = new BaskovInput(name, age);

        baskovHandler.AddBaskov(baskovInput);
    }
    else if (action == "users delite")
    {
        
    }
    else
    {
        Console.WriteLine("ебобо?");
        continue;
    }
    Console.WriteLine();
}
