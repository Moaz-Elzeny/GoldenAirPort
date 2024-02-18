using System.Xml.Serialization;

namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.TokenDto
{

    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Envelope)serializer.Deserialize(reader);
    // }

    public class PartyId
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class From
    {
        public PartyId PartyId { get; set; }
    }

    public class To
    {
        public PartyId PartyId { get; set; }
    }

    public class Service
    {
        public string type { get; set; }
        public string text { get; set; }
    }

    public class MessageData
    {
        public double MessageId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class MessageHeader
    {
        public From From { get; set; }
        public To To { get; set; }
        public string ConversationId { get; set; }
        public Service Service { get; set; }
        public string Action { get; set; }
        public MessageData MessageData { get; set; }
        public string eb { get; set; }
        public double version { get; set; }
        public int mustUnderstand { get; set; }
        public string text { get; set; }
    }

    public class BinarySecurityToken
    {
        public string valueType { get; set; }
        public string EncodingType { get; set; }
        public string text { get; set; }
    }

    public class Security
    {
        public BinarySecurityToken BinarySecurityToken { get; set; }
        public string wsse { get; set; }
        public string text { get; set; }
    }

    public class Header
    {
        public MessageHeader MessageHeader { get; set; }
        public Security Security { get; set; }
    }

    public class TokenCreateRS
    {
        public object Success { get; set; }
        public string sws { get; set; }
        public string Version { get; set; }
    }

    public class Body
    {
        public TokenCreateRS TokenCreateRS { get; set; }
    }

    public class Envelope
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
        //public string soap-env { get; set; }
        public string text { get; set; }
    }
}


