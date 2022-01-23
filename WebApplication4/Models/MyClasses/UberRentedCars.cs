using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class UberRentedCars
    {
        [Key]
        [Required]
        [RegularExpression(@"^{2,3}[a-zA-z]-{2,4}[0-9]$", ErrorMessage = "Invalid Number Of Plate")]
        public String NumberPlate { get; set; }
        [ForeignKey("NumberPlate")]
        public virtual Car Car { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "Invalid Pakistani CNIC format")]
        public String Cnic { get; set; }
        [ForeignKey("Cnic")]
        public virtual Person Person { get; set; }

        [Required]
        public int EstimateHours { get; set; }

        [Required]
        public Double EstimateKilometers { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
    }
}