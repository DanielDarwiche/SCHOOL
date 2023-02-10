using System;
using System.Collections.Generic;

namespace SCHOOL.Models
{
    public partial class ExtraTeacher
    {
        public string Teacher { get; set; } = null!;
        public int TeacherId { get; set; }
        public string CourseName { get; set; } = null!;
    }
}
