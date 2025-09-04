namespace Core.Concretes.Entities.Showroom
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public required string Key { get; set; }
        public required string Value { get; set; }
        public required int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
