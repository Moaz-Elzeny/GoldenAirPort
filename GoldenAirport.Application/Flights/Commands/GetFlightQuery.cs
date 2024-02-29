using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.DTOs;
using GoldenAirport.Application.Flights.ThirdParty.Queries;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Flights.Commands
{
    public class GetFlightQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public FlightTypeDto FlightType { get; set; }
        public int? FromCity { get; set; }
        public List<int>? ToCity { get; set; }
        public DateTime? StartingOn { get; set; }
        public int? Passenger { get; set; }
        public bool DirectFlight { get; set; }
        public int TravelClass { get; set; }
        public class CreateFlightCommandHandler : IRequestHandler<GetFlightQuery, ResponseDto<object>>
        {
            public async Task<ResponseDto<object>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
            {
                 ShoppingQuery shoppingQuery = new ShoppingQuery();


                List<GetFlightDto> flightList = new List<GetFlightDto>();

                GetFlightDto flight = new GetFlightDto
                {
                    FromCity = "Cairo",
                    ToCity = "Geda",
                    TakeOffDate = "20/3/2024",
                    DateOfArrival = "5:00:00",
                    FlightHours = "2:30:00",
                    FlightPrice = "15000",
                    FlightPriceLessThanTwoYears = "10000",
                    FlightPriceLessThanTwelveYears = "6000",
                    IsRefundable = "True",
                    AirLine = "EgyptAir",
                    NumberOfSeats = "50",
                    NumberOfBags = "50",
                    TravelClass = "Normal"
                };

                flightList.Add(flight);

                flight = new GetFlightDto
                {
                    FromCity = "Geda",
                    ToCity = "Cairo",
                    TakeOffDate = "30/30/2024",
                    DateOfArrival = "8:00:00",
                    FlightHours = "2:30:00",
                    FlightPrice = "15000",
                    FlightPriceLessThanTwoYears = "10000",
                    FlightPriceLessThanTwelveYears = "6000",
                    IsRefundable = "false",
                    AirLine = "EgyptAir",
                    NumberOfSeats = "50",
                    NumberOfBags = "50",
                    TravelClass = "Economy"
                };


                flightList.Add(flight);



                //ResponseThirdPartyDto<dynamic> responseDto = shoppingQuery.Default();

                //ResponseThirdPartyDto<dynamic> response = shoppingQuery.Default();

                // Create a list of GetFlightDto
                //var flightDtos = new List<GetFlightDto>
                //{
                //    new GetFlightDto
                //    {
                //        FromCity = response.Result.groupedItineraryResponse?.version,
                //        //ToCity = response.Result.groupedItineraryResponse?.ToCity,
                //        //TakeOffDate = response.Result.groupedItineraryResponse?.TakeOffDate,
                //        //DateOfArrival = response.Result.groupedItineraryResponse?.DateOfArrival,
                //        //FlightHours = response.Result.groupedItineraryResponse?.FlightHours,
                //        //FlightPrice = response.Result.groupedItineraryResponse?.FlightPrice,
                //        //FlightPriceLessThanTwoYears = response.Result.groupedItineraryResponse?.FlightPriceLessThanTwoYears,
                //        //FlightPriceLessThanTwelveYears = response.Result.groupedItineraryResponse?.FlightPriceLessThanTwelveYears,
                //        //IsRefundable = response.Result.groupedItineraryResponse?.IsRefundable,
                //        //AirLine = response.Result.groupedItineraryResponse?.AirLine,
                //        //NumberOfSeats = response.Result.groupedItineraryResponse?.NumberOfSeats,
                //        //NumberOfBags = response.Result.groupedItineraryResponse?.NumberOfBags,
                //        //TravelClass = response.Result.groupedItineraryResponse?.TravelClass,
                //    }
                //};
                //if (!response.IsSuccess)
                //    return ResponseDto<object>.Failure(new ErrorDto()
                //    {
                //        Message = "Error from Third Party",
                //        Detilse = response.Result,
                //    });

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Success ✔️",
                    Result = flightList,

                });
            }
        }
    }
}
