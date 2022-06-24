namespace DigiBugzy.Domain.Entities.Administration.Categories
{
    [Table(name: nameof(Category), Schema = DatabaseConstants.Schemas.Admin)]
    public abstract class Category: BaseAdministrationEntity, IBaseClassificationIncludeEntity, IBaseParentIncludeEntity
    {
        public int ClassificationId { get; set; }

        public int? ParentId { get; set; }


        [ForeignKey(nameof(ClassificationId))]
        public Classification Classification { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Category Parent { get; set; }
        
    }
}
