using Core.Abstracts.Bases;

namespace Core.Concretes.Entities.Accounts
{
    public class Administrator : BaseEntity
    {
        public required string MemberId { get; set; }
        public virtual Member? Member { get; set; }
    }
}
