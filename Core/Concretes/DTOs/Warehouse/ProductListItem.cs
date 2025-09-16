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
    public class ProductDetail { }
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
    public class EditProduct { }
    public class CategoryListItem
    {
        public int Id { get; set; }
        //null!: Buraya boş bir veri gelmeyeceği yazılımcı tarafından garanti ediliyor.
        public string Name { get; set; } = null!;
    }
    public class SubCategoryListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CategoryListItem ParentCategory { get; set; } = null!;
    }
    public class BrandListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
    }
    public class ModelListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
