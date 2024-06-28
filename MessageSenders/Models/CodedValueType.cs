using System.ComponentModel;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace MessageSender.Models;

public class CodedValueType
{
    public CodedValueType()
    {
        
    }
    public CodedValueType(Enum csdCode)
    {
        this.Code = csdCode;
    }
    
    [XmlIgnore]
    public Enum Code { get; set; }

    [XmlAttribute("csd-code")]
    public string CsdCode => this.Code.ToString();

    [XmlAttribute("codeSystemName")]
    public string? CodeSystemName
    {
        get
        {
            var enumType = this.Code.GetType();
            var enumValueName = Enum.GetName(this.Code.GetType(), this.Code) ?? string.Empty;
            var fieldInfo = enumType.GetField(enumValueName);
            return fieldInfo != null ? fieldInfo.GetCustomAttribute<CategoryAttribute>()?.Category : null;
        }
    }

    [XmlAttribute("displayName")]
    public string? DisplayName { get; set; }
    [XmlAttribute("originalText")]
    public string? OriginalText 
    {
        get
        {
            var enumType = this.Code.GetType();
            var enumValueName = Enum.GetName(this.Code.GetType(), this.Code) ?? string.Empty;
            var fieldInfo = enumType.GetField(enumValueName);
            return fieldInfo != null ? fieldInfo.GetCustomAttribute<DescriptionAttribute>()?.Description : null;
        }
    }
}