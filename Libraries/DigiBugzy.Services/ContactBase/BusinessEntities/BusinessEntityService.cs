
using DigiBugzy.Core.Domain.BusinessEntities;

namespace DigiBugzy.Services.ContactBase.BusinessEntities
{
    public class BusinessEntityService: BaseService, IBusinessEntityService
    {
        #region Constructor

        /// <inheritdoc />
        public BusinessEntityService(string connectionString) : base(connectionString)
        {
        }

        #endregion

        /// <inheritdoc />
        public BusinessEntity GetById(int id, bool loadComplete = false)
        {
            var entity = dbContext.BusinessEntities.FirstOrDefault(x => x.Id == id);

            //if (loadComplete)
            //{
            //    entity = loadComplete(entity);
            //}

            return entity;
        }

        /// <inheritdoc />
        public List<BusinessEntity> Get(StandardFilter filter, bool loadComplete = false)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Delete(int id, bool hardDelete)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Delete(BusinessEntity entity, bool hardDelete)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Delete(List<BusinessEntity> entities, bool hardDelete)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Update(BusinessEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Create(BusinessEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
