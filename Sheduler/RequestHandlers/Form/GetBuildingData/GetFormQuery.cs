using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RequestHandlers.Form.GetBuildingData
{
    public class GetFormQuery : IRequest<IEnumerable<object>>
    {
        [Required]
        public Type ModelType { set; get; }
    }
}
