namespace Core.Concretes.DTOs.Warehouse
{
    public class CategoryListItem
    {
        public int Id { get; set; }
        //null!: Buraya boş bir veri gelmeyeceği yazılımcı tarafından garanti ediliyor.
        public string Name { get; set; } = null!;
    }
}
