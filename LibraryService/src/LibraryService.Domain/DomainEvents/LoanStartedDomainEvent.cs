using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.DomainEvents
{
    public class LoanStartedDomainEvent : INotification
    {
        public LoanStartedDomainEvent() { }
    }
}
