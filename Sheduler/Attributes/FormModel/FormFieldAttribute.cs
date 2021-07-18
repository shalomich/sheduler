using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FormFieldAttribute : Attribute
    {
        public FormFieldType Type { get; }
        public bool IsRequired { get; }
        public string MetadataPath { get; }
        
        public FormFieldAttribute(FormFieldType type, bool isRequired = true, string metadataPath = null)
        {
            Type = type;
            IsRequired = isRequired;
            MetadataPath = metadataPath;
        }

    }

    public enum FormFieldType
    {
        Text,
        Number,
        Select,
        SelectMultiple,
        TextArea,
        Email,
        Password,
        Tel,
        Date,
        RadioButton
    }
}
