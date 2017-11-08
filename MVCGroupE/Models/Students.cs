using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGroupE.Models
{
    public class Students
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Student #")]
        public string SiD { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Student Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        public int Age { get; set; }

        public int Phone { get; set; }

        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ICollection<Enrolment> Enrolment { get; set; }

        public virtual ICollection<LabHistory> LabHistory  { get; set; }

        public virtual ICollection<FurtureClasses> furtureClasses { get; set; }


    }
}