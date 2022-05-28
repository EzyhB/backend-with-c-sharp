using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using Catalog.Dtos;

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
        private readonly IInMemItemsRepoInterface repository;


        public ItemsController(IInMemItemsRepoInterface repository)
        {   
            // asigning repository to a new instance of InMemItemsRepo using the new contructor
            this.repository = repository;
        }

        // when someone does GET to /items this GetItems will handle that
        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            // we previously assigned repository to an instance of InMemItemsRepo and that had a method to return all items called .GetItems(), we use that here to assign items to items(line 30) by envoking that method repository.GetItems()
            var items = repository.GetItems().Select( item => new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            });
            return items;
        }

        // Get /items/{id}
        [HttpGet("{id}")]

        // ActionResult allows us to return multiple things from a function, we can return NotFound or item
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            switch (item)
            {
                case null:
                    return NotFound();
                default:
                    return item;
            }
        }
    }
}