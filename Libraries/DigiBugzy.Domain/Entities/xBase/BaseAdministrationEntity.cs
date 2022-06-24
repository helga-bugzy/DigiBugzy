

namespace DigiBugzy.Domain.Entities.xBase
{
    public abstract class BaseAdministrationEntity: BaseEntity, IAdministrationEntity
    {
        [MaxLength(150), MinLength(5)]
        [Required]
        public string Name { get; set; }

        [MaxLength(150), MinLength(5)]
        public string Description { get; set; }




    }
}
