using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Services.Administration.Documents
{
    public interface IDocumentTypeService
    {

        #region Requets

        /// <summary>
        /// Gets a document type item with it's related data via eager loading
        /// on hand of the primary key id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DocumentType GetById(int id);
        
        /// <summary>
        /// Gets list of document types as per filter specifications
        /// and includes related data via eager loading
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<DocumentType> Get(StandardFilter filter);


        #endregion

        #region Commands

        /// <summary>
        /// Soft/hard deletes an existing document type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete);

        /// <summary>
        /// Soft/hard deletes an existing document type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(DocumentType entity, bool hardDelete);

        /// <summary>
        /// Soft/hard deletes an existing document type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(List<DocumentType> entities, bool hardDelete);

        /// <summary>
        /// Updates an existing document type
        /// </summary>
        /// <param name="entity"></param>
        public void Update(DocumentType entity);

        /// <summary>
        /// Creates a new document type
        /// </summary>
        /// <param name="entity"></param>
        public int Create(DocumentType entity);

        #endregion
    }
}
