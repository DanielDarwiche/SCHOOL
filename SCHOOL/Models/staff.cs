using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class staff
    {
        public staff()
        {
            Principals = new HashSet<Principal>();
            Teachers = new HashSet<Teacher>();
        }
        [Key]

        public int StaffId { get; set; }
        public string StaffRole { get; set; } = null!;
        public bool Hired { get; set; }

        public virtual ICollection<Principal> Principals { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
