//using System.Xml.Serialization;

//namespace GoldenAirport.Application.Flights.ThirdParty.Dtos.TokenDto
//{
//    //public class TokenRequestDto
//    //{
//    //}
//    // using System.Xml.Serialization;
//    // XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
//    // using (StringReader reader = new StringReader(xml))
//    // {
//    //    var test = (Envelope)serializer.Deserialize(reader);
//    // }

//    [XmlRoot(ElementName = "From")]
//    public class From
//    {

//        [XmlElement(ElementName = "PartyId")]
//        public string PartyId { get; set; }
//    }

//    [XmlRoot(ElementName = "To")]
//    public class To
//    {

//        [XmlElement(ElementName = "PartyId")]
//        public string PartyId { get; set; }
//    }

//    [XmlRoot(ElementName = "MessageHeader")]
//    public class MessageHeader
//    {

//        [XmlElement(ElementName = "From")]
//        public From From { get; set; }

//        [XmlElement(ElementName = "To")]
//        public To To { get; set; }

//        [XmlElement(ElementName = "ConversationId")]
//        public string ConversationId { get; set; }

//        [XmlElement(ElementName = "Action")]
//        public string Action { get; set; }

//        [XmlAttribute(AttributeName = "xmlns")]
//        public string xmlns { get; set; }

//        [XmlText]
//        public string text { get; set; }
//    }

//    [XmlRoot(ElementName = "UsernameToken")]
//    public class UsernameToken
//    {

//        [XmlElement(ElementName = "Username")]
//        public string Username { get; set; }

//        [XmlElement(ElementName = "Password")]
//        public string Password { get; set; }

//        [XmlElement(ElementName = "Organization")]
//        public string Organization { get; set; }

//        [XmlElement(ElementName = "Domain")]
//        public string Domain { get; set; }
//    }

//    [XmlRoot(ElementName = "Security")]
//    public class Security
//    {

//        [XmlElement(ElementName = "UsernameToken")]
//        public UsernameToken UsernameToken { get; set; }

//        [XmlAttribute(AttributeName = "xmlns")]
//        public string xmlns { get; set; }

//        [XmlText]
//        public string text { get; set; }
//    }

//    [XmlRoot(ElementName = "Header")]
//    public class Header
//    {

//        [XmlElement(ElementName = "MessageHeader")]
//        public MessageHeader MessageHeader { get; set; }

//        [XmlElement(ElementName = "Security")]
//        public Security Security { get; set; }
//    }

//    [XmlRoot(ElementName = "TokenCreateRQ")]
//    public class TokenCreateRQ
//    {

//        [XmlAttribute(AttributeName = "Version")]
//        public string Version { get; set; }

//        [XmlAttribute(AttributeName = "xmlns")]
//        public string xmlns { get; set; }
//    }

//    [XmlRoot(ElementName = "Body")]
//    public class Body
//    {

//        [XmlElement(ElementName = "TokenCreateRQ")]
//        public TokenCreateRQ TokenCreateRQ { get; set; }
//    }

//    [XmlRoot(ElementName = "TokenRequestDto")]
//    public class TokenRequestDto
//    {

//        [XmlElement(ElementName = "Header")]
//        public Header Header { get; set; }

//        [XmlElement(ElementName = "Body")]
//        public Body Body { get; set; }

//        [XmlAttribute(AttributeName = "SOAP-ENV")]
//        public string SOAPENV { get; set; }

//        [XmlText]
//        public string text { get; set; }
//    }


//}
