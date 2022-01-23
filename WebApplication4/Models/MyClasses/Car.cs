using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Car
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name")]
        public String Name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$")]
        [Range(1970,2019, ErrorMessage = "The Model of Car should be between 1970 and 2019 years")]
        public int Model { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage="Invalid Input")]
        public String Make { get; set; }

        [Key]
        [Required]
        [RegularExpression(@"^{2,3}[a-zA-z]-{2,4}[0-9]$", ErrorMessage = "Invalid Number Of Plate")]
        public String NumberPlate { get; set; }

        [Required]
        public double PetrolInLitres { get; set; }

        [Required]
        public double DrivenInKms { get; set; }

        [Required]
        public int Rating { get; set; } // Options will be given 1,2,3,4,5

        [Required]
        [RegularExpression(@"^[0-9]{5}-[0-9]{7}-[0-9]$",ErrorMessage ="Invalid Pakistani CNIC format")]
        public String Cnic { get; set; }
        [ForeignKey("Cnic")]
        public virtual Person Person { get; set; }

        [Required]
        public int EngineCC { get; set; }
    }
}