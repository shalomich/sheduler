using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public partial class StatusGraph
    {
        private class StatusNode
        {
            public StatusNode(RequestStatus status)
            {
                Status = status;
            }

            public RequestStatus Status { private set; get; }
            public ISet<StatusNode> NextStatuses { set; get; }

            public override bool Equals(object obj)
            {
                return obj is StatusNode node ? this.Status == node.Status : false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Status);
            }
        }
    }
    
}
