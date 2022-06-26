
namespace DigiBugzy.ApplicationLayer.CommandHandlers
{
    public class IApiHandler : IBaseApiObject
    {
        public Task<T> CreateItem<T, R>(R request)
            where T : IResponseObject
            where R : IRequestObject
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteItem<T, R>(R request, bool hardDelete = false)
            where T : IResponseObject
            where R : IRequestObject
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get<T, F>(F filter) where T : IResponseObject where F : IFilterObject
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateItem<T, R>(R request)
            where T : IResponseObject
            where R : IRequestObject
        {
            throw new NotImplementedException();
        }
    }
}
