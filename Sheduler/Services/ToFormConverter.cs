using Microsoft.Extensions.Configuration;
using Sheduler.Attributes;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sheduler.Services
{
    public class ToFormConverter
    {
        public IEnumerable<object> Convert(Type modelType)
        {
            PropertyInfo[] properties = modelType.GetProperties();

            var form = new HashSet<FormField>();

            foreach(var property in properties)
            {
                var fieldAttribute = property
                    .GetCustomAttribute<FormFieldAttribute>();

                if (fieldAttribute == null)
                    continue;
                
                form.Add(
                    new FormField(
                        name: property.Name, 
                        type: fieldAttribute.Type.ToString(),
                        isRequired: fieldAttribute.IsRequired
                    ));
            }

            return form;
        }

        private class FormField
        {
            public string Name { get; }
            public string Type { get; }
            public bool IsRequired { get; }
            public FormField(string name, string type, bool isRequired)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
                Type = type ?? throw new ArgumentNullException(nameof(type));
                IsRequired = isRequired;
            }

            public override bool Equals(object obj)
            {
                return obj is FormField field ? this.Name == field.Name : false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name);
            }
        }
    }

}
