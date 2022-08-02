using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Services.Administration.Categories;
using Microsoft.EntityFrameworkCore;

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

        #region Requests

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

        /// <inheritdoc />
        public List<MappingViewModel> GetMappingViewModels(int productId)
        {
            using var productCustomFieldService = new ProductCustomFieldService(_connectionString);
            var mappings =
                dbContext.ProductCustomFields
                    .Where(p => p.ProductId == productId)
                    .Include(x => x.CustomField).ToList();

            return mappings.Select(
                m => new MappingViewModel
                {
                    Id = m.Id,
                    Name = m.CustomField.Name,
                    DigiAdminId = m.ProductId,
                    CreatedOn = m.CreatedOn,
                    CustomFieldValue = m.Value,
                    EntityMappedToId = m.CustomFieldId,
                    EntityMappedFromId = m.ProductId,
                    IsDeleted = false,
                    IsActive = true
                }).ToList();


        }

        #endregion


        #region Commands

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



        public void CreateCustomFieldMappings(int productId)
        {

            //Services
            using var productCategoryService = new ProductCategoryService(_connectionString);
            using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
            using var productCustomFieldService = new ProductCustomFieldService(_connectionString);

            //Get product custom fields (current)
            var productCustomFields = productCustomFieldService.GetMappingViewModels(productId);

            //Get product-category mappings
            var productCategoryMaps = productCategoryService.GetByProductId(productId);
            foreach (var productCategoryMap in productCategoryMaps)
            {

                //Get all category-customfield mappings
                var categoryCustomFieldMaps = categoryCustomFieldService.GetByCategoryId(productCategoryMap.CategoryId);
                foreach (var categoryCustomFieldMap in categoryCustomFieldMaps)
                {
                    //is product already mapped?
                    var ismapped =
                        productCustomFields.FirstOrDefault(pc => pc.EntityMappedToId == categoryCustomFieldMap.CustomFieldId);
                    if (ismapped == null)
                    {
                        //Not found, create a mapping
                        productCustomFieldService.Create(new ProductCustomField()
                        {
                            CreatedOn = DateTime.Now,
                            CustomFieldId = categoryCustomFieldMap.CustomFieldId,
                            DigiAdminId = productCategoryMap.DigiAdminId,
                            IsDeleted = false,
                            IsActive = true,
                            ProductId = productId
                        });
                    }
                }
            }
        }

        /// <inheritdoc />
        public void HandleCustomFieldMapping(int categoryId, int customFieldId, bool isMapped)
        {
            throw new NotImplementedException();
        }

        #endregion


        #endregion
    }
}
