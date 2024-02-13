using Microsoft.EntityFrameworkCore;
using StudentService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Domain.Entities
{
    /// <summary>
    /// Session module entity 
    /// Part of <seealso cref="CourseLevel"/> Aggregate
    /// </summary>
   
    public class SessionModule: BaseAuditableEntity
    {
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public SessionModule() { }

        /// <summary>
        /// Internal constructor for session module used by <seealso cref="Session"/>
        /// </summary>
        /// <param name="moduleId"></param>
        internal SessionModule(int moduleId) 
        {
            ModuleId = moduleId;
        }
        public int ModuleId { get; private set; }
        public int SessionId { get; private set; }
        public CourseModule CourseModule { get; private set; }
        public Session Session { get; private set; }
    }
}
