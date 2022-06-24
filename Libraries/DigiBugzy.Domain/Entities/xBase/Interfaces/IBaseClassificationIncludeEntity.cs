namespace DigiBugzy.Domain.Entities.xBase.Interfaces
{
    public interface IBaseClassificationIncludeEntity
    {
        public int ClassificationId { get; set; }

        [ForeignKey(nameof(ClassificationId))]
        public Classification Classification { get; set; }
    }
}
