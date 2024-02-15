using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.DTOs.BookingDto;
using GoldenAirport.Application.Flights.DTOs.Error;
using GoldenAirport.Application.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace GoldenAirport.Application.Flights.ThirdParty
{
    public class BookingCommand
    {
        public ResponseThirdPartyDto<dynamic> DOCSAndDK()
        {
            var body = @"{" + "\n" +
@"    ""CreatePassengerNameRecordRQ"": {" + "\n" +
@"        ""haltOnAirPriceError"": true," + "\n" +
@"        ""targetCity"": ""M9DL""," + "\n" +
@"        ""AirBook"": {" + "\n" +
@"            ""HaltOnStatus"": [" + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""HL""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""HN""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""KK""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""LL""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""NN""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""NO""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""UC""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""US""" + "\n" +
@"                }," + "\n" +
@"                {" + "\n" +
@"                    ""Code"": ""UN""" + "\n" +
@"                }" + "\n" +
@"            ]," + "\n" +
@"            ""RedisplayReservation"": {" + "\n" +
@"                ""NumAttempts"": 5," + "\n" +
@"                ""WaitInterval"": 1000" + "\n" +
@"            }," + "\n" +
@"            ""RetryRebook"": {" + "\n" +
@"                ""Option"": true" + "\n" +
@"            }," + "\n" +
@"            ""OriginDestinationInformation"": {" + "\n" +
@"                ""FlightSegment"": [" + "\n" +
@"                    {" + "\n" +
@"                        ""DepartureDateTime"": ""2024-06-05T14:00""," + "\n" +
@"                        ""FlightNumber"": ""506""," + "\n" +
@"                        ""NumberInParty"": ""2""," + "\n" +
@"                        ""ResBookDesigCode"": ""Y""," + "\n" +
@"                        ""Status"": ""NN""," + "\n" +
@"                        ""DestinationLocation"": {" + "\n" +
@"                            ""LocationCode"": ""DXB""" + "\n" +
@"                        }," + "\n" +
@"                        ""MarketingAirline"": {" + "\n" +
@"                            ""Code"": ""GF""," + "\n" +
@"                            ""FlightNumber"": ""506""" + "\n" +
@"                        }," + "\n" +
@"                        ""OriginLocation"": {" + "\n" +
@"                            ""LocationCode"": ""BAH""" + "\n" +
@"                        }" + "\n" +
@"                    }" + "\n" +
@"                ]" + "\n" +
@"            }" + "\n" +
@"        }," + "\n" +
@"        ""AirPrice"": [" + "\n" +
@"            {" + "\n" +
@"                ""PriceComparison"": {" + "\n" +
@"                    ""AmountSpecified"": 56.100," + "\n" +
@"                    ""AcceptablePriceIncrease"": {" + "\n" +
@"                        ""HaltOnNonAcceptablePrice"": false," + "\n" +
@"                        ""Amount"": 10" + "\n" +
@"                    }" + "\n" +
@"                }," + "\n" +
@"                ""PriceRequestInformation"": {" + "\n" +
@"                    ""Retain"": true," + "\n" +
@"                    ""OptionalQualifiers"": {" + "\n" +
@"                        ""PricingQualifiers"": {" + "\n" +
@"                            ""PassengerType"": [" + "\n" +
@"                                {" + "\n" +
@"                                    ""Code"": ""ADT""," + "\n" +
@"                                    ""Quantity"": ""1""" + "\n" +
@"                                }," + "\n" +
@"                                {" + "\n" +
@"                                    ""Code"": ""C09""," + "\n" +
@"                                    ""Quantity"": ""1""" + "\n" +
@"                                }," + "\n" +
@"                                {" + "\n" +
@"                                    ""Code"": ""INF""," + "\n" +
@"                                    ""Quantity"": ""1""" + "\n" +
@"                                }" + "\n" +
@"                            ]" + "\n" +
@"                        }" + "\n" +
@"                    }" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        ]," + "\n" +
@"        ""TravelItineraryAddInfo"": {" + "\n" +
@"            ""AgencyInfo"": {" + "\n" +
@"                ""Address"": {" + "\n" +
@"                    ""AddressLine"": ""SABRE TRAVEL""," + "\n" +
@"                    ""CityName"": ""SOUTHLAKE""," + "\n" +
@"                    ""CountryCode"": ""US""," + "\n" +
@"                    ""PostalCode"": ""76092""," + "\n" +
@"                    ""StateCountyProv"": {" + "\n" +
@"                        ""StateCode"": ""TX""" + "\n" +
@"                    }," + "\n" +
@"                    ""StreetNmbr"": ""3150 SABRE DRIVE""" + "\n" +
@"                }," + "\n" +
@"                ""Ticketing"": {" + "\n" +
@"                    ""TicketType"": ""7TAW""" + "\n" +
@"                }" + "\n" +
@"            }," + "\n" +
@"            ""CustomerInfo"": {" + "\n" +
@"                ""ContactNumbers"": {" + "\n" +
@"                    ""ContactNumber"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""NameNumber"": ""1.1""," + "\n" +
@"                            ""Phone"": ""12321321321""," + "\n" +
@"                            ""PhoneUseType"": ""B""" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""NameNumber"": ""2.1""," + "\n" +
@"                            ""Phone"": ""546544654585""," + "\n" +
@"                            ""PhoneUseType"": ""B""" + "\n" +
@"                        }" + "\n" +
@"                    ]" + "\n" +
@"                }," + "\n" +
@"                " + "\n" +
@"                ""Email"": [" + "\n" +
@"                    {" + "\n" +
@"                        ""NameNumber"": ""1.1""," + "\n" +
@"                        ""Address"": ""ahmedmohamed12@gmail.com""," + "\n" +
@"                        ""Type"": ""TO""" + "\n" +
@"                    }," + "\n" +
@"                    {" + "\n" +
@"                        ""Address"": ""support@golden.com""," + "\n" +
@"                        ""Type"": ""BC""" + "\n" +
@"                    }" + "\n" +
@"                ]," + "\n" +
@"                ""PersonName"": [" + "\n" +
@"                    {" + "\n" +
@"                        ""NameNumber"": ""1.1""," + "\n" +
@"                        ""GivenName"": ""joo MR""," + "\n" +
@"                        ""Surname"": ""mohamed""," + "\n" +
@"                        ""PassengerType"": ""ADT""" + "\n" +
@"                    }," + "\n" +
@"                    {" + "\n" +
@"                        ""NameNumber"": ""2.1""," + "\n" +
@"                        ""GivenName"": ""eman MISS""," + "\n" +
@"                        ""Surname"": ""mohamed""," + "\n" +
@"                        ""PassengerType"": ""C09""" + "\n" +
@"                    }," + "\n" +
@"                    {" + "\n" +
@"                        ""NameNumber"": ""3.1""," + "\n" +
@"                        ""GivenName"": ""jojo""," + "\n" +
@"                        ""Surname"": ""khalid""," + "\n" +
@"                        ""Infant"": true," + "\n" +
@"                        ""PassengerType"": ""INF""" + "\n" +
@"                    }" + "\n" +
@"                ]" + "\n" +
@"            }" + "\n" +
@"        }," + "\n" +
@"        ""SpecialReqDetails"": {" + "\n" +
@"            ""SpecialService"": {" + "\n" +
@"                ""SpecialServiceInfo"": {" + "\n" +
@"                    ""AdvancePassenger"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""Document"": {" + "\n" +
@"                                ""ExpirationDate"": ""2020-07-10""," + "\n" +
@"                                ""Number"": ""3252352""," + "\n" +
@"                                ""Type"": ""P""," + "\n" +
@"                                ""IssueCountry"": ""EG""," + "\n" +
@"                                ""NationalityCountry"": ""EG""" + "\n" +
@"                            }," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""DateOfBirth"": ""1975-07-25""," + "\n" +
@"                                ""Gender"": ""M""," + "\n" +
@"                                ""NameNumber"": ""1.1""," + "\n" +
@"                                ""GivenName"": ""joo""," + "\n" +
@"                                ""Surname"": ""mohamed""" + "\n" +
@"                            }" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""Document"": {" + "\n" +
@"                                ""ExpirationDate"": ""2021-07-16""," + "\n" +
@"                                ""Number"": ""3423243""," + "\n" +
@"                                ""Type"": ""P""," + "\n" +
@"                                ""IssueCountry"": ""EG""," + "\n" +
@"                                ""NationalityCountry"": ""EG""" + "\n" +
@"                            }," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""DateOfBirth"": ""2010-07-08""," + "\n" +
@"                                ""Gender"": ""F""," + "\n" +
@"                                ""NameNumber"": ""2.1""," + "\n" +
@"                                ""GivenName"": ""eman""," + "\n" +
@"                                ""Surname"": ""mohamed""" + "\n" +
@"                            }" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""Document"": {" + "\n" +
@"                                ""ExpirationDate"": ""2021-07-08""," + "\n" +
@"                                ""Number"": ""233232""," + "\n" +
@"                                ""Type"": ""P""," + "\n" +
@"                                ""IssueCountry"": ""EG""," + "\n" +
@"                                ""NationalityCountry"": ""EG""" + "\n" +
@"                            }," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""DateOfBirth"": ""2017-08-10""," + "\n" +
@"                                ""Gender"": ""FI""," + "\n" +
@"                                ""NameNumber"": ""1.1""," + "\n" +
@"                                ""GivenName"": ""jojo""," + "\n" +
@"                                ""Surname"": ""khalid""" + "\n" +
@"                            }" + "\n" +
@"                        }" + "\n" +
@"                    ]," + "\n" +
@"                    ""SecureFlight"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""DateOfBirth"": ""1975-07-25""," + "\n" +
@"                                ""Gender"": ""M""," + "\n" +
@"                                ""NameNumber"": ""1.1""," + "\n" +
@"                                ""GivenName"": ""joo""," + "\n" +
@"                                ""Surname"": ""mohamed""" + "\n" +
@"                            }" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""DateOfBirth"": ""2010-07-08""," + "\n" +
@"                                ""Gender"": ""M""," + "\n" +
@"                                ""NameNumber"": ""2.1""," + "\n" +
@"                                ""GivenName"": ""eman""," + "\n" +
@"                                ""Surname"": ""mohamed""" + "\n" +
@"                            }" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""DateOfBirth"": ""2017-07-06""," + "\n" +
@"                                ""Gender"": ""FI""," + "\n" +
@"                                ""NameNumber"": ""1.1""," + "\n" +
@"                                ""GivenName"": ""jojo""," + "\n" +
@"                                ""Surname"": ""khalid""" + "\n" +
@"                            }" + "\n" +
@"                        }" + "\n" +
@"                    ]," + "\n" +
@"                    ""Service"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""SSR_Code"": ""CHLD""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""NameNumber"": ""2.1""" + "\n" +
@"                            }," + "\n" +
@"                            ""Text"": ""08JUL10""" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SSR_Code"": ""INFT""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""NameNumber"": ""1.1""" + "\n" +
@"                            }," + "\n" +
@"                            ""Text"": ""khalid/jojo/10Aug17""" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SSR_Code"": ""OSI""," + "\n" +
@"                            ""Text"": ""CTCM 0096612321321321/EN""," + "\n" +
@"                            ""VendorPrefs"": {" + "\n" +
@"                                ""Airline"": {" + "\n" +
@"                                    ""Code"": ""YY""" + "\n" +
@"                                }" + "\n" +
@"                            }" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SSR_Code"": ""OSI""," + "\n" +
@"                            ""Text"": ""CTCE joomohamed12//gmail.com/EN""," + "\n" +
@"                            ""VendorPrefs"": {" + "\n" +
@"                                ""Airline"": {" + "\n" +
@"                                    ""Code"": ""YY""" + "\n" +
@"                                }" + "\n" +
@"                            }" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""SSR_Code"": ""CTCM""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""NameNumber"": ""1.1""" + "\n" +
@"                            }," + "\n" +
@"                            ""Text"": ""0096612321321321""" + "\n" +
@"                        }," + "\n" +
@"                        {" + "\n" +
@"                            ""SegmentNumber"": ""A""," + "\n" +
@"                            ""SSR_Code"": ""CTCE""," + "\n" +
@"                            ""PersonName"": {" + "\n" +
@"                                ""NameNumber"": ""1.1""" + "\n" +
@"                            }," + "\n" +
@"                            ""Text"": "" joomohamed12//gmail.com """ + "\n" +
@"                        }" + "\n" +
@"                    ]" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        }," + "\n" +
@"        ""PostProcessing"": {" + "\n" +
@"            ""RedisplayReservation"": {" + "\n" +
@"                ""waitInterval"": 100" + "\n" +
@"            }," + "\n" +
@"            ""ARUNK"": {" + "\n" +
@"                ""priorPricing"": true" + "\n" +
@"            }," + "\n" +
@"            ""EndTransaction"": {" + "\n" +
@"                ""Source"": {" + "\n" +
@"                    ""ReceivedFrom"": ""SWS""" + "\n" +
@"                }" + "\n" +
@"            }," + "\n" +
@"            ""PostBookingHKValidation"": {" + "\n" +
@"                ""waitInterval"": 200," + "\n" +
@"                ""numAttempts"": 4" + "\n" +
@"            }," + "\n" +
@"            ""WaitForAirlineRecLoc"": {" + "\n" +
@"                ""waitInterval"": 200," + "\n" +
@"                ""numAttempts"": 4" + "\n" +
@"            }" + "\n" +
@"        }" + "\n" +
@"    }" + "\n" +
@"}";
            //var bodyData = RequstData.ConvertToJson();
            var responce = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.create), body, new Dictionary<string, string>()
                {
                     { "Authorization", "Bearer T1RLAQLQgrRGkqbkQ+14aqk1WW7hX0KVRFuX9ucg6hOOH9ahGhBqhxb6Xy0lhMvfQG0vjT4SAADQTsAANvCx45JiIzGaVf+r40VSDCPWfBOB0RcGYjWNGS1ddRxpfwv/R44rzoaQHPiCdZ5jkV7yCPZjd/ig8N6ydPyaTZVffBjOASqyGuI1faEb3Kk7pChgfY9e1KjHFrt9hUxZkKvZEsRKvNHCCA8DVfAroAOaMHIZ1gQUMQWxISEvPz+HHrtjtJtw11AMrJLFo+zk5XLqT+wPmq9d2d2hHWQUxBw8JD4QgbL7DzFHoGDap/VGpckuGR6WSe3APMYkXFaRT6lV+/pDlMxIZW27IA**" }
                });
            StreamReader readers = new(responce.GetResponseStream());
            string responseText = readers.ReadToEnd();
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                //ResponseDto response = JsonConvert.DeserializeObject<ResponseDto>(responseText);
                return ResponseThirdPartyDto<dynamic>.Success(responce);//response.groupedItineraryResponse.legDescs
            }
            else if (responce.StatusCode == HttpStatusCode.Unauthorized)
            {
                ///  اعمل التوكن تاني لمره وحده بس
                ErrorDTO response = JsonConvert.DeserializeObject<ErrorDTO>(responseText);
                return ResponseThirdPartyDto<dynamic>.Failure(response);
            }
            else
            {
                ErrorDTO response = JsonConvert.DeserializeObject<ErrorDTO>(responseText);
                return ResponseThirdPartyDto<dynamic>.Failure(response);
            }
        }
    }
}
