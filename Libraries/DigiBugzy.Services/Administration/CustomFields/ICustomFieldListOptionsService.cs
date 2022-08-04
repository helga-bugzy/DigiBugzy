using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBugzy.Services.Administration.CustomFields
{
    public interface ICustomFieldListOptionsService
    {

        /// <summary>
        /// Gets a custom field list option
        /// on hand of its primary key id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomFieldListOption GetById(int id);

        /// <summary>
        /// Gets a custom field list option items for a specific custom field
        /// on hand of its primary key id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<CustomFieldListOption> GetForCustomFieldId(int id);

        

        /// <summary>
        /// Soft/hard deletes an existing custom field
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete);

        public void Delete(CustomFieldListOption entity, bool hardDelete);


        public void Delete(List<CustomFieldListOption> entities, bool hardDelete);

        /// <summary>
        /// Updates an existing custom field list option
        /// </summary>
        /// <param name="entity"></param>
        public void Update(CustomFieldListOption entity);

        /// <summary>
        /// Creates a new custom field list option
        /// </summary>
        /// <param name="entity"></param>
        public int Create(CustomFieldListOption entity);
    }
}
