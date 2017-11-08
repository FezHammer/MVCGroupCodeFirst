using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGroupE.Models
{
    public class FurtureClasses
    {
        [Required]
        [Key]
        public int FurtureCourseID { get; set; }

        [Display(Name = "Course Name")]
        [Required]
        [StringLength(4)]
        [Column(TypeName = "varchar")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Display(Name = "Student #")]
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string SiD { get; set; }
        public virtual Students Students { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        


    }
}