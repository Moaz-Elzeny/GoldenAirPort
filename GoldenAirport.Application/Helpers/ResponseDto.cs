using GoldenAirport.Application.Helpers.DTOs;
using Newtonsoft.Json;

namespace GoldenAirport.Application.Common.Models
{
    public class ResponseDto<T>
    {
        public ResultDto Result { get; set; }

        public ErrorDto Error { get; set; }

        public bool IsSuccess { get; set; }

        private ResponseDto(bool status, ResultDto result, ErrorDto error)
        {
            IsSuccess = status;
            Result = result;
            Error = error;
        }

        public static ResponseDto<T> Success(ResultDto result)
        {
            return new ResponseDto<T>(true, result,null);
        }

        public static ResponseDto<T> Failure(ErrorDto error)
        {
            return new ResponseDto<T>(false, null, error);
        }


    }


    public class ResponseThirdPartyDto<T>
    {

        public T Result { get; set; }

        public bool IsSuccess { get; set; }

        private ResponseThirdPartyDto(bool status, T result)
        {
            IsSuccess = status;
            Result = result;
        }

        public static ResponseThirdPartyDto<T> Success(T result)
        {
            return new ResponseThirdPartyDto<T>(true, result);
        }

        public static ResponseThirdPartyDto<T> Failure(T result)
        {
            return new ResponseThirdPartyDto<T>(false, result);
        }


    }
}
