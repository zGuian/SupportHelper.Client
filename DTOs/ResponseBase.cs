using System.Windows.Markup;

namespace SupportHelper.Blazor.DTOs
{
    public sealed class ResponseBase<T> where T : class
    {
        public bool IsSuccess { get; private set; }
        public T? Data { get; private set; }

        private ResponseBase(bool isSuccess, T? data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public static ResponseBase<T> ReturnSuccess(T data)
        {
            return new ResponseBase<T>(true, data);
        }

        public static ResponseBase<T> ReturnFalse()
        {
            return new ResponseBase<T>(false, null);
        }
    }
}
