using System.Collections.Generic;
// importing Catalog entities that we made inside of entities folder
using Catalog.Entities;

// creating Catalog (document name) Repositories(the thing were making)
namespace Catalog.Repositories
{
    // creating a public class names  InMemITemsRepo
    public class InMemItemsRepo
    {
        // creating a private List that will have the scructure of <Item> and with the name items that is read only so we cant edit it
        private readonly List<Item> items = new()
        {
            new Item { Id= Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id= Guid.NewGuid(), Name = "Diamond Sword", Price = 100, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id= Guid.NewGuid(), Name = "Wooden Shield", Price = 19, CreatedDate = DateTimeOffset.UtcNow},
        };

        /*
        Many times there is a need to loop through a collection of classes or lists which are anonymous types. IEnumerable interface is one of the best features of C# language which loops over the collection.

        Key Points:
        -   IEnumerable interface contains the System.Collections.Generic namespace.
        -   IEnumerable interface is a generic interface which allows looping over generic or non-generic lists.
        -   IEnumerable interface also works with linq query expression.
        -   IEnumerable interface Returns an enumerator that iterates through the collection.
        */

        /*Creating a method that returns items(line 12) and items is a List that contains multiple instances of the Item record. To be able to iterate over that, we need the IEmumerable*/
        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        // Creating a method that returns a single Item record from Items where the Id matches with the paramater passed in
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}