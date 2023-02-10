using System;
using System.Collections.Generic;

namespace SCHOOL.Models
{
    public partial class ExtrastudInfo
    {
        public string Student { get; set; } = null!;
        public int StudentId { get; set; }
        public string ClassName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int GradeValue { get; set; }
        public string Teacher { get; set; } = null!;
        public int TeacherId { get; set; }
    }
}
