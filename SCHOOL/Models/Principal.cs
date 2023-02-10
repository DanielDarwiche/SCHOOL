using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class Principal
    {
        [Key]

        public int PrincipalId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Salary { get; set; }
        public DateTime HiredSinceDate { get; set; }
        public int StaffId { get; set; }
        public bool Hired { get; set; }

        public virtual staff Staff { get; set; } = null!;
    }
}
