namespace Etqaan.Application.Common.Models
{
    public class ResultDto<T>
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        private ResultDto(bool success, T data, IEnumerable<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public static ResultDto<T> Success(T data)
        {
            return new ResultDto<T>(true, data, null);
        }

        public static ResultDto<T> Failure(IEnumerable<string> errors)
        {
            return new ResultDto<T>(false, default, errors);
        }

        public static ResultDto<T> Failure(string error)
        {
            return new ResultDto<T>(false, default, new List<string> { error });
        }
    }
}
