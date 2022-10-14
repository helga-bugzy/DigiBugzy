
using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Services.Administration.Documents
{
    public class DocumentFileTypeService : BaseService, IDocumentFileTypeService
    {
        #region Ctor

        /// <inheritdoc />
        public DocumentFileTypeService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        /// <inheritdoc />

        #region Requests

        public DocumentFileType GetById(int id)
        {
            return dbContext.DocumentFileTypes.FirstOrDefault(t => t.Id == id);
        }

        /// <inheritdoc />
        public List<DocumentFileType> Get(StandardFilter filter)
        {
            var query = dbContext.DocumentFileTypes.AsQueryable<DocumentFileType>();

            if (filter.Id.HasValue)
            {
                query = query.Where(x => x.Id == filter.Id);
                return query.ToList();
            }

            if (filter.DigiAdminId.HasValue)
            {
                query = query.Where(x => x.DigiAdminId == filter.DigiAdminId);
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
        public void Delete(DocumentFileType entity, bool hardDelete)
        {
            if (hardDelete)
            {
                dbContext.DocumentFileTypes.Remove(entity);
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
        public void Delete(List<DocumentFileType> entities, bool hardDelete)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(DocumentFileType entity)
        {
            dbContext.DocumentFileTypes.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public int Create(DocumentFileType entity)
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

            dbContext.DocumentFileTypes.Add(entity);
            dbContext.SaveChanges();


            return entity.Id;
        }

        #endregion
    }
}
