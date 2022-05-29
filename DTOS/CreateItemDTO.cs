namespace Catalog.Dtos
{
    public record CreateItemDTO
    {
        public string Name { get; init;}
        public decimal Price { get; init; }
    }
}