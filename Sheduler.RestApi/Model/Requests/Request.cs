using Sheduler.RestApi.Attributes;
using Sheduler.RestApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model.Requests
{
    public abstract class Request : IEntity
    {
        private const string WrongNewStatus = "Impossible change status from {0} to {1}";

        private DateTime? _sendingDate = DateTime.MinValue;
        private RequestStatus _currentStatus = RequestStatus.Created;
        public int Id {set; get; }
        public abstract string Type { get; }
        
        public RequestStatus Status => _currentStatus;
        
        public ISet<DateTime> ChoosendDates { set; get; }
        
        public int? DayQuantity => ChoosendDates?.Count;
        
        public DateTime CreationDate { private set; get; } = DateTime.Now.Date;
        public DateTime? SendingDate
        {
            set 
            {
                if (value < CreationDate)
                    throw new ArgumentException();
                _sendingDate = value;
            }
            get
            {
                return _sendingDate;
            }
        }
        public User Creator { set; get; }
        public int CreatorId {set; get; }        
        public string Comment { set; get; }
        public User Approving { set; get; }
        public int? ApprovingId {set; get; }

        public void ChangeStatus(RequestStatus newStatus)
        {
            if (StatusGraph.Instance.CanChangeStatus(_currentStatus, newStatus) == false)
                throw new ArgumentException(String.Format(WrongNewStatus, _currentStatus, newStatus));

            _currentStatus = newStatus;
        }
    }

    
    
}
