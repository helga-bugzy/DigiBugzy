



namespace DigiBugzy.ApplicationLayer.CommandHandlers.Administrations.DigiAdmins
{
    public class IDigiAdminsApi : IBaseApiObject
    {
        public Task<A> CreateItem<A, R>(R request)
            where A : IResponseObject
            where R : IRequestObject
        {
            throw new NotImplementedException();
        }

        public Task<A> DeleteItem<A, R>(R request, bool hardDelete = false)
            where A : IResponseObject
            where R : IRequestObject
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<A>> Get<A, F>(F filter) where A : IResponseObject
        {
            throw new NotImplementedException();
        }

        public Task<A> UpdateItem<A, R>(R request)
            where A : IResponseObject
            where R : IRequestObject
        {
            throw new NotImplementedException();
        }
    }
}
