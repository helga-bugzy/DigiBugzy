using DigiBugzy.Core.Domain.Administration.ThreeDPrinting;

namespace DigiBugzy.Services.Administration.ThreeDPrinting
{
    public class ThreeDResolutionService : BaseService, IThreeDResolutionService
    {
        #region Ctor

        /// <inheritdoc />
        public ThreeDResolutionService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        #region Requests


        /// <inheritdoc />
        public ThreeDResolution GetById(int id)
        {
            return dbContext.ThreeDResolutions.FirstOrDefault(x => x.Id == id);
        }

        /// <inheritdoc />
        public List<ThreeDResolution> Get(StandardFilter filter)
        {
            var query = dbContext.ThreeDResolutions.AsQueryable<ThreeDResolution>();

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
                dbContext.ThreeDResolutions.Remove(entity);
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
        public void Update(ThreeDResolution entity)
        {
            dbContext.ThreeDResolutions.Update(entity);
            dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void Create(ThreeDResolution entity)
        {
            var filter = new StandardFilter
            {
                Name = entity.Name
            };
            var current = Get(filter);

            if (current.Count > 0)
                Update(entity);
            else
                dbContext.ThreeDResolutions.Add(entity);

            dbContext.SaveChanges();
        }

        #endregion
    }
}
