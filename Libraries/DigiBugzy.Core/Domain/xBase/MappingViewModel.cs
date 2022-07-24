
namespace DigiBugzy.Core.Domain.xBase
{
    public class MappingViewModel: BaseEntity
    {
        public int WorkingEntityId { get; set; }

        public int MapToEntityId { get; set; }

        public string Name { get; set; }

        public bool IsMapped { get; set; }
    }
}
