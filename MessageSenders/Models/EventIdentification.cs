using System.Xml.Serialization;
using MessageSender.Enums;

namespace MessageSender.Models;

public class EventIdentification
{
    [XmlElement]
    public CodedValueType EventID { get; set; }
    [XmlElement]
    public CodedValueType EventTypeCode { get; set; }
    [XmlAttribute]
    public EventActionCode EventActionCode { get; set; }
    [XmlAttribute]
    public DateTime EventDateTime { get; set; }
    [XmlAttribute]
    public EventOutcomeIndicator EvenOutcomeIndicator { get; set; }
    [XmlElement]
    public string? EventOutcomeDescription { get; set; }
    private bool ShouldSerializeEventOutcomeDescription() => !string.IsNullOrEmpty(this.EventOutcomeDescription);
}