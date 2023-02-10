using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }
        [Key]

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
