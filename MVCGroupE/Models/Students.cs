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
        [Display(Name = "Student #")]
        [RegularExpression(@"\d{5,10}", ErrorMessage = "Student # must between 5-10 numbers.")]
        public int SiD { get; set; }

        [Required]
        [StringLength(30)]
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

    }
}