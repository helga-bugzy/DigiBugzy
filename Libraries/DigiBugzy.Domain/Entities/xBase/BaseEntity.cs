



namespace DigiBugzy.Domain.Entities.xBase
{
    public abstract partial class BaseEntity: IBaseEntity

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

        [Required]
        public int DigiAdminId { get; set; }

        [ForeignKey(nameof(DigiAdminId))]
        public BaseDigiAdminEntity DigiAdmin { get; set; }
    }
}
