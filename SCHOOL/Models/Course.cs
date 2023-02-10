using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseRecords = new HashSet<CourseRecord>();
            GradeRecords = new HashSet<GradeRecord>();
        }
        [Key]

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public bool IsActive { get; set; }
        public int HeadTeacherId { get; set; }

        public virtual Teacher HeadTeacher { get; set; } = null!;
        public virtual ICollection<CourseRecord> CourseRecords { get; set; }
        public virtual ICollection<GradeRecord> GradeRecords { get; set; }
    }
}
