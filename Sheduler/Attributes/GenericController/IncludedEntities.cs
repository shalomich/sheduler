using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sheduler.Services
{
    public static class IncludedEntities 
    { 
        public static IReadOnlyList<TypeInfo> Types; 
        static IncludedEntities() 
        { 
            var assembly = typeof(IncludedEntities).GetTypeInfo().Assembly; 
            var typeList = new List<TypeInfo>(); 
            foreach (Type type in assembly.GetTypes()) 
            { 
                if (type.GetCustomAttributes(typeof(FormModelAttribute), true).Length > 0) 
                { 
                    typeList.Add(type.GetTypeInfo()); 
                } 
            } 
            Types = typeList; 
        } 
    }
}
