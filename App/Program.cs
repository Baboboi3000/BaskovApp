using Core.Handlers;

IBaskovRepository baskovRepository = new BaskovMemoryRepository();
BaskovHandler baskovHandler = new(baskovRepository);

while (true)
{
    var action = Console.ReadLine().ToLower().Trim();
    Console.WriteLine();

    if(action == "get")
    {
        var baskov = baskovHandler.GetAll();
        if (baskov == null || baskov.Count = 0)
        {
            Console.WriteLine("Пользователей нет");
            Console.WriteLine();
            continue;
        }

    }
}
