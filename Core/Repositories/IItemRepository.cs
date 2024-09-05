using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IItemRepository
    {
        void Add(Item item);

        List<Item> GetAll();
    }
}
