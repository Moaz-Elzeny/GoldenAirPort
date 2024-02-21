using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.DTOs;
using GoldenAirport.Application.Flights.ThirdParty.Queries;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Flights.Commands
{
    public class GetFlightQuery : IRequest<ResponseDto<object>>
    {
        public class CreateFlightCommandHandler : IRequestHandler<GetFlightQuery, ResponseDto<object>>
        {
            public async Task<ResponseDto<object>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
            {
                 ShoppingQuery shoppingQuery = new ShoppingQuery();


                List<GetFlightDto> flightList = new List<GetFlightDto>();

                GetFlightDto flight = new GetFlightDto
                {
                    FromCity = "YourFromCityValue1",
                    ToCity = "YourToCityValue1",
                    TakeOffDate = "YourTakeOffDateValue1",
                    DateOfArrival = "YourDateOfArrivalValue1",
                    FlightHours = "YourFlightHoursValue1",
                    FlightPrice = "YourFlightPriceValue1",
                    FlightPriceLessThanTwoYears = "YourFlightPriceLessThanTwoYearsValue1",
                    FlightPriceLessThanTwelveYears = "YourFlightPriceLessThanTwelveYearsValue1",
                    IsRefundable = "YourIsRefundableValue1",
                    AirLine = "YourAirLineValue1",
                    NumberOfSeats = "YourNumberOfSeatsValue1",
                    NumberOfBags = "YourNumberOfBagsValue1",
                    TravelClass = "YourTravelClassValue1"
                };
                flightList.Add(flight);



                ResponseThirdPartyDto<dynamic> responseDto = shoppingQuery.Default();
                if (!responseDto.IsSuccess)
                    return ResponseDto<object>.Failure(new ErrorDto()
                    {
                        Message = "Error from Third Party",
                        Detilse = responseDto.Result,
                    });

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Success ✔️",
                    Result = flightList,

                });
            }
        }
    }
}
