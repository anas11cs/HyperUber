using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Insurance
    {
        [Key]
        [Required]
        [RegularExpression(@"^{2,3}[a-zA-z]-{2,4}[0-9]$", ErrorMessage = "Invalid Number Of Plate")]
        public String NumberPlate { get; set; }
        [ForeignKey("NumberPlate")]
        public virtual Car Car { get; set; }

        [Required]
        public bool Status { get; set; } // 1 means paid 0 means to be paid

        [Required]
        public double Amount { get; set; }

    }
}