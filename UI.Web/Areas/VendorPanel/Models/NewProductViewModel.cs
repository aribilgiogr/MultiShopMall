using System.ComponentModel.DataAnnotations;

namespace UI.Web.Areas.VendorPanel.Models
{
    public class NewProductViewModel
    {
        [Display(Name = "Product Name", Prompt = "Product Name"), Required, MinLength(5)]
        public string Name { get; set; } = null!;

        [Display(Name = "Product Description", Prompt = "Product Description"), MinLength(25), DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Product List Price", Prompt = "Product List Price"), Required]
        public decimal Price { get; set; }

        [Display(Name = "Product Discount Rate", Prompt = "Product Discount Rate"), Required, Range(0, 100)]
        public decimal Discount { get; set; }

        [Display(Name = "Product Category", Prompt = "Product Category"), Required]
        public int SubCategoryId { get; set; }

        [Display(Name = "Product Brand", Prompt = "Product Brand"), Required]
        public int BrandId { get; set; }

        [Display(Name = "Product Model", Prompt = "Product Model"), Required]
        public int ProductModelId { get; set; }

        [Display(Name = "Product Thumbnail Image", Prompt = "Product Thumbnail Image"), Required, DataType(DataType.Upload)]
        public IFormFile Thumbnail { get; set; } = null!;

        public IEnumerable<IFormFile> Images { get; set; } = [];
        public Dictionary<string, string> Attributes { get; set; } = [];
    }
}
