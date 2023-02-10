using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            CourseRecords = new HashSet<CourseRecord>();
            Courses = new HashSet<Course>();
            GradeRecords = new HashSet<GradeRecord>();
        }

        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public decimal Salary { get; set; }
        public DateTime HiredSinceDate { get; set; }
        public int StaffId { get; set; }
        public bool Hired { get; set; }

        public virtual staff Staff { get; set; } = null!;
        public virtual ICollection<CourseRecord> CourseRecords { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<GradeRecord> GradeRecords { get; set; }
    }
}
