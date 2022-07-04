

namespace DigiBugzy.Core.Domain.xBase
{
    public class BaseAdministrationEntity: BaseEntity, IAdministrationEntity
    {
        [MaxLength(150), MinLength(5)]
        [Required]
        public string Name { get; set; }

        [MaxLength(150), MinLength(5)]
        public string Description { get; set; }




    }
}
