using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model.Requests
{
    public partial class StatusGraph
    {
        private ISet<StatusNode> _nodes;

        private static readonly Lazy<StatusGraph> _statusGraph = new Lazy<StatusGraph>(() => new StatusGraph());
        public static StatusGraph Instance => _statusGraph.Value;
        private StatusGraph()
        {
            var createdNode = new StatusNode(RequestStatus.Created);
            var sentNode = new StatusNode(RequestStatus.Sent);
            var approvedNode = new StatusNode(RequestStatus.Approved);
            var notApprovedNode = new StatusNode(RequestStatus.Disapproved);
            var allowedNode = new StatusNode(RequestStatus.Allowed);
            var notAllowedNode = new StatusNode(RequestStatus.Disallowed);
            var withdrawnNode = new StatusNode(RequestStatus.Withdrawn);
            var canceledNode = new StatusNode(RequestStatus.Cancelled);

            createdNode.NextStatuses = new HashSet<StatusNode> { sentNode, canceledNode };
            sentNode.NextStatuses = new HashSet<StatusNode> { approvedNode, notApprovedNode, withdrawnNode, canceledNode };
            approvedNode.NextStatuses = new HashSet<StatusNode> { allowedNode, notAllowedNode, canceledNode };
            notApprovedNode.NextStatuses = new HashSet<StatusNode> { withdrawnNode, canceledNode };
            allowedNode.NextStatuses = new HashSet<StatusNode> { canceledNode };
            notAllowedNode.NextStatuses = new HashSet<StatusNode> { withdrawnNode, canceledNode };
            withdrawnNode.NextStatuses = new HashSet<StatusNode> { sentNode, canceledNode };

            _nodes = new HashSet<StatusNode> { createdNode, sentNode, approvedNode, notApprovedNode, allowedNode, notAllowedNode, withdrawnNode, canceledNode };
        }
        public bool CanChangeStatus(RequestStatus currentStatus, RequestStatus newStatus)
        {
            var currentNode = _nodes.SingleOrDefault(node => node.Status == currentStatus);

            var nextStatusNode = currentNode?.NextStatuses
                .SingleOrDefault(nextNode => nextNode.Status == newStatus);

            if (nextStatusNode == null)
                return false;

            return true;
        }
    }
}
