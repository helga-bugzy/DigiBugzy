

namespace DigiBugzy.Core.Domain.xBase.Interfaces
{
    public interface IBaseClassificationMappingEntity
    {
        public int ClassificationId { get; set; }

        public Classification Classification { get; set; }
    }
}
