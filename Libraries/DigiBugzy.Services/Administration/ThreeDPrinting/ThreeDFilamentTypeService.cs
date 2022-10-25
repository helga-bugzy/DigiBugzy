using DigiBugzy.Core.Domain.Administration.ThreeDPrinting;

namespace DigiBugzy.Services.Administration.ThreeDPrinting
{
    public class ThreeDFilamentTypeService : BaseService, IThreeDFilamentTypeService
    {
        #region Ctor

        /// <inheritdoc />
        public ThreeDFilamentTypeService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Requests


        /// <inheritdoc />
        public ThreeDFilamentType GetById(int id)
        {
            return dbContext.ThreeDFilamentTypes.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ThreeDFilamentType> Get(StandardFilter filter)
        {
            var query = dbContext.ThreeDFilamentTypes.AsQueryable<ThreeDFilamentType>();

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
            var entity = GetById(id);
            if (entity == null) return;

            if (hardDelete)
            {
                dbContext.ThreeDFilamentTypes.Remove(entity);
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
        public void Update(ThreeDFilamentType entity)
        {
            dbContext.ThreeDFilamentTypes.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Create(ThreeDFilamentType entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0)
                Update(entity);
            else
                dbContext.ThreeDFilamentTypes.Add(entity);

            dbContext.SaveChanges();
        }

        #endregion
    }
}
