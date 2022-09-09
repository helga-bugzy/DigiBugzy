
using DigiBugzy.Core.Domain.Projects;
using DigiBugzy.Core.Enumerations;
using DigiBugzy.Services.Administration.Categories;
using DigiBugzy.Services.Administration.CustomFields;
using DigiBugzy.Services.Catalog.Products;
using DigiBugzy.Services.Catalog.Stock;
using DigiBugzy.Services.Projects;

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
                case SampleDataTypeEnum.Projects:
                    CreateProjects();
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
                        Name = $"Sample Field {i} - {Enum.GetName(typeof(CustomFieldTypeEnumeration), item)}",
                        Description = "Sample Custom Field",
                        CustomFieldTypeId = (int)item,
                        ClassificationId = _classificationId,
                    };
                    cfield.Id = customFieldService.Create(cfield);

                    if ((int)item != (int)CustomFieldTypeEnumeration.ListType) continue;
                    for (var o = 0; o <= 3; o++)
                    {
                        var option = new CustomFieldListOption
                        {
                            IsActive = true,
                            IsDeleted = false,
                            CreatedOn = DateTime.Now,
                            DigiAdminId = _digiAdminId,
                            CustomFieldId = cfield.Id,
                            Value = $"Option {o} for {cfield.Name}"
                        };

                        option.Id = customFieldListOptionService.Create(option);
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
                    Name = $"Sample Category {p}",
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
                        Name = $"Sample Child Category {p}",
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
                            Name = $"Sample Child Sub Category {p}",
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
                //Parent product
                var product = new Product
                {
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    DigiAdminId = _digiAdminId,
                    Name = $"Sample product {p}",
                    Description = "Sample product",
                    QuantityReserved = 0D,
                    QuantityOnOrder = 0D,
                    TotalInStock = 0D,
                    TotalValue = 0D
                    
                };
                product.Id = productService.Create(product);

                //Child products
                for (var c = 0; c <= 3; c++)
                {
                    var child = new Product
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = _digiAdminId,
                        Name = $"Sample child {p}-{c}",
                        Description = "Sample child product",
                        ParentId = product.Id
                    };

                    child.Id = productService.Create(child);
                    //var date = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: DateTime.Now.Hour, minute: DateTime.Now.Minute, second: DateTime.Now.Second, DateTimeKind.Utc);
                    var stockJournalService = new StockJournalService(_connectionString);
                    stockJournalService.Create(new()
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        EntryDate = DateTime.Now,
                        DigiAdminId = _digiAdminId,
                        Name = "Journal Entry",
                        Description = "Opening stock balance",
                        QuantityIn = c + 1,
                        QuantityOnOrder = double.Parse(s: 0.ToString()),
                        QuantityOut = double.Parse(s: 0.ToString()),
                        QuantityReserved = double.Parse(s: 0.ToString()),
                        TotalInStock = double.Parse(s: 0.ToString()),
                        TotalValue = double.Parse(s: 0.ToString()),
                        ProductId = child.Id,
                        Price = double.Parse(s: (c + 100).ToString()),
                        ProjectSectionPartId = null,
                        Supplier = null
                    });
                }
                
            }
        }

        /// <summary>
        /// Creates projects with sections and parts in the sections
        /// </summary>
        private void CreateProjects()
        {
            using var projectService = new ProjectService(_connectionString);
            using var projectSectionService = new ProjectSectionService(_connectionString);
            using var projectSectionPartService = new ProjectSectionPartService(_connectionString);

            //Projects
            for(var p = 1; p <= 10; p++)
            {
                var project = new Project
                {
                    IsActive = true,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    DigiAdminId = _digiAdminId,
                    Name = $"Sample project {p}",
                    Description = "Sample project",
                };

                project.Id = projectService.Create(project);

                for(var s = 1; s <= 5; s++)
                {
                    var projectSection = new ProjectSection
                    {
                        IsActive = true,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        DigiAdminId = _digiAdminId,
                        Name = $"Sample Project {p} - Section {s}",
                        Description = "Sample project section",
                        ProjectId = project.Id
                    };
                    projectSection.Id = projectSectionService.Create(projectSection);

                    for (var psp = 1; psp <= 20; psp++)
                    {
                        var projectSectionPart = new ProjectSectionPart
                        {
                            IsActive = true,
                            IsDeleted = false,
                            CreatedOn = DateTime.Now,
                            DigiAdminId = _digiAdminId,
                            Name = $"Sample Project {p} - Section {s} - Part {psp}",
                            Description = "Sample project section part",
                            ProjectSectionId = projectSection.Id
                        };

                        projectSectionPartService.Create(projectSectionPart);
                    }

                }
            }
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
            using var customFieldOptionsService = new CustomFieldListOptionService(_connectionString);
           

            //Custom Fields
            var customFields = customFieldService.Get(new StandardFilter
            {
                DigiAdminId = _digiAdminId,
                Name = "Sample",
                LikeSearch = true,
                ClassificationId = _classificationId,
                
            });

            foreach (var customField in customFields)
            {
                //Category Mappings
                categoryCustomFieldService.Delete(categoryCustomFieldService.GetByCustomFieldId(customField.Id), true);

                //Product Mappings
                productCustomFieldService.Delete(productCustomFieldService.GetByCustomFieldId(customField.Id), true);

                //Custom Field
                customFieldOptionsService.Delete(customFieldOptionsService.GetForCustomFieldId(customField.Id), true);
                customFieldService.Delete(customField, true);
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
                    ClassificationId = _classificationId,
                    DigiAdminId = _digiAdminId,
                    OnlyParents = true
                }) ;
            foreach (var category in categories)
            {
                DeleteCategoryRecursive(category.Id);
                
                //Custom field mappings
                categoryCustomFieldService.Delete(categoryCustomFieldService.GetByCategoryId(category.Id), true);

                //Product field mappings
                productCategoryService.Delete(productCategoryService.GetByCategoryId(category.Id), true);

                //Category
                categoryService.Delete(category, true);
            }
        }

        private void DeleteCategoryRecursive(int parentId)
        {
            using var categoryService = new CategoryService(_connectionString);
            using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
            using var productCategoryService = new ProductCategoryService(_connectionString);

            var categories = categoryService.Get(
                new StandardFilter
                {
                    ParentId = parentId,
                });

            foreach (var category in categories)
            {
                
                DeleteCategoryRecursive(category.Id);

                //Custom field mappings
                categoryCustomFieldService.Delete(categoryCustomFieldService.GetByCategoryId(category.Id), true);

                //Product field mappings
                productCategoryService.Delete(productCategoryService.GetByCategoryId(category.Id), true);

                //Category
                categoryService.Delete(category, true);
            }
        }

        private void DeleteProducts()
        {
            using var productService = new ProductService(_connectionString);
            using var productCategoryService = new ProductCategoryService(_connectionString);
            using var productCustomfieldService = new ProductCustomFieldService(_connectionString);

            var products = productService.Get(new StandardFilter
            {
                Name = "Sample",
                LikeSearch = true
            });

            foreach (var product in products)
            {
                try
                {
                    //Stock
                    var stock = dbContext.StockJournals.Where(s => s.ProductId == product.Id).ToList();
                    foreach (var item in stock)
                    {
                        dbContext.StockJournals.Remove(item);
                        dbContext.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

                //Categories
                productCategoryService.Delete(productCategoryService.GetByProductId(product.Id), true);
                
                //CustomFields
                productCustomfieldService.Delete(productCustomfieldService.GetByProductId(product.Id), true);

                //Product
                productService.Delete(product, true);
            }
        }

        private void DeleteProjects()
        {
            using var projectService = new ProjectService(_connectionString);
            using var projectSectionService = new ProjectSectionService(_connectionString);
            using var projectSectionPartService = new ProjectSectionPartService(_connectionString);

            var projects = projectService.Get(new StandardFilter { Name = "Sample", LikeSearch = true });
            foreach (var project in projects)
            {
                var sections = projectSectionService.GetByProjectId(project.Id);
                foreach(var section in sections)
                {
                    var parts = projectSectionPartService.GetByProjectSectionId(section.Id);
                    foreach(var part in parts)
                    {
                        projectSectionPartService.Delete(part.Id, true);
                    }

                    projectSectionService.Delete(section.Id, true);
                }

                projectService.Delete(project.Id, true);  
            }
        }


        #endregion
    }
}
