using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL.Models
{
    public partial class GradeRecord
    {
        [Key]

        public int RecordId { get; set; }
        public int GradeNameId { get; set; }
        public int GradeValue { get; set; }
        public DateTime SetDate { get; set; }
        public int SetByTeacherId { get; set; }
        public int GradeForStudentId { get; set; }

        public virtual Student GradeForStudent { get; set; } = null!;
        public virtual Course GradeName { get; set; } = null!;
        public virtual Teacher SetByTeacher { get; set; } = null!;
    }
}
