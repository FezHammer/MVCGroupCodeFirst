using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGroupE.Models
{
    public class Course
    {
        [Key]
        [Required]
        [StringLength(4)]
        [Column(TypeName = "varchar")]
        public string CourseId { get; set; }

        [Display(Name = "Course Name")]
        [StringLength(32)]
        [Column(TypeName = "varchar")]
        public String CourseName { get; set; }

        [StringLength(1000)]
        [Column(TypeName = "varchar")]
        public string Description { get; set; }

        public int Semester { get; set; }

        [Display(Name = "Catergory")]
        [StringLength(32)]
        [Column(TypeName = "varchar")]
        public string CategoryName { get; set; }

        public int Year { get; set; }

        [Display(Name = "Prerequisite")]
        [StringLength(4)]
        [Column(TypeName = "varchar")]
        public string PrerequisiteId { get; set; }

        public bool Compulsory { get; set; }

        public virtual ICollection<Enrolment> Enrolment { get; set; }

        public virtual ICollection<LabHistory> LabHistory { get; set; }

        public virtual ICollection<FurtureClasses> furtureClasses { get; set; }


    }
}