using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGroupE.Models
{   
    public class Enrolment
    {
        [Key]
        [Required]
        public int EnrollId { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Student #")]
        public string SiD { get; set; }
        public virtual Students Students { get; set; }

        [Required]
        [StringLength(4)]
        [Column(TypeName = "varchar")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        public int EnrolmentYear { get; set; }

        public int EnrolmentSemester { get; set; }

        public int Grade { get; set; }



    }
}