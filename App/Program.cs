using Core.Handlers;
using System.ComponentModel.Design;

IBaskovRepository baskovRepository = new BaskovMemoryRepository();
BaskovHandler baskovHandler = new(baskovRepository);

while (true)
{
    var action = Console.ReadLine().ToLower().Trim();
    Console.WriteLine();

    if (action == "get")
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
    else if (action == "add")
    {
        Console.WriteLine("Введите имя и возраст");
        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        var baskovInput = new BaskovInput(name, age);

        baskovHandler.AddBaskov(baskovInput);
    }
    else
    {
        Console.WriteLine("ебобо?");
        continue;
    }
    Console.WriteLine();
}
