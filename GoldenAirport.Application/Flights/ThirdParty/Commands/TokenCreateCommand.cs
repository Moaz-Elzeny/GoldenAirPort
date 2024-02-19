using GoldenAirport.Application.Common.Models;
using GoldenAirport.Application.Flights.ThirdParty.Dtos.Error;
using GoldenAirport.Application.Helpers;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Xml;

namespace GoldenAirport.Application.Flights.ThirdParty.Commands
{
    public class TokenCreateCommand
    {
        public ResponseThirdPartyDto<dynamic> RQ()
        {
            var body = @"	<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
@"	    <SOAP-ENV:Header>" + "\n" +
@"	        <MessageHeader xmlns=""http://www.ebxml.org/namespaces/messageHeader"">" + "\n" +
@"	            <From>" + "\n" +
@"	                <PartyId>Agency</PartyId>" + "\n" +
@"	            </From>" + "\n" +
@"	            <To>" + "\n" +
@"	                <PartyId>SWS</PartyId>" + "\n" +
@"	            </To>" + "\n" +
@"	            <ConversationId>MyConvID</ConversationId>" + "\n" +
@"	            <Action>TokenCreateRQ</Action>" + "\n" +
@"	        </MessageHeader>" + "\n" +
@"	        <Security xmlns=""http://schemas.xmlsoap.org/ws/2002/12/secext"">" + "\n" +
@"	            <UsernameToken>" + "\n" +
@"	                <Username>735281</Username>" + "\n" +
@"	                <Password>TA21IF43</Password>" + "\n" +
@"	                <Organization>M9DL</Organization>" + "\n" +
@"	                <Domain>DEFAULT</Domain>" + "\n" +
@"	            </UsernameToken>" + "\n" +
@"	        </Security>" + "\n" +
@"	    </SOAP-ENV:Header>" + "\n" +
@"	    <SOAP-ENV:Body>" + "\n" +
@"	        <TokenCreateRQ Version=""1.0.0"" xmlns=""http://webservices.sabre.com""/>" + "\n" +
@"	    </SOAP-ENV:Body>" + "\n" +
@"	</SOAP-ENV:Envelope>";

            var response = HttpWebResponseHelper.Post(HttpMethod.Post, EnumHelper.GetEnumDescription(Enviroment.soap_endpoint), body, new Dictionary<string, string>()
                {
                     //{ "Authorization", "Bearer T1RLAQLQgrRGkqbkQ+14aqk1WW7hX0KVRFuX9ucg6hOOH9ahGhBqhxb6Xy0lhMvfQG0vjT4SAADQTsAANvCx45JiIzGaVf+r40VSDCPWfBOB0RcGYjWNGS1ddRxpfwv/R44rzoaQHPiCdZ5jkV7yCPZjd/ig8N6ydPyaTZVffBjOASqyGuI1faEb3Kk7pChgfY9e1KjHFrt9hUxZkKvZEsRKvNHCCA8DVfAroAOaMHIZ1gQUMQWxISEvPz+HHrtjtJtw11AMrJLFo+zk5XLqT+wPmq9d2d2hHWQUxBw8JD4QgbL7DzFHoGDap/VGpckuGR6WSe3APMYkXFaRT6lV+/pDlMxIZW27IA**" }
                },contentType: "text/xml");
            StreamReader readers = new(response.GetResponseStream());
            string responseText = readers.ReadToEnd();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //string soapResponse = "<soapenv:Envelope>...</soapenv:Envelope>";

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(responseText);
                var token ="";
                // Check if the root element is 'soapenv:Envelope'
                if (xmlDoc.DocumentElement?.Name == "soap-env:Envelope")
                {
                   token = xmlDoc.DocumentElement.FirstChild.LastChild.InnerText;

                }

                //XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                //using (StringReader reader = new StringReader(responseText))
                //{
                    //var dsSet = new DataSet();
                    //Envelope resulte = (Envelope)serializer.Deserialize(reader);
                    return ResponseThirdPartyDto<dynamic>.Success(token);
                //}
                
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
        public DataSet J_ConvertXmlToDataSet(string xmlPhysicalFilePath, XmlReadMode readMode)
        {
            DataSet J_DataSet = new DataSet();

            J_DataSet.ReadXml(xmlPhysicalFilePath, readMode);
            return (J_DataSet);
        }
    }
}
