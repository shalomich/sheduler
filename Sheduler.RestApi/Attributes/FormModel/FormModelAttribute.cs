using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)] 
    public class FormModelAttribute : Attribute 
    {
        public string FormModelName { private set; get; }

        public FormModelAttribute(string formModelName)
        {
            FormModelName = formModelName ?? throw new ArgumentNullException(nameof(formModelName));
        }
    }
}
