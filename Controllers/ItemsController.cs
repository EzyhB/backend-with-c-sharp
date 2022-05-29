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
            var items = repository.GetItems().Select( item => item.AsDto());
            return items;
        }

        // Get /items/{id}
        [HttpGet("{id}")]

        // ActionResult allows us to return multiple things from a function, we can return NotFound or item
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            switch (item)
            {
                case null:
                    return NotFound();
                default:
                    return item.AsDto();
            }
        }

        // this will handle the /post to /items
        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO itemDTO)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }
    }
}