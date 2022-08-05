﻿using DigiBugzy.Core.Domain.xBase;
using DigiBugzy.Services.Administration.Categories;
using Microsoft.EntityFrameworkCore;

namespace DigiBugzy.Services.Administration.CustomFields
{
    public class CustomFieldService : BaseService, ICustomFieldService
    {
        #region Fields



        #endregion

        #region Ctor

        public CustomFieldService(string connectionString) : base(connectionString)
        {

        }

        #endregion

        #region Public Methods


        /// <inheritdoc />
        public List<CustomField> Get(StandardFilter filter)
        {
            var query = dbContext.CustomFields.AsQueryable<CustomField>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue)
            {
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);
            }
            

            if (filter.ClassificationId.HasValue)
            {
                query = query.Where(x => x.ClassificationId == filter.ClassificationId);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = filter.LikeSearch ? query.Where(x => x.Name.Contains(filter.Name)) : query.Where(x => x.Name.Equals(filter.Name));
            }

            if (!filter.IncludeDeleted)
                query = query.Where(x => x.IsDeleted == false);

            if (!filter.IncludeInActive)
                query = query.Where(x => x.IsActive == true);

            
            return query
                .Include(cft => cft.CustomFieldType)                
                .ToList();


        }

        /// <inheritdoc />
        public List<MappingViewModel> GetCategoryMappings(int customFieldId, int classificationId)
        {
            var results = new List<MappingViewModel>();
            if (customFieldId <= 0 || classificationId <= 0) return results;

            //Get categories
            using var categoryService = new CategoryService(_connectionString);
            var categories = categoryService.Get(new StandardFilter { ClassificationId = classificationId });

          foreach (var category in categories)
            {
                var result = new MappingViewModel
                {
                    Name = category.Name,
                    IsMapped = false,
                    EntityMappedToId = category.Id,
                    EntityMappedFromId = customFieldId,
                    ParentId =category.ParentId
                };

                if (category.CustomFieldMappings == null)
                {
                    using var categoryCustomFieldService = new CategoryCustomFieldService(_connectionString);
                    category.CustomFieldMappings = categoryCustomFieldService.GetByCategoryId(customFieldId);
                }

                var mapping = category.CustomFieldMappings.FirstOrDefault(x =>
                    x.CustomFieldId == customFieldId && category.IsDeleted == false && category.IsActive);
                if (mapping != null && mapping.CategoryId == customFieldId)
                {
                    result.IsMapped = true;
                }

                results.Add(result);
            }

            return results;

        }

        /// <inheritdoc />
        public List<CustomField> Get(List<int> ids)
        {
            return dbContext.CustomFields.Where(x => ids.Contains(x.Id)).ToList();
        }


        /// <inheritdoc />
        public CustomField GetById(int id)
        {
            return dbContext.CustomFields.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />

        #region Commands

        public int Create(CustomField entity)
        {
            
            var filter = new StandardFilter
            {
                Name = entity.Name,
                ClassificationId = entity.ClassificationId
            };
            var current = Get(filter);

            if (current.Count > 0)
            {
                entity.Id = current[0].Id;
                Update(entity);
                return entity.Id;
            }

            dbContext.CustomFields.Add(entity);
            dbContext.SaveChanges();

            if (entity.CustomFieldTypeId == 7)
            {
                var option = new CustomFieldListOption
                {
                    CreatedOn = DateTime.Now,
                    CustomFieldId = entity.Id,
                    DigiAdminId = entity.DigiAdminId,
                    IsDeleted = false,
                    IsActive = true,
                    Value = @"Default Option"
                };

                dbContext.CustomFieldListOptions.Add(option);
                dbContext.SaveChanges();
            }

            return entity.Id;
        }

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {
            Delete(GetById(id), hardDelete);
        }

        /// <inheritdoc />
        public void Delete(CustomField entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.CustomFields.Remove(entity);
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
        public void Delete(List<CustomField> entities, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.CustomFields.RemoveRange(entities);
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

        /// <inheritdoc />
        public void Update(CustomField entity)
        {
            //var filter = new StandardFilter
            //{
            //    Name = entity.Name,
            //};

            //TODO check for duplicate


            dbContext.CustomFields.Update(entity);
            dbContext.SaveChanges();
        }

        #endregion

        #endregion
    }
}
