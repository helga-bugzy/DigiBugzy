
using DigiBugzy.Core.Enumerations;
using DigiBugzy.Services.Administration.Categories;
using DigiBugzy.Services.Administration.CustomFields;
using DigiBugzy.Services.Catalog.Products;

namespace DigiBugzy.Services.SampleData
{
    public class SampleDataService:BaseService, ISampleDataService
    {
        private readonly SampleDataTypeEnum _sampleDataType;
        private readonly int _classificationId;
        private readonly int _digiAdminId;


        #region Ctor

        public SampleDataService(string connectionString, SampleDataTypeEnum sampleDataType, int classificationId = 0, int digiAdminId = 1) : base(connectionString)
        {
            _sampleDataType = sampleDataType;
            _classificationId = classificationId;
            _digiAdminId = digiAdminId;
        }

        #endregion

        #region Create


        /// <inheritdoc />
        public void CreateSampleData()
        {
            switch (_sampleDataType)
            {
                case SampleDataTypeEnum.Categories:
                    CreateCategories();
                    break;
                case SampleDataTypeEnum.CustomFields:
                    CreateCustomFields();
                    break;
                case SampleDataTypeEnum.Products:
                    CreateProducts();
                    break;
            }
        }

        private void CreateCustomFields()
        {
            using var customFieldService = new CustomFieldService(_connectionString);
            using var customFieldListOptionService = new CustomFieldListOptionService(_connectionString);

            foreach (var item in Enum.GetValues(typeof(CustomFieldTypeEnumeration)))
            {
                for (var i = 0; i <= 5; i++)
                {
                    var cfield = new CustomField
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = _digiAdminId,
                        Name = @$"Sample Field {i} - {Enum.GetName(typeof(CustomFieldTypeEnumeration), item)}",
                        Description = "Sample Custom Field",
                        CustomFieldTypeId = (int)item,
                        ClassificationId = _classificationId,
                    };
                    cfield.Id = customFieldService.Create(cfield);

                    if ((int)item == (int)CustomFieldTypeEnumeration.ListType)
                    {
                        for (var o = 0; o <= 3; o++)
                        {
                            var option = new CustomFieldListOption
                            {
                                IsActive = true,
                                IsDeleted = false,
                                CreatedOn = DateTime.Now,
                                DigiAdminId = _digiAdminId,
                                CustomFieldId = cfield.Id,
                                Value = $@"Option {o} for {cfield.Name}"
                            };

                            option.Id = customFieldListOptionService.Create(option);
                        }

                    }
                }
            }

        }

        private void CreateCategories()
        {
            using var categoryService = new CategoryService(_connectionString);
            for (var p = 0; p < 11; p++)
            {
                var parent = new Category
                {
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    DigiAdminId = _digiAdminId,
                    Name = $@"Sample Category {p}",
                    Description = "Sample",
                    ClassificationId = _classificationId,
                    CustomFieldMappings = null
                };
                parent.Id = categoryService.Create(parent);

                for (var c = 0; c < 4; c++)
                {
                    var child = new Category
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = _digiAdminId,
                        Name = $@"Sample Child Category {p}",
                        Description = "Sample",
                        ClassificationId = _classificationId,
                        ParentId = parent.Id
                    };
                    child.Id = categoryService.Create(child);

                    for (var cc = 0; cc < 2; cc++)
                    {
                        var schild = new Category
                        {
                            IsActive = true,
                            IsDeleted = false,
                            CreatedOn = DateTime.Now,
                            DigiAdminId = _digiAdminId,
                            Name = $@"Sample Child Sub Category {p}",
                            Description = "Sample",
                            ClassificationId = _classificationId,
                            ParentId = child.Id

                        };
                        schild.Id = categoryService.Create(schild);
                    }
                }

            }
        }

        private void CreateProducts()
        {
            using var productService = new ProductService(_connectionString);
            for (var p = 0; p <= 30; p++)
            {
                var product = new Product
                {
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    DigiAdminId = _digiAdminId,
                    Name = $@"Sample product {p}",
                    Description = "Sample product",
                };

                for (var c = 0; c <= 3; c++)
                {
                    var child = new Product
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = _digiAdminId,
                        Name = $@"Sample product {p}",
                        Description = "Sample product",
                        
                    };
                }
                productService.Create(product);
            }
        }

        private void CreateProjects()
        {

        }

        #endregion

        #region Delete


        /// <inheritdoc />
        public void DeleteSampleData()
        {
            switch (_sampleDataType)
            {
                case SampleDataTypeEnum.Categories:
                    DeleteCategories();
                    break;
                case SampleDataTypeEnum.CustomFields:
                    DeleteCustomFields();
                    break;
                case SampleDataTypeEnum.Products:
                    DeleteProducts();
                    break;
                case SampleDataTypeEnum.Projects:
                    DeleteProjects();
                    break;
            }
        }

        

        private void DeleteCustomFields()
        {
            using var customFieldService = new CustomFieldService(_connectionString);
            using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
            using var productCustomFieldService = new ProductCustomFieldService(_connectionString);
           

            //Custom Fields
            var customFields = customFieldService.Get(new StandardFilter
            {
                DigiAdminId = _digiAdminId,
                Name = "Sample",
                LikeSearch = true,
                ClassificationId = _classificationId
            });

            foreach (var customField in customFields)
            {
                //Category Mappings
                dbContext.CategoryCustomFields.RemoveRange(categoryCustomFieldService.GetByCustomFieldId(customField.Id));

                //Product Mappings
                dbContext.ProductCustomFields.RemoveRange(productCustomFieldService.GetByCustomFieldId(customField.Id));

                //Custom Fields
                customFieldService.Delete(customField.Id, true);
            }
        }

        private void DeleteCategories()
        {
            using var categoryService = new CategoryService(_connectionString);
            using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
            using var productCategoryService = new ProductCategoryService(_connectionString);


            var categories = categoryService.Get(
                new StandardFilter
                {
                    Name = "Sample",
                    LikeSearch = true,
                    ClassificationId = _classificationId
                });
            foreach (var category in categories)
            {
                //Custom field mappings
                dbContext.CategoryCustomFields.RemoveRange(categoryCustomFieldService.GetByCategoryId(category.Id));

                //Product field mappings
                dbContext.ProductCategories.RemoveRange(productCategoryService.GetByCategoryId(category.Id));


                //Category
                categoryService.Delete(category.Id, true);
            }
        }

        private void DeleteProducts()
        {

        }

        private void DeleteProjects()
        {

        }


        #endregion
    }
}
