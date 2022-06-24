
namespace DigiBugzy.Domain.Entities.xBase.Interfaces
{
    public interface IBaseDigiAdminEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

    }
}
