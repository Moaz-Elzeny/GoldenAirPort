﻿using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.ThirdParty.Commands;
using GoldenAirport.Application.Helpers.DTOs;

namespace GoldenAirport.Application.Flights.Commands
{
    public class BookingFlightCommand : IRequest<ResponseDto<object>>
    {
        public class BookingFlightCommandHandler : IRequestHandler<BookingFlightCommand, ResponseDto<object>>
        {
            public async Task<ResponseDto<object>> Handle(BookingFlightCommand request, CancellationToken cancellationToken)
            {

                RevalidateCommand revalidateCommand = new RevalidateCommand();

                var revalidateBooking = revalidateCommand.M_mode();

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
