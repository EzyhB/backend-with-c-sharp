using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepo
    {
        private readonly List<Item> items = new()
        {
            new Item { Id= Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id= Guid.NewGuid(), Name = "Diamond Sword", Price = 100, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id= Guid.NewGuid(), Name = "Wooden Shield", Price = 19, CreatedDate = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}