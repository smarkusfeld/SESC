using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common;

namespace LibraryService.Domain.Common.Interfaces
{
    /// <summary>
    /// IEntity interface will be implemented by all domain entities directly or indirectly
    /// </summary>
    public interface IEntity
    {
        public object Key { get; }


    }
}
