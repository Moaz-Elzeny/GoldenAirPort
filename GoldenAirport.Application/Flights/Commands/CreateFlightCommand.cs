using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.ThirdParty.Queries;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Flights.Commands
{
    public class CreateFlightCommand : IRequest<ResponseDto<object>>
    {
        public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, ResponseDto<object>>
        {
            public async Task<ResponseDto<object>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
            {
                ShoppingQuery shoppingQuery = new ShoppingQuery();

                ResponseThirdPartyDto<dynamic> responseDto = shoppingQuery.Default();
                if (!responseDto.IsSuccess)
                    return ResponseDto<object>.Failure(new ErrorDto()
                    {
                        Message = "Error from Third Party",
                        Detilse = responseDto.Result,
                    });

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Success",
                    Result = responseDto.Result.groupedItineraryResponse.legDescs,

                });
            }
        }
    }
}
