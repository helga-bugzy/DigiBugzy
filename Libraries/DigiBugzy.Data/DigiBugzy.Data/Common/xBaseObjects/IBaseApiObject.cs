
namespace DigiBugzy.Data.Common.xBaseObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Response (answer)</typeparam>
    /// <typeparam name="R">Request</typeparam>
    /// <typeparam name="C">Command</typeparam>
    /// <typeparam name="F">Filter</typeparam>
    public interface IBaseApiObject
    {

        /// <summary>
        /// Gets all items on hand of the filter values forwarded
        /// </summary>
        /// <typeparam name="A">Response (answer)</typeparam>
        /// <typeparam name="F">Filter</typeparam>
        /// <param name="filter">Filter with specifications</param>
        /// <returns></returns>        
        Task<IEnumerable<T>> Get<T, F>(F filter) where T : IResponseObject where F : IFilterObject;

        /// <summary>
        /// Adds new item to the database as per response specifications
        /// </summary>
        /// <typeparam name="A">Response (answer)</typeparam>
        /// <typeparam name="R">Request object</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<A> CreateItem<A, R>(R request) where A : IResponseObject where R : IRequestObject;

        /// <summary>
        /// Adds updates an item in the database as per response specifications
        /// </summary>
        /// <typeparam name="A">Response (answer)</typeparam>
        /// <typeparam name="R">Request object</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<A> UpdateItem<A, R>(R request) where A : IResponseObject where R: IRequestObject;

        /// <summary>
        /// Marks a specific item for deletion or hard delete
        /// </summary>
        /// <typeparam name="A">Response (answer)</typeparam>
        /// <typeparam name="R">Request object</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<A> DeleteItem<A, R>(R request, bool hardDelete = false) where A : IResponseObject where R : IRequestObject;

        
    }
}
