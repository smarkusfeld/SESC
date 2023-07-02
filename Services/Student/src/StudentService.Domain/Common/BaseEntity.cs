using StudentService.Domain.Interfaces;

namespace StudentService.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {        
        public virtual object Key { get; } 
    }
}
