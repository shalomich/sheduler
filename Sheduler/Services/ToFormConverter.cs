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
        public record FormField(string Name, string Type, bool IsRequired);

        public IEnumerable<FormField> Convert(string formModelName)
        {
            Type formModelType = GetType().Assembly.GetTypes()
            .Single(type => type
                .GetCustomAttribute<FormModelAttribute>()
                    ?.FormModelName == formModelName);
            
            PropertyInfo[] properties = formModelType.GetProperties();

            var form = new HashSet<FormField>();

            foreach(var property in properties)
            {
                var fieldAttribute = property
                    .GetCustomAttribute<FormFieldAttribute>();

                if (fieldAttribute == null)
                    continue;
                
                form.Add(
                    new FormField(
                        Name: property.Name, 
                        Type: fieldAttribute.Type.ToString(),
                        IsRequired: fieldAttribute.IsRequired
                    ));
            }

            return form;
        }
    }

}
