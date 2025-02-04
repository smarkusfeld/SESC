using RegistrarService.Domain.Interfaces;

namespace RegistrarService.Domain.Common
{
    /// <summary>
    /// Base class for Auditable entity 
    /// </summary>
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy {get; set;}
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
