using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs.Warehouse
{
    public class ProductListItem { }
    public class ProductDetail { }
    public class CreateProduct { }
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
