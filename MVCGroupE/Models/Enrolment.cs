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

        [Required]
        public int SiD { get; set; }
        public virtual Students Students { get; set; }

        //[Required]
        //[StringLength(4)]
        //[Column(TypeName = "varchar")]
        //public string CourseId { get; set; }

        public int EnromentYear { get; set; }

        public int EnromentSemester { get; set; }



    }
}