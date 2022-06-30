using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Services.DateValidators
{
    public interface IRequestDateValidator
    {
        public void Validate(Request validatedRequest);
    }
}
