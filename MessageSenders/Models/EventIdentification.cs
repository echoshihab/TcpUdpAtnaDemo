using System.Xml.Serialization;

namespace MessageSender.Models;

public class EventIdentification
{
    [XmlElement]
    public EventId EventID { get; set; }
    [XmlElement]
    public EventTypeCode EventTypeCode { get; set; }
    [XmlAttribute]
    public string EventActionCode { get; set; }
    [XmlAttribute]
    public DateTime EventDateTime { get; set; }
    [XmlAttribute]
    public string EvenOutcomeIndicator { get; set; }
    [XmlElement]
    public string EventOutcomDescription { get; set; }
}