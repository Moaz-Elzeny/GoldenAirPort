using System.ComponentModel;

namespace GoldenAirport.Application.Helpers
{
    public static class Enviroment
    {
        public static string soap_endpoint = "https://webservices.cert.platform.sabre.com";
        public static string rest_endpoint = "https://api.cert.platform.sabre.com";
        public static string username = "735281";
        public static string password = "TA21IF43";
        public static string pcc = "M9DL";
        public static string pcc_tkt = "XXXX";
        public static string country_code = "AT";
        public static string ptrta = "XXXXXX";
        public static string client_id = "XXXXXX";
        public static string client_secret = "XXXXXX";
        public static string conv_id = "2021.01.DevStudio";
        public static string pnr = "RYASNM";
        public static string header = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP-ENV:Header><MessageHeader xmlns=\"http://www.ebxml.org/namespaces/messageHeader\"><From><PartyId>Agency</PartyId></From><To><PartyId>SWS</PartyId></To><ConversationId>ConversationId</ConversationId><Action>BFM</Action></MessageHeader><Security xmlns=\"http://schemas.xmlsoap.org/ws/2002/12/secext\"><BinarySecurityToken EncodingType=\"Base64Binary\" valueType=\"String\">T1RLAQLQgrRGkqbkQ+14aqk1WW7hX0KVRFuX9ucg6hOOH9ahGhBqhxb6Xy0lhMvfQG0vjT4SAADQTsAANvCx45JiIzGaVf+r40VSDCPWfBOB0RcGYjWNGS1ddRxpfwv/R44rzoaQHPiCdZ5jkV7yCPZjd/ig8N6ydPyaTZVffBjOASqyGuI1faEb3Kk7pChgfY9e1KjHFrt9hUxZkKvZEsRKvNHCCA8DVfAroAOaMHIZ1gQUMQWxISEvPz+HHrtjtJtw11AMrJLFo+zk5XLqT+wPmq9d2d2hHWQUxBw8JD4QgbL7DzFHoGDap/VGpckuGR6WSe3APMYkXFaRT6lV+/pDlMxIZW27IA**</BinarySecurityToken></Security></SOAP-ENV:Header><SOAP-ENV:Body>";
        public static string header_diag = "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP-ENV:Header><MessageHeader xmlns=\"http://www.ebxml.org/namespaces/messageHeader\"><From><PartyId>Agency</PartyId></From><To><PartyId>SWS</PartyId></To><ConversationId>ConversationId</ConversationId><Action>BFM</Action></MessageHeader><Security xmlns=\"http://schemas.xmlsoap.org/ws/2002/12/secext\"><BinarySecurityToken EncodingType=\"Base64Binary\" valueType=\"String\">T1RLAQLQgrRGkqbkQ+14aqk1WW7hX0KVRFuX9ucg6hOOH9ahGhBqhxb6Xy0lhMvfQG0vjT4SAADQTsAANvCx45JiIzGaVf+r40VSDCPWfBOB0RcGYjWNGS1ddRxpfwv/R44rzoaQHPiCdZ5jkV7yCPZjd/ig8N6ydPyaTZVffBjOASqyGuI1faEb3Kk7pChgfY9e1KjHFrt9hUxZkKvZEsRKvNHCCA8DVfAroAOaMHIZ1gQUMQWxISEvPz+HHrtjtJtw11AMrJLFo+zk5XLqT+wPmq9d2d2hHWQUxBw8JD4QgbL7DzFHoGDap/VGpckuGR6WSe3APMYkXFaRT6lV+/pDlMxIZW27IA**</BinarySecurityToken></Security><Diagnostics xmlns=\"http://webservices.sabre.com\"/></SOAP-ENV:Header><SOAP-ENV:Body>";
        public static string footer = "</SOAP-ENV:Body></SOAP-ENV:Envelope>";

        public enum Endpoints
        {
            [Description("/v4/offers/shop")]
            shop = 1, 
            
            [Description("/v4/shop/flights/revalidate")]
            revalidate = 2,

            [Description("/v2.4.0/passenger/records?mode=create")]
            create = 3,
        }

    }
}
