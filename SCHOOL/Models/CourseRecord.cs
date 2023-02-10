using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class CourseRecord
    {
        [Key]

        public int CourseRecordId { get; set; }
        public int CourseNameId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public virtual Course CourseName { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
    }
}
