// Creating catalog(document name) entities(the name of the thing were making)
namespace Catalog.Entities
{
    // creating a public record called Item, which has the properties of Id, Name, Price, CreateDAte
    public record Item
    {
        public Guid Id { get; init;}
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}