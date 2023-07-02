using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Interfaces
{
    /// <summary>
    /// IEntity interface will be implemented by all domain entities directly or indirectly
    /// </summary>
    public interface IEntity 
    {
        /// <summary>
        /// Read only key property for entity. Not mapped to database
        /// </summary>
        public object Key { get; }

    }
}
