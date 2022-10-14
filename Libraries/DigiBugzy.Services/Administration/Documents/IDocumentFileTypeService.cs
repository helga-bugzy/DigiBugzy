
using DigiBugzy.Core.Domain.Administration.Documents;

namespace DigiBugzy.Services.Administration.Documents
{
    public interface IDocumentFileTypeService
    {
        #region Requets

        /// <summary>
        /// Gets a document file type item with it's related data via eager loading
        /// on hand of the primary key id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DocumentFileType GetById(int id);

        /// <summary>
        /// Gets list of document file types as per filter specifications
        /// and includes related data via eager loading
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<DocumentFileType> Get(StandardFilter filter);


        #endregion

        #region Commands

        /// <summary>
        /// Soft/hard deletes an existing document file type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(int id, bool hardDelete);

        /// <summary>
        /// Soft/hard deletes an existing document file type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(DocumentFileType entity, bool hardDelete);

        /// <summary>
        /// Soft/hard deletes an existing document file type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hardDelete"></param>
        public void Delete(List<DocumentFileType> entities, bool hardDelete);

        /// <summary>
        /// Updates an existing document file type
        /// </summary>
        /// <param name="entity"></param>
        public void Update(DocumentFileType entity);

        /// <summary>
        /// Creates a new document file type
        /// </summary>
        /// <param name="entity"></param>
        public int Create(DocumentFileType entity);

        #endregion
    }
}
