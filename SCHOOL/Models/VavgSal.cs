using System;
using System.Collections.Generic;

namespace SCHOOL.Models
{
    public partial class VavgSal
    {
        public decimal? TotalSalaryForAllTeachers { get; set; }
        public decimal? TotalSalaryForAllPrincipals { get; set; }
        public decimal? TotalSalaryForAllAdministrators { get; set; }
    }
}
