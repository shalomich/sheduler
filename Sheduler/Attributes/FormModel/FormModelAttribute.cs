using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)] 
    public class FormModelAttribute : Attribute { }
}
