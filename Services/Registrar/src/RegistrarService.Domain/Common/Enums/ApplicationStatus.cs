using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Common.Enums
{
    /// <summary>
    /// Application Status Enum
    /// </summary>
    public enum ApplicationStatus
    {
        InProgress,
        Received,
        UnderReview,
        Referred,
        Deferred,
        Waitlisted,
        Rejected,
        Offer,
        ConditionalOffer,
        Accepted,
        Declined,
        Withdrawn

    }
}
