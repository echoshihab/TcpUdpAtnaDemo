using System.ComponentModel;
using System.Dynamic;
using System.Xml.Serialization;

namespace MessageSender.Models;

public class CodedValueType
{
    public CodedValueType(Enum csdCode)
    {
        this.CsdCode = csdCode;
    }
    [XmlAttribute("csd-code")]
    public Enum CsdCode { get; set; }

    [XmlAttribute("codeSystemName")]
    public string? CodeSystemName {
        get
        {
            var categoryAttribute = TypeDescriptor.GetProperties(this)[nameof(this.CsdCode)]?.Attributes[typeof(CategoryAttribute)];
            return ((CategoryAttribute)categoryAttribute)?.Category;
        }
}

[XmlAttribute("displayName")]
    public string? DisplayName { get; set; }
    [XmlAttribute("originalText")]
    public string? OriginalText 
    {
        get
        {
            var descriptionAttribute = TypeDescriptor.GetProperties(this)[nameof(this.CsdCode)]?.Attributes[typeof(DescriptionAttribute)];
            return ((DescriptionAttribute)descriptionAttribute)?.Description;
        }
    }
}