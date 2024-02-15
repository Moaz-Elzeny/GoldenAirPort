using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.DTOs.Error;
using GoldenAirport.Application.Flights.DTOs.ShopeDto;
using GoldenAirport.Application.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace GoldenAirport.Application.Flights.ThirdParty
{
    public class ShoppingQuery
    {
       public ResponseThirdPartyDto<dynamic> Default()
        {
            var RequstData = new RequestDto();
            RequstData.OTA_AirLowFareSearchRQ.Version = "4";
            RequstData.OTA_AirLowFareSearchRQ.POS = new POS()
            {
                Source = new List<Source>()
                    {
                        new Source()
                        {
                            PseudoCityCode = "M9DL",
                            RequestorID = new RequestorID()
                            {
                                Type = "1",
                                ID = "1",
                                CompanyName = new CompanyName()
                                {
                                    Code = "TN",
                                }
                            }
                        },
                    },
            };
            RequstData.OTA_AirLowFareSearchRQ.OriginDestinationInformation = new List<OriginDestinationInformation>()
                {
                    new OriginDestinationInformation()
                    {
                        RPH = "1",
                        DepartureDateTime = DateTime.Parse("2024-03-01T00:00:00"),
                        OriginLocation = new OriginLocation()
                        {
                            LocationCode = "JED"
                        },
                        DestinationLocation = new DestinationLocation()
                        {
                            LocationCode = "CAI"
                        }
                    },
                    new OriginDestinationInformation()
                    {
                        RPH = "2",
                        DepartureDateTime = DateTime.Parse("2024-03-11T00:00:00"),
                        OriginLocation = new OriginLocation()
                        {
                            LocationCode = "CAI"
                        },
                        DestinationLocation = new DestinationLocation()
                        {
                            LocationCode = "JED"
                        }
                    },
                };
            RequstData.OTA_AirLowFareSearchRQ.TravelPreferences = new TravelPreferences()
            {
                ValidInterlineTicket = true,
                TPA_Extensions = new TPAExtensions()
                {
                    DataSources = new DataSources
                    {
                        NDC = "Disable",
                        ATPCO = "Enable",
                        LCC = "Disable"
                    },
                    PreferNDCSourceOnTie = new PreferNDCSourceOnTie()
                    {
                        Value = false
                    },
                    ExcludeCallDirectCarriers = new ExcludeCallDirectCarriers()
                    {
                        Enabled = true,
                    },
                    KeepSameCabin = new KeepSameCabin()
                    {
                        Enabled = false,
                    },
                },
                Baggage = new Baggage()
                {
                    Description = true,
                    RequestType = "A",
                },
                CabinPref = new List<CabinPref>()
                    {
                        new CabinPref()
                        {
                            Cabin = "Y",
                            PreferLevel = "Preferred"
                        }
                    }
            };
            RequstData.OTA_AirLowFareSearchRQ.TravelerInfoSummary = new TravelerInfoSummary()
            {
                AirTravelerAvail = new List<AirTravelerAvail>
                    {
                        new AirTravelerAvail()
                        {
                            PassengerTypeQuantity = new List<PassengerTypeQuantity>()
                            {
                                new PassengerTypeQuantity()
                                {
                                    Code = "ADT",
                                    Quantity = 1,
                                    TPA_Extensions = new TPAExtensions1()
                                    {
                                        VoluntaryChanges = new VoluntaryChanges()
                                        {
                                            Match = "Info"
                                        }
                                    }
                                },
                                new PassengerTypeQuantity()
                                {
                                    Code = "CNN",
                                    Quantity = 1,
                                    TPA_Extensions = new TPAExtensions1()
                                    {
                                        VoluntaryChanges = new VoluntaryChanges()
                                        {
                                            Match = "Info"
                                        }
                                    }
                                },
                                new PassengerTypeQuantity()
                                {
                                    Code = "INF",
                                    Quantity = 1,
                                    TPA_Extensions = new TPAExtensions1()
                                    {
                                        VoluntaryChanges = new VoluntaryChanges()
                                        {
                                            Match = "Info"
                                        }
                                    }
                                },
                            },
                        }
                    }
            };
            RequstData.OTA_AirLowFareSearchRQ.TPA_Extensions = new TPAExtensions2()
            {
                IntelliSellTransaction = new IntelliSellTransaction()
                {
                    RequestType = new RequestType()
                    {
                        Name = "200ITINS",
                    },
                    CompressResponse = new CompressResponse()
                    {
                        Value = false
                    },
                    TravelerPersona = new TravelerPersona()
                    {
                        Name = "Test"
                    }
                }
            };

            var bodyData = RequstData.ConvertToJson();
            var responce = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.shop), bodyData, new Dictionary<string, string>()
                {
                     { "Authorization", "Bearer T1RLAQLQgrRGkqbkQ+14aqk1WW7hX0KVRFuX9ucg6hOOH9ahGhBqhxb6Xy0lhMvfQG0vjT4SAADQTsAANvCx45JiIzGaVf+r40VSDCPWfBOB0RcGYjWNGS1ddRxpfwv/R44rzoaQHPiCdZ5jkV7yCPZjd/ig8N6ydPyaTZVffBjOASqyGuI1faEb3Kk7pChgfY9e1KjHFrt9hUxZkKvZEsRKvNHCCA8DVfAroAOaMHIZ1gQUMQWxISEvPz+HHrtjtJtw11AMrJLFo+zk5XLqT+wPmq9d2d2hHWQUxBw8JD4QgbL7DzFHoGDap/VGpckuGR6WSe3APMYkXFaRT6lV+/pDlMxIZW27IA**" }
                });
            StreamReader readers = new(responce.GetResponseStream());
            string responseText = readers.ReadToEnd();
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                ResponseDto response = JsonConvert.DeserializeObject<ResponseDto>(responseText);
                return ResponseThirdPartyDto<dynamic>.Success(response);
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
