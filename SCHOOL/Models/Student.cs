using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseRecords = new HashSet<CourseRecord>();
            GradeRecords = new HashSet<GradeRecord>();
        }
        [Key]

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual ICollection<CourseRecord> CourseRecords { get; set; }
        public virtual ICollection<GradeRecord> GradeRecords { get; set; }
    }
}
