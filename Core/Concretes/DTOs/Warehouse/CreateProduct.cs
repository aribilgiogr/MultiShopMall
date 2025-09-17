namespace Core.Concretes.DTOs.Warehouse
{
    public class CreateProduct
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductModelId { get; set; }
        public required string Thumbnail { get; set; }
        public int VendorId { get; set; }
        public IEnumerable<string> Images { get; set; } = [];
        public Dictionary<string, string> Attributes { get; set; } = [];
    }
}
