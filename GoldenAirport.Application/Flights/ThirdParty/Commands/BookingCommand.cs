using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.DTOs.BookingDto;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.BookingDto;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.Error;
using GoldenAirport.Application.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace GoldenAirport.Application.Flights.ThirdParty.Commands
{
    public class BookingCommand
    {
        

        public ResponseThirdPartyDto<dynamic> DOCSAndDK()
        {
            var RequstData = new BookingRequestDto
            {
                CreatePassengerNameRecordRQ = new CreatePassengerNameRecordRQ
                {
                    haltOnAirPriceError = true,
                    targetCity = "M9DL",
                    AirBook = new Dtos.BookingDto.AirBook
                    {
                        HaltOnStatus = new List<HaltOnStatus>
                        {
                            new HaltOnStatus { Code = "HL" },
                            new HaltOnStatus { Code = "HN" },
                            new HaltOnStatus { Code = "KK" },
                            new HaltOnStatus { Code = "LL" },
                            new HaltOnStatus { Code = "NN" },
                            new HaltOnStatus { Code = "NO" },
                            new HaltOnStatus { Code = "UC" },
                            new HaltOnStatus { Code = "US" },
                            new HaltOnStatus { Code = "UN" },
                        },
                        RedisplayReservation = new RedisplayReservation
                        {
                            NumAttempts = 5,
                            WaitInterval = 1000
                        },
                        RetryRebook = new RetryRebook
                        {
                            Option = true
                        },
                        OriginDestinationInformation = new OriginDestinationInformation
                        {
                            FlightSegment = new List<FlightSegment>
                            {
                                new FlightSegment
                                {
                                    DepartureDateTime = "2024-06-05T14:00",
                                    FlightNumber = "506",
                                    NumberInParty = "2",
                                    ResBookDesigCode = "Y",
                                    Status = "NN",
                                    DestinationLocation = new Dtos.BookingDto.DestinationLocation
                                    {
                                        LocationCode = "DXB"
                                    },
                                    MarketingAirline = new Dtos.BookingDto.MarketingAirline
                                    {
                                        Code = "GF",
                                        FlightNumber = "506"
                                    },
                                    OriginLocation = new OriginLocation
                                    {
                                        LocationCode = "BAH"
                                    }
                                }
                            }
                        }
                    },
                    AirPrice = new List<Dtos.BookingDto.AirPrice>
                    {
                        new Dtos.BookingDto.AirPrice
                        {
                            PriceComparison = new Dtos.BookingDto.PriceComparison
                            {
                                AmountSpecified = 56.100,
                                AcceptablePriceIncrease = new AcceptablePriceIncrease
                                {
                                    HaltOnNonAcceptablePrice = false,
                                    Amount = 10
                                }
                            },
                            PriceRequestInformation = new PriceRequestInformation
                            {
                                Retain = true,
                                OptionalQualifiers = new OptionalQualifiers
                                {
                                    PricingQualifiers = new PricingQualifiers
                                    {
                                        PassengerType = new List<PassengerType>
                                        {
                                            new PassengerType { Code = "ADT", Quantity = "1" },
                                            new PassengerType { Code = "C09", Quantity = "1" },
                                            new PassengerType { Code = "INF", Quantity = "1" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    TravelItineraryAddInfo = new TravelItineraryAddInfo
                    {
                        AgencyInfo = new AgencyInfo
                        {
                            Address = new Address
                            {
                                AddressLine = "SABRE TRAVEL",
                                CityName = "SOUTHLAKE",
                                CountryCode = "US",
                                PostalCode = "76092",
                                StateCountyProv = new StateCountyProv
                                {
                                    StateCode = "TX"
                                },
                                StreetNmbr = "3150 SABRE DRIVE"
                            },
                            Ticketing = new Dtos.BookingDto.Ticketing
                            {
                                TicketType = "7TAW"
                            }
                        },
                        CustomerInfo = new Dtos.BookingDto.CustomerInfo
                        {
                            ContactNumbers = new Dtos.BookingDto.ContactNumbers
                            {
                                ContactNumber = new List<Dtos.BookingDto.ContactNumber>
                                {
                                    new Dtos.BookingDto.ContactNumber { NameNumber = "1.1", Phone = "12321321321", PhoneUseType = "B" },
                                    new Dtos.BookingDto.ContactNumber { NameNumber = "2.1", Phone = "546544654585", PhoneUseType = "B" }
                                }
                            },
                            Email = new List<Email>
                            {
                                new Email { NameNumber = "1.1", Address = "ahmedmohamed12@gmail.com", Type = "TO" },
                                new Email {NameNumber = "", Address = "support@golden.com", Type = "BC" }
                            },
                            PersonName = new List<Dtos.BookingDto.PersonName>
                            {
                                new Dtos.BookingDto.PersonName { NameNumber = "1.1", GivenName = "joo MR", Surname = "mohamed",Infant = false, PassengerType = "ADT" },
                                new Dtos.BookingDto.PersonName { NameNumber = "2.1", GivenName = "eman MISS", Surname = "mohamed",Infant = false, PassengerType = "C09" },
                                new Dtos.BookingDto.PersonName { NameNumber = "3.1", GivenName = "jojo", Surname = "khalid", Infant = true, PassengerType = "INF" }
                            }
                        }
                    },
                    SpecialReqDetails = new SpecialReqDetails
                    {
                        SpecialService = new SpecialService
                        {
                            SpecialServiceInfo = new Dtos.BookingDto.SpecialServiceInfo
                            {
                                AdvancePassenger = new List<AdvancePassenger>
                                {
                                    new AdvancePassenger
                                    {
                                        SegmentNumber = "A",
                                        Document = new Document
                                        {
                                            ExpirationDate = "2020-07-10",
                                            Number = "3252352",
                                            Type = "P",
                                            IssueCountry = "EG",
                                            NationalityCountry = "EG"
                                        },
                                        PersonName = new PersonName1
                                        {
                                            DateOfBirth = "1975-07-25",
                                            Gender = "M",
                                            NameNumber = "1.1",
                                            GivenName = "joo",
                                            Surname = "mohamed"
                                        }
                                    },
                                    new AdvancePassenger
                                    {
                                        SegmentNumber = "A",
                                        Document = new Document
                                        {
                                            ExpirationDate = "2021-07-16",
                                            Number = "3423243",
                                            Type = "P",
                                            IssueCountry = "EG",
                                            NationalityCountry = "EG"
                                        },
                                        PersonName = new PersonName1
                                        {
                                            DateOfBirth = "2010-07-08",
                                            Gender = "F",
                                            NameNumber = "2.1",
                                            GivenName = "eman",
                                            Surname = "mohamed"
                                        }
                                    },
                                    new AdvancePassenger
                                    {
                                        SegmentNumber = "A",
                                        Document = new Document
                                        {
                                            ExpirationDate = "2021-07-08",
                                            Number = "233232",
                                            Type = "P",
                                            IssueCountry = "EG",
                                            NationalityCountry = "EG"
                                        },
                                        PersonName = new PersonName1
                                        {
                                            DateOfBirth = "2017-08-10",
                                            Gender = "FI",
                                            NameNumber = "1.1",
                                            GivenName = "jojo",
                                            Surname = "khalid"
                                        }
                                    },
                                },
                                SecureFlight = new List<SecureFlight>
                                {
                                    new SecureFlight
                                    {
                                        SegmentNumber = "A",
                                        PersonName = new PersonName1
                                        {
                                            DateOfBirth = "1975-07-25",
                                            Gender = "M",
                                            NameNumber = "1.1",
                                            GivenName = "joo",
                                            Surname = "mohamed"
                                        }
                                    },
                                    new SecureFlight
                                    {
                                        SegmentNumber = "A",
                                        PersonName = new PersonName1
                                        {
                                            DateOfBirth = "2010-07-08",
                                            Gender = "F",
                                            NameNumber = "2.1",
                                            GivenName = "eman",
                                            Surname = "mohamed"
                                        }
                                    },new SecureFlight
                                    {
                                        SegmentNumber = "A",
                                        PersonName = new PersonName1
                                        {
                                            DateOfBirth = "2017-07-06",
                                            Gender = "FI",
                                            NameNumber = "1.1",
                                            GivenName = "jojo",
                                            Surname = "khalid"
                                        }
                                    },
                                },
                                Service = new List<Dtos.BookingDto.Service>
                                {
                                    new Dtos.BookingDto.Service
                                    {
                                        SegmentNumber = "A",
                                        SSR_Code = "CHLD",
                                        PersonName = new PersonName2 { NameNumber = "2.1" },
                                        Text = "08JUL10",
                                        VendorPrefs = new VendorPrefs
                                        {
                                            Airline = new Dtos.BookingDto.Airline
                                            {
                                                Code = "YY"
                                            }
                                        }
                                    },
                                    new Dtos.BookingDto.Service
                                    {
                                        SegmentNumber = "A",
                                        SSR_Code = "INFT",
                                        PersonName = new PersonName2 { NameNumber = "1.1" },
                                        Text = "khalid/jojo/10Aug17",
                                        VendorPrefs = new VendorPrefs
                                        {
                                            Airline = new Dtos.BookingDto.Airline
                                            {
                                                Code = "YY"
                                            }
                                        }
                                    },
                                    new Dtos.BookingDto.Service
                                    {
                                        SegmentNumber = "A",
                                        SSR_Code = "OSI",
                                        PersonName = new PersonName2{NameNumber = ""},
                                        Text = "CTCM 0096612321321321/EN",
                                        VendorPrefs = new VendorPrefs
                                        {
                                            Airline = new Dtos.BookingDto.Airline
                                            {
                                                Code = "YY"
                                            }
                                        }
                                    },
                                    new Dtos.BookingDto.Service
                                    {
                                        SegmentNumber = "A",
                                        SSR_Code = "OSI",
                                        PersonName = new PersonName2{NameNumber = ""},
                                        Text = "CTCE joomohamed12//gmail.com/EN",
                                        VendorPrefs = new VendorPrefs
                                        {
                                            Airline = new Dtos.BookingDto.Airline
                                            {
                                                Code = "YY"
                                            }
                                        }
                                    },
                                    new Dtos.BookingDto.Service
                                    {
                                        SegmentNumber = "A",
                                        SSR_Code = "CTCM",
                                        PersonName = new PersonName2 { NameNumber = "1.1" },
                                        Text = "0096612321321321",
                                        VendorPrefs = new VendorPrefs
                                        {
                                            Airline = new Dtos.BookingDto.Airline
                                            {
                                                Code = "YY"
                                            }
                                        }
                                    },
                                    new Dtos.BookingDto.Service
                                    {
                                        SegmentNumber = "A",
                                        SSR_Code = "CTCE",
                                        PersonName = new PersonName2 { NameNumber = "1.1" },
                                        Text = " joomohamed12//gmail.com ",
                                        VendorPrefs = new VendorPrefs
                                        {
                                            Airline = new Dtos.BookingDto.Airline
                                            {
                                                Code = "YY"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    PostProcessing = new PostProcessing
                    {
                        RedisplayReservation = new RedisplayReservation1
                        {
                            waitInterval = 100
                        },
                        ARUNK = new ARUNK
                        {
                            priorPricing = true
                        },
                        EndTransaction = new EndTransaction
                        {
                            Source = new Dtos.BookingDto.Source
                            {
                                ReceivedFrom = "SWS"
                            }
                        },
                        PostBookingHKValidation = new PostBookingHKValidation
                        {
                            waitInterval = 200,
                            numAttempts = 4
                        },
                        WaitForAirlineRecLoc = new WaitForAirlineRecLoc
                        {
                            waitInterval = 200,
                            numAttempts = 4
                        }
                    }
                }
            };



            var bodyData = RequstData.ConvertToJson();

            var response = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.create), bodyData, new Dictionary<string, string>()
                {
                     { "Authorization", "Bearer T1RLAQIIMrxeYyZJAcegclJNEO2Apvs+bdlllVGAvZ9E01bocBDsiCnGzl7r/geIwZwxreijAADQJUyRwq5ttFQPqwFTyYNxp4dGjSYbLYL/4xmhdAQ0gqUZ8qM8WTGzRdOKsCdsJUEUZyFLu+QWLF5CkDW+UU9AaZwCJ8aOB0Geeahwo3jGlHWHA6Tho69BW7LEGGr1es6/xVB0CnUAf90jnuyZnNDfDIKcvbj+ESyU0a9oO3V8q2dl4FT5cCyANqy1H8GK63Y9nqnNM+PudnSlyaB7DsxvwDb2t/iuYvP2RTxgilUWwUWqEctCqJTGUehk0r6TVvPhku2yagULXOZI+smbiJQq6A**" }
                });

            StreamReader readers = new(response.GetResponseStream());
            string responseText = readers.ReadToEnd();


            if (response.StatusCode == HttpStatusCode.OK)
            {
                //JsonSerializerSettings jsonSelectSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
                BookingResponseDto resulte = JsonConvert.DeserializeObject<BookingResponseDto>(responseText);
                return ResponseThirdPartyDto<dynamic>.Success(resulte);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var tokenCreateCommand = new TokenCreateCommand();
                var result = tokenCreateCommand.RQ();
                response = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.create), bodyData, new Dictionary<string, string>()
                {
                    { "Authorization", $"Bearer {result.Result}" }
                });
                readers = new(response.GetResponseStream());
                responseText = readers.ReadToEnd();

                BookingResponseDto resulte = JsonConvert.DeserializeObject<BookingResponseDto>(responseText);
                return ResponseThirdPartyDto<dynamic>.Success(resulte);
            }
            else
            {
                ErrorDTO responseError = JsonConvert.DeserializeObject<ErrorDTO>(responseText);
                return ResponseThirdPartyDto<dynamic>.Failure(responseError);
            }
        }
    }
}
