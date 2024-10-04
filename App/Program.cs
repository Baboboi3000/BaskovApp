
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
var item1 = new Item
{
    Id = 1,
};
var item2 = new Item
{
    Id = 1,
};
var equal3 = item1.Equals(item2);
var equal4 = item1 == item2;

Console.WriteLine("Пользователи - users");
Console.WriteLine("Создать пользователя - create");
Console.WriteLine("Удалить пользователя - delete");
Console.WriteLine("Получить всех пользователей - get");
Console.WriteLine("Предметы - items");
Console.WriteLine("Добавить предмет - add");
Console.WriteLine("Получить все предметы - get");
Console.WriteLine("Удалить предмет - delete");
Console.WriteLine("Добавить предмет к пользователю - add users");
var userApp = new UsersApp();
var itemApp = new ItemsApp();

while (true)
{

    try
    {
        bool isAccess = false;
        var action = Console.ReadLine().ToLower().Trim();

        isAccess = userApp.Handle(action);
        if (isAccess)
            continue;
        isAccess = itemApp.Handle(action);
        if (!isAccess)
        {
            Console.WriteLine("Это была ошибка");
            continue;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("ОШИБКА" + ex.Message);
        continue;
    }
}

