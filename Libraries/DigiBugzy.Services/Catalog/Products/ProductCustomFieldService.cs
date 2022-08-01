

namespace DigiBugzy.Services.Catalog.Products
{
    public class ProductCustomFieldService :BaseService, IProductCustomFieldService
    {
        #region Fields

        #endregion

        #region Ctor

        public ProductCustomFieldService(string connectionString) : base(connectionString)
        {

        }

        #endregion


        #region Methods
        public ProductCustomField GetById(int id)
        {
            return dbContext.ProductCustomFields.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ProductCustomField> GetByProductId(int productId)
        {
            return dbContext.ProductCustomFields.Where(x => x.ProductId == productId).ToList();
        }

        /// <inheritdoc />
        public List<ProductCustomField> GetByCustomFieldId(int CustomFieldId)
        {
            return dbContext.ProductCustomFields.Where(x => x.CustomFieldId == CustomFieldId).ToList();
        }


        public void Create(ProductCustomField entity)
        {
            dbContext.ProductCustomFields.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id, bool hardDelete = false)
        {


            var entity = GetById(id);
            if (entity == null) return;

            if (hardDelete)
            {
                dbContext.ProductCustomFields.Remove(entity);

                dbContext.SaveChanges();
            }
            else
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                Update(entity);
            }


        }



        public void Update(ProductCustomField entity)
        {
            dbContext.ProductCustomFields.Update(entity);
            dbContext.SaveChanges();
        }

        #endregion
    }
}
