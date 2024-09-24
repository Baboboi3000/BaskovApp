using App;
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

Console.WriteLine("Пользователи - users");
Console.WriteLine("Создать пользователя - create");
Console.WriteLine("Удалить пользователя - delete");
Console.WriteLine("Получить всех пользователей - get");
Console.WriteLine("Предметы - items");
Console.WriteLine("Добавить предмет - add");
Console.WriteLine("Получить все предметы - get");
Console.WriteLine("Добавить предмет к пользователю - add users");
Console.ReadLine();
UsersApp.Pipisa();   // тут я пытался вызвать методы из ItemApp и UserApp
ItemsApp.Sisa();
