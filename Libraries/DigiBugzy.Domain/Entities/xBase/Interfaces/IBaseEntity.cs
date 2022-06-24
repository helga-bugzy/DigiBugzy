

namespace DigiBugzy.Domain.Entities.xBase.Interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public int DigiAdminId { get; set; }
    }
}
