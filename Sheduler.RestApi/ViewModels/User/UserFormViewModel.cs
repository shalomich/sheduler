using Sheduler.RestApi.Attributes;
using Sheduler.RestApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.ViewModels
{
    [FormModel("user")]
    public class UserFormViewModel
    {   
        public int? Id { set; get; }
        [FormField(FormFieldType.Email)]
        [EmailAddress]
        [Required]
        public string Email { set; get; }

        [FormField(FormFieldType.Text,"Пароль")]
        [Required]
        public string Password { set; get; }

        [FormField(FormFieldType.Text, "Фио", false)]
        [RegularExpression("^[А-ЯЁ][а-яё]* [А-ЯЁ][а-яё]* [А-ЯЁ][а-яё]*$")]
        public string Name { set; get; }

        [FormField(FormFieldType.Select, "Роль", false, "user/role")]
        public UserRole? Role { set; get; }

        [FormField(FormFieldType.Select, "Должность", false, "user/post")]
        public int? PostId{ set; get; }
        
        [FormField(FormFieldType.Tel, "Номер телефона", false)]
        [RegularExpression(@"89\d{9}")]
        public string PhoneNumber { set; get; }
    }

}