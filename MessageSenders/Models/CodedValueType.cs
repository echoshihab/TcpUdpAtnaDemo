using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;

namespace MessageSender.Models;

public class CodedValueType
{

    private string _csdCode;
    private string? _codeSystemName;
    private string? _originalText;
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
    public string CsdCode
    {
        get => this.Code.ToString();
        set => this._csdCode = value; 
    }

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
        set => this._codeSystemName = value;
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
        set => this._originalText = value;
    }

}