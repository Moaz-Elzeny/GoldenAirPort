using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.ThirdParty.Commands;
using GoldenAirport.Application.Helpers.DTOs;
using GoldenAirport.Application.TripRegistrations.Dtos;
using GoldenAirport.Domain.Enums;

namespace GoldenAirport.Application.Flights.Commands
{
    public class BookingFlightCommand : IRequest<ResponseDto<object>>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public UserType UserType { get; set; }
        //public string? CurrentUserId { get; set; }

        public List<AdultDto> Adult { get; set; }
        public List<ChildDto>? Child { get; set; }
        public class BookingFlightCommandHandler : IRequestHandler<BookingFlightCommand, ResponseDto<object>>
        {
            public async Task<ResponseDto<object>> Handle(BookingFlightCommand request, CancellationToken cancellationToken)
            {

                //RevalidateCommand revalidateCommand = new RevalidateCommand();

                //var revalidateBooking = revalidateCommand.M_mode();

                BookingCommand bookingCommand = new BookingCommand();

                ResponseThirdPartyDto<dynamic> responseDto = bookingCommand.DOCSAndDK();

                if (!responseDto.IsSuccess)
                    return ResponseDto<object>.Failure(new ErrorDto()
                    {
                        Message = "Error from Third Party",
                        Detilse = responseDto.Result,
                    });

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Success",
                    Result = responseDto.Result.Links,

                });

            }
        }
    }
}
