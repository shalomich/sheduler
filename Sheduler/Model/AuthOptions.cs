using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheduler.Model
{
    public class AuthOptions
    {
        public string Key { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public int Lifetime { set; get; }
        public SymmetricSecurityKey GenerateSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
