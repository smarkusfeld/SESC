﻿using RegistrarService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarService.Domain.Entities
{ 
    /// <summary>
    /// Academic Year Entity
    /// </summary>
    public class AcademicYear : BaseAuditableEntity
    {
        public AcademicYear(int startYear, int endYear) 
        { 
            StartYear = startYear;
            EndYear = endYear;
        }
        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        [NotMapped]
        public string Name => StartYear.ToString() + "/" + EndYear.ToString();

        //navigation properities
        public ICollection<CourseLevel> CourseLevels { get; set; } = new List<CourseLevel>();


    }
}
