using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.Error;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.RevalidateDto;
using GoldenAirport.Application.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace GoldenAirport.Application.Flights.ThirdParty.Commands
{
    public class RevalidateCommand
    {
        public ResponseThirdPartyDto<dynamic> M_mode()
        {
            var body = @"{" + "\n" +
@"    ""OTA_AirLowFareSearchRQ"": {" + "\n" +
@"        ""Version"": ""1""," + "\n" +
@"        ""POS"": {" + "\n" +
@"            ""Source"": [" + "\n" +
@"                {" + "\n" +
@"                    ""PseudoCityCode"": ""M9DL""," + "\n" +
@"                    ""RequestorID"": {" + "\n" +
@"                        ""ID"": ""REQ.ID""," + "\n" +
@"                        ""Type"": ""0.AAA.X""," + "\n" +
@"                        ""CompanyName"": {" + "\n" +
@"                            ""Code"": ""TN""" + "\n" +
@"                        }" + "\n" +
@"                    }" + "\n" +
@"                }" + "\n" +
@"            ]" + "\n" +
@"        }," + "\n" +
@"        ""OriginDestinationInformation"": [" + "\n" +
@"            {" + "\n" +
@"                ""RPH"": ""1""," + "\n" +
@"                ""DepartureDateTime"": ""2024-03-29T08:10:00""," + "\n" +
@"                ""OriginLocation"": {" + "\n" +
@"                    ""LocationCode"": ""RUH""" + "\n" +
@"                }," + "\n" +
@"                ""DestinationLocation"": {" + "\n" +
@"                    ""LocationCode"": ""AHB""" + "\n" +
@"                }," + "\n" +
@"                ""TPA_Extensions"": {" + "\n" +
@"                    ""Flight"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""Number"": 1659," + "\n" +
@"                            ""DepartureDateTime"": ""2024-03-29T08:10:00""," + "\n" +
@"                            ""ArrivalDateTime"": ""2024-03-29T09:45:00""," + "\n" +
@"                            ""Type"": ""A""," + "\n" +
@"                            ""ClassOfService"": ""N""," + "\n" +
@"                            ""DestinationLocation"": {" + "\n" +
@"                                ""LocationCode"": ""AHB""" + "\n" +
@"                            }," + "\n" +
@"                            ""OriginLocation"": {" + "\n" +
@"                                ""LocationCode"": ""RUH""" + "\n" +
@"                            }," + "\n" +
@"                            ""Airline"": {" + "\n" +
@"                                ""Operating"": ""SV""," + "\n" +
@"                                ""Marketing"": ""SV""" + "\n" +
@"                            }" + "\n" +
@"                        }" + "\n" +
@"                    ]" + "\n" +
@"                }" + "\n" +
@"            }," + "\n" +
@"            {" + "\n" +
@"                ""RPH"": ""2""," + "\n" +
@"                ""DepartureDateTime"": ""2024-03-30T04:05:00""," + "\n" +
@"                ""OriginLocation"": {" + "\n" +
@"                    ""LocationCode"": ""AHB""" + "\n" +
@"                }," + "\n" +
@"                ""DestinationLocation"": {" + "\n" +
@"                    ""LocationCode"": ""RUH""" + "\n" +
@"                }," + "\n" +
@"                ""TPA_Extensions"": {" + "\n" +
@"                    ""Flight"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""Number"": 1860," + "\n" +
@"                            ""DepartureDateTime"": ""2024-03-30T04:05:00""," + "\n" +
@"                            ""ArrivalDateTime"": ""2024-03-30T05:45:00""," + "\n" +
@"                            ""Type"": ""A""," + "\n" +
@"                            ""ClassOfService"": ""N""," + "\n" +
@"                            ""DestinationLocation"": {" + "\n" +
@"                                ""LocationCode"": ""RUH""" + "\n" +
@"                            }," + "\n" +
@"                            ""OriginLocation"": {" + "\n" +
@"                                ""LocationCode"": ""AHB""" + "\n" +
@"                            }," + "\n" +
@"                            ""Airline"": {" + "\n" +
@"                                ""Operating"": ""SV""," + "\n" +
@"                                ""Marketing"": ""SV""" + "\n" +
@"                            }" + "\n" +
@"                        }" + "\n" +
@"                    ]" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        ]," + "\n" +
@"        ""TravelPreferences"": {" + "\n" +
@"            ""TPA_Extensions"": {" + "\n" +
@"                ""JumpCabinLogic"": {" + "\n" +
@"                    ""Disabled"": true" + "\n" +
@"                }," + "\n" +
@"                ""KeepSameCabin"": {" + "\n" +
@"                    ""Enabled"": true" + "\n" +
@"                }," + "\n" +
@"                ""VerificationItinCallLogic"": {" + "\n" +
@"                    ""Value"": ""M""," + "\n" +
@"                    ""AlwaysCheckAvailability"": true" + "\n" +
@"                }" + "\n" +
@"            }" + "\n" +
@"        }," + "\n" +
@"        ""TravelerInfoSummary"": {" + "\n" +
@"            ""SeatsRequested"": [" + "\n" +
@"                2" + "\n" +
@"            ]," + "\n" +
@"            ""AirTravelerAvail"": [" + "\n" +
@"                {" + "\n" +
@"                    ""PassengerTypeQuantity"": [" + "\n" +
@"                        {" + "\n" +
@"                            ""Code"": ""ADT""," + "\n" +
@"                            ""Quantity"": 2," + "\n" +
@"                            ""TPA_Extensions"": {" + "\n" +
@"                                ""VoluntaryChanges"": {" + "\n" +
@"                                    ""Match"": ""Info""" + "\n" +
@"                                }" + "\n" +
@"                            }" + "\n" +
@"                        }" + "\n" +
@"                    ]" + "\n" +
@"                }" + "\n" +
@"            ]," + "\n" +
@"            ""PriceRequestInformation"": {" + "\n" +
@"                ""CurrencyCode"": ""SAR""," + "\n" +
@"                ""TPA_Extensions"": {}" + "\n" +
@"            }" + "\n" +
@"        }" + "\n" +
@"    }" + "\n" +
@"}";

            var response = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.revalidate), body, new Dictionary<string, string>()
                {
                     { "Authorization", "Bearer T1RLAQLQgrRGkqbkQ+14aqk1WW7hX0KVRFuX9ucg6hOOH9ahGhBqhxb6Xy0lhMvfQG0vjT4SAADQTsAANvCx45JiIzGaVf+r40VSDCPWfBOB0RcGYjWNGS1ddRxpfwv/R44rzoaQHPiCdZ5jkV7yCPZjd/ig8N6ydPyaTZVffBjOASqyGuI1faEb3Kk7pChgfY9e1KjHFrt9hUxZkKvZEsRKvNHCCA8DVfAroAOaMHIZ1gQUMQWxISEvPz+HHrtjtJtw11AMrJLFo+zk5XLqT+wPmq9d2d2hHWQUxBw8JD4QgbL7DzFHoGDap/VGpckuGR6WSe3APMYkXFaRT6lV+/pDlMxIZW27IA**" }
                });
            StreamReader readers = new(response.GetResponseStream());
            string responseText = readers.ReadToEnd();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                RevalidateResponseDto resulte = JsonConvert.DeserializeObject<RevalidateResponseDto>(responseText);
                return ResponseThirdPartyDto<dynamic>.Success(resulte);//response.groupedItineraryResponse.legDescs
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ///  اعمل التوكن تاني لمره وحده بس
                ErrorDTO responseError = JsonConvert.DeserializeObject<ErrorDTO>(responseText);
                return ResponseThirdPartyDto<dynamic>.Failure(responseError);
            }
            else
            {
                ErrorDTO responseError = JsonConvert.DeserializeObject<ErrorDTO>(responseText);
                return ResponseThirdPartyDto<dynamic>.Failure(responseError);
            }
        }
    }
}
