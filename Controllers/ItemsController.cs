using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;

namespace Catalog.Controllers
{
    // declaring this as an API controller
    [ApiController]
    // declaring the route to be /items
    [Route("items")]

    // Creating a public class called ItemsController which inherits from ControllerBase
    public class ItemsController : ControllerBase
    {
        // initialising a private read only repository that is a type of InMemItemsRepo
        private readonly InMemItemsRepo repository;


        public ItemsController()
        {   
            // asigning repository to a new instance of InMemItemsRepo using the new contructor
            repository = new InMemItemsRepo();
        }

        // when someone does GET to /items this GetItems will handle that
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            // we previously assigned repository to an instance of InMemItemsRepo and that had a method to return all items called .GetItems(), we use that here to assign items to items(line 30) by envoking that method repository.GetItems()
            var items = repository.GetItems();
            return items;
        }

        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item;
        }
    }
}