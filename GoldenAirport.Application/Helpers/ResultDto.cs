namespace GoldenAirport.Application.Common.Models
{
    public class ResultDto<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        private ResultDto(bool success, T data, string message,  IEnumerable<string> errors)
        {
            Result = data;
            Message = message;
            Errors = errors;
        }

        public static ResultDto<T> Success(T data, string message)
        {
            return new ResultDto<T>(true, data, message, null);
        }

        public static ResultDto<T> Failure(IEnumerable<string> errors, string somthingError)
        {
            return new ResultDto<T>(false, default, somthingError,errors);
        }

        public static ResultDto<T> Failure(string error, string somthingError)
        {
            return new ResultDto<T>(false, default, somthingError, new List<string> { error });
        }
    }
}
