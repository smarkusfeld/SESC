using LibraryService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {        
        public virtual object Key { get; } 
    }
}
