namespace Core.Concretes.DTOs.Warehouse
{
    public class SubCategoryListItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CategoryListItem ParentCategory { get; set; } = null!;
    }
}
