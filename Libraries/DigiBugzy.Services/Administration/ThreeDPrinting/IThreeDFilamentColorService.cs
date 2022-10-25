﻿using DigiBugzy.Core.Domain.Administration.ThreeDPrinting;

namespace DigiBugzy.Services.Administration.ThreeDPrinting
{
    public interface IThreeDFilamentColorService
    {
        #region Requests

        /// <summary>
        /// Get individual item on hand of its primary key id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThreeDFilamentColor GetById(int id);

        /// <summary>
        /// Gets list of items conforming to filter specifications
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<ThreeDFilamentColor> Get(StandardFilter filter);

        #endregion

        #region Commands

        /// <summary>
        /// Deletes item on hand of it's id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete);

        /// <summary>
        /// Updates existing item in the database
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ThreeDFilamentColor entity);


        /// <summary>
        /// Create new item  in the database (does check for duplicate - then updates)
        /// </summary>
        /// <param name="entity"></param>
        public void Create(ThreeDFilamentColor entity);

        #endregion

    }
}
