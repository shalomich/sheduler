using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FormFieldAttribute : Attribute
    {
        public FormFieldType Type { get; }
        public string Text { get; }
        public bool IsRequired { get; }
        public string Metadata { get; }
        public FormFieldAttribute(FormFieldType type, string text = null, bool isRequired = true, string metadata = null)
        {
            Type = type;
            IsRequired = isRequired;
            Metadata = metadata;
            Text = text;
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
        Radio
    }
}
