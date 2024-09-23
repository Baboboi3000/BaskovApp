using Core.Handlers;
using Core.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace App
{
    public class ItemsApp
    {
        public static void Sisa()
        {
            JsonContext memoryContext = JsonContext.GetInstance();

            IItemRepository itemRepository = new ItemMemoryRepository(memoryContext);

            ItemHandler itemHandler = new(itemRepository);

            while (true)
            {
                var action = Console.ReadLine().ToLower().Trim();

                if (action == "items add")
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
                    foreach (var item in items)
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
        }
    }
}
