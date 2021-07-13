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
        public FormFieldAttribute(FormFieldType type, bool isRequired = true)
        {
            Type = type;
            IsRequired = isRequired; 
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
