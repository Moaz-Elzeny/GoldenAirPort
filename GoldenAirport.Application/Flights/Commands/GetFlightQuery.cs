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



                //ResponseThirdPartyDto<dynamic> responseDto = shoppingQuery.Default();

                ResponseThirdPartyDto<dynamic> response = shoppingQuery.Default();

                // Create a list of GetFlightDto
                var flightDtos = new List<GetFlightDto>
                {
                    new GetFlightDto
                    {
                        FromCity = response.Result.groupedItineraryResponse?.version,
                        //ToCity = response.Result.groupedItineraryResponse?.ToCity,
                        //TakeOffDate = response.Result.groupedItineraryResponse?.TakeOffDate,
                        //DateOfArrival = response.Result.groupedItineraryResponse?.DateOfArrival,
                        //FlightHours = response.Result.groupedItineraryResponse?.FlightHours,
                        //FlightPrice = response.Result.groupedItineraryResponse?.FlightPrice,
                        //FlightPriceLessThanTwoYears = response.Result.groupedItineraryResponse?.FlightPriceLessThanTwoYears,
                        //FlightPriceLessThanTwelveYears = response.Result.groupedItineraryResponse?.FlightPriceLessThanTwelveYears,
                        //IsRefundable = response.Result.groupedItineraryResponse?.IsRefundable,
                        //AirLine = response.Result.groupedItineraryResponse?.AirLine,
                        //NumberOfSeats = response.Result.groupedItineraryResponse?.NumberOfSeats,
                        //NumberOfBags = response.Result.groupedItineraryResponse?.NumberOfBags,
                        //TravelClass = response.Result.groupedItineraryResponse?.TravelClass,
                    }
                };
                if (!response.IsSuccess)
                    return ResponseDto<object>.Failure(new ErrorDto()
                    {
                        Message = "Error from Third Party",
                        Detilse = response.Result,
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
