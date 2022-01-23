using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Person
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name")]
        public String Name { get; set; }

        [Required]
        [RegularExpression(@"{8}", ErrorMessage = "Invalid Length of Password")]
        public String Password { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public String Email { get; set; }
        // ABOVE IS THE SHIT WRITTEN THAT DOESN'T WORKS

        [Required]
        [EmailAddress]
        public String Email { get; set; }


        [Required]
        [RegularExpression(@"[0][3][0-4][0-9]-{7}[0-9]", ErrorMessage = "Invalid Pakistani Phone No.")]
        public String PhoneNo { get; set; }

        [Key]
        [Required]
        [RegularExpression(@"^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "Invalid Pakistani CNIC format")]
        public String Cnic { get; set; }

        public double PaymentBalance { get; set; }

    }
}