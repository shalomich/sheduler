using Microsoft.Extensions.Configuration;
using Sheduler.Attributes;
using Sheduler.Extensions;
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
        public record FormField(string Name, string Text, string Type, bool IsRequired, string Metadata);

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

                string name = property.Name.FirstCharToLowerCase();
                form.Add(
                    new FormField(
                        Name: name,
                        Text: fieldAttribute.Text ?? name,
                        Type: fieldAttribute.Type.ToString().ToLower(),
                        IsRequired: fieldAttribute.IsRequired,
                        Metadata: fieldAttribute.Metadata
                    ));
            }

            return form;
        }
    }

}
