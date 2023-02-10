using System;
using System.Collections.Generic;

namespace SCHOOL.Models
{
    public partial class ViewStaffOverView
    {
        public string? Principals { get; set; }
        public DateTime? PHiredDate { get; set; }
        public string? Admins { get; set; }
        public DateTime? AHiredDate { get; set; }
        public string Teachers { get; set; } = null!;
        public DateTime THiredDate { get; set; }
    }
}
