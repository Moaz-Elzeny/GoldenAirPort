namespace GoldenAirport.Application.Users.DTOs
{
    public record UserTokenDto
    {
        public string UserId { get; init; }
        public string Token { get; init; }
    }
}
