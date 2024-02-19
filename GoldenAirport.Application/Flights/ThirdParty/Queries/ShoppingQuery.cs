using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.ThirdParty.Commands;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.Error;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.ShopeDto;
using GoldenAirport.Application.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace GoldenAirport.Application.Flights.ThirdParty.Queries
{
    public class ShoppingQuery
    {

        public ResponseThirdPartyDto<dynamic> Default()
        {
            var RequstData = new ShoppingRequestDto();
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
            var response = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.shop), bodyData, new Dictionary<string, string>()
                {
                     { "Authorization", "Bearer T1RLAQKRtGkBV4h4nmclbxuZeE1LQ41ma5avQQrUBm6UA3Ke/xA6fchgh6MZvI5jTl6/Rjs3AADQcts7/1m6j4VH5+/csa5gPXRnRL9N3NMZoTW5lxd1iggZkOaZvF+SPEd+m8NWDuF4dS1T36WkgNyumjGvnRD79qeOym11HJWYtmHxk1MAH7p1KDfWe2cyXAzr9JSyFyO9gpsNGkOY94mDGkbp2JH23qGa8s2bIGT4AOhQGLY3dPonn3cvCOKdsxLFZiDqHbX0lA0ScskT0bBJisLX0OIhrczJiRgnKt/Za7rqJKiG/SgMHkTkTRuKdCrTDZagTHagLn/68kSGC1VnUskcphIR1Q**" }
                });
            StreamReader readers = new(response.GetResponseStream());
            string responseText = readers.ReadToEnd();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ShoppingResponseDto resulte = JsonConvert.DeserializeObject<ShoppingResponseDto>(responseText);
                return ResponseThirdPartyDto<dynamic>.Success(resulte);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var tokenCreateCommand = new TokenCreateCommand();
                var result = tokenCreateCommand.RQ();
                response = HttpWebResponseHelper.Post(HttpMethod.Post, Enviroment.rest_endpoint + EnumHelper.GetEnumDescription(Enviroment.Endpoints.shop), bodyData, new Dictionary<string, string>()
                {
                    { "Authorization", $"Bearer {result.Result}" }
                });
                 readers = new(response.GetResponseStream());
                responseText = readers.ReadToEnd();
               
                ShoppingResponseDto resulte = JsonConvert.DeserializeObject<ShoppingResponseDto>(responseText);
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
