namespace DigiBugzy.ApplicationLayer.Common.xBaseObjects.ComObjects
{
    public class BaseResponseObject: IResponseObject
    {
        public int Id { get; set; }

        public bool IsSuccess { get; set; }

        public Exception Exception { get; set; }

        public string Message { get; set; }
    }
}
