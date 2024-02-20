using RegistrarService.Domain.Interfaces;

namespace RegistrarService.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {        
        public virtual object Key { get; } 
    }
}
