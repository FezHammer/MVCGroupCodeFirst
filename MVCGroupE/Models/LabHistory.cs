using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGroupE.Models
{
    public class LabHistory
    {
        [Required]
        [Key]
        public int LabId { get; set; }

        [Required]
        [StringLength(4)]
        [Column(TypeName = "varchar")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Student #")]
        public string SiD { get; set; }
        public virtual Students Students { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Date of Lab")]
        public string LabDate { get; set; }

        public bool Attended { get; set; }

    }
}