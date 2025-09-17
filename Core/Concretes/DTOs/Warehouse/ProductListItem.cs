using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.Warehouse
{
    public class ProductListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string ModelName { get; set; } = null!;

    }
    public class ProductDetail {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductModelId { get; set; }
        public required string Thumbnail { get; set; }
        public IEnumerable<string> Images { get; set; } = [];
        public Dictionary<string, string> Attributes { get; set; } = [];
    }

    public class EditProduct {
        public int Id { get; set; }
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
