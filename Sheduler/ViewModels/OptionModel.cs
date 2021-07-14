using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record OptionModel(string Text, string Value)
    {
        public static OptionModel FromEnum(Enum enumItem)
        {
            string text = enumItem.ToString();
            string value = Convert.ToInt32(enumItem).ToString();

            return new OptionModel(text, value);
        }
    }
}
