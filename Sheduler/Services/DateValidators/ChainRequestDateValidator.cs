using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Services.DateValidators
{
    public abstract class ChainRequestDateValidator : IRequestDateValidator
    {
        protected ChainRequestDateValidator NextValidator;

        public ChainRequestDateValidator SetNextValidator(ChainRequestDateValidator nextValidator)
        {
            NextValidator = nextValidator;
            return NextValidator;
        }
        public abstract void Validate(Request validatedRequest);
        
    }
}
