using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Services.Administration.Categories;
using DigiBugzy.Services.Administration.CustomFields;

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
            //Services
            using var productCategoryFieldService = new ProductCategoryService(_connectionString);
            using var productCustomFieldService = new ProductCustomFieldService(_connectionString);
            using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
            using var customFieldService = new CustomFieldService(_connectionString);
            using var customFieldTypeService = new CustomFieldTypeService(_connectionString);
            

            var results = new List<MappingViewModel>();

            //Collections
            var productCategoryMappings = productCategoryFieldService.GetByProductId(productId);
            var productCustomFieldsMappings = productCustomFieldService.GetByProductId(productId);


            foreach (var productCategoryMapping in productCategoryMappings)
            {
                
                var categoryCustomFieldsMappings = categoryCustomFieldService.GetByCategoryId(productCategoryMapping.CategoryId);
                foreach (var categoryCustomFieldMapping in categoryCustomFieldsMappings)
                {
                    //Do we have this mapping already for the product?
                    var resultItem = results.Where(r => r.EntityMappedToId == categoryCustomFieldMapping.CustomFieldId);
                    if (resultItem.Any()) continue;

                    //No productCustomField mapping yet, so lets add one to the results
                    var customField = categoryCustomFieldMapping.CustomField ??= customFieldService.GetById(categoryCustomFieldMapping.CustomFieldId);
                    var customFieldType = categoryCustomFieldMapping.CustomField.CustomFieldType ??= customFieldTypeService.GetById(categoryCustomFieldMapping.CustomField.CustomFieldTypeId);
                    
                    var viewModel = new MappingViewModel
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = 1,
                        EntityMappedFromId = productId,
                        EntityMappedToId = customField.Id,
                        Name = customField.Name,
                        TypeName = customFieldType.Name,
                        TypeId = customFieldType.Id,
                        IsMapped = false,
                        CustomFieldValue = null,
                    };

                    var productCustomFieldMapping = productCustomFieldsMappings.FirstOrDefault(x => x.CustomFieldId == customField.Id);
                    if (productCustomFieldMapping == null)
                    {
                        viewModel.IsMapped = false;
                        productCustomFieldService.Create(new ProductCustomField()
                        {
                            CreatedOn = DateTime.Now,
                            CustomFieldId = customField.Id,
                            DigiAdminId = customField.DigiAdminId,
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = productId
                        });   

                    }
                    else
                    {
                        viewModel.IsMapped = true;
                        if(productCustomFieldMapping.ValueString != null) viewModel.CustomFieldValue = productCustomFieldMapping.ValueString;
                    }

                    results.Add(viewModel);
                }
            }


            return results;



        }

        #endregion


        #region Commands

        public void Create(ProductCustomField entity)
        {
            dbContext.ProductCustomFields.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id, bool hardDelete)
        {
            Delete(GetById(id), hardDelete);
           
            
        }

        /// <inheritdoc />
        public void Delete(ProductCustomField entity, bool hardDelete)
        {
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

        

        /// <inheritdoc />
        public void Delete(List<ProductCustomField> entities, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.ProductCustomFields.RemoveRange(entities);
                dbContext.SaveChanges();
            }
            else
            {
                foreach (var entity in entities)
                {
                    Delete(entity, false);
                }
            }
        }


        public void Update(ProductCustomField entity)
        {
            var item = dbContext.ProductCustomFields.FirstOrDefault(x =>
                x.ProductId == entity.ProductId && x.CustomFieldId == entity.CustomFieldId);
            if (item == null) return;
            item.ValueString = entity.ValueString;

            dbContext.ProductCustomFields.Update(item);
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
