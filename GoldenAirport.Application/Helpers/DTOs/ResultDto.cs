namespace GoldenAirport.Application.Helpers.DTOs
{
    public class ResultDto
    {
        public object Result { get; set; }
        public string Message { get; set; }
    }

    public class ResultThirdPartyDto<T>
    {
        public T Result { get; set; }
    }
}
