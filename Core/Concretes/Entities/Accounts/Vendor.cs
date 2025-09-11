using Core.Abstracts.Bases;
using Core.Concretes.Entities.Showroom;

namespace Core.Concretes.Entities.Accounts
{
    public class Vendor : BaseEntity
    {
        public required string StoreName { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public string? Banner { get; set; }

        public required string MemberId { get; set; }
        public virtual Member? Member { get; set; }
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
