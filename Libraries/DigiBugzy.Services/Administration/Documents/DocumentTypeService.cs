using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Services.Administration.Documents
{
    public class DocumentTypeService: BaseService, IDocumentTypeService
    {
        #region Ctor

        /// <inheritdoc />
        public DocumentTypeService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        /// <inheritdoc />

        #region Requests

        public DocumentType GetById(int id)
        {
            return dbContext.DocumentTypes.FirstOrDefault(t => t.Id == id);
        }

        /// <inheritdoc />
        public List<DocumentType> Get(StandardFilter filter)
        {
            var query = dbContext.DocumentTypes.AsQueryable<DocumentType>();

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

            return query.ToList();
        }

        #endregion

        #region Commands

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {
            Delete(GetById(id), hardDelete);
        }

        /// <inheritdoc />
        public void Delete(DocumentType entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.DocumentTypes.Remove(entity);
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
        public void Delete(List<DocumentType> entities, bool hardDelete)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(DocumentType entity)
        {
            dbContext.DocumentTypes.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(DocumentType entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0)
            {
                entity.Id = current[0].Id;
                Update(entity);
                return entity.Id;
            }

            dbContext.DocumentTypes.Add(entity);
            dbContext.SaveChanges();


            return entity.Id;
        }

        #endregion
    }
}
