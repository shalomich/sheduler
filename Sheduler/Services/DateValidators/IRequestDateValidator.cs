using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Services.DateValidators
{
    public interface IRequestDateValidator
    {
        public void Validate(Request validatedRequest);
    }
}
