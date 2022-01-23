using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Driver
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Name")]
        public String Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        [RegularExpression(@"{8}", ErrorMessage = "Invalid Length of Password")]
        public String Password { get; set; }

        [RegularExpression(@"^{2,3}[a-zA-z]-{2,4}[0-9]$", ErrorMessage = "Invalid Number Of Plate")]
        public String NumberPlate { get; set; } // of the car he is driving if no car then 'null'
        [ForeignKey("NumberPlate")]
        public virtual Car Car { get; set; }

        [Key]
        [Required]
        [RegularExpression(@"[0][3][0-4][0-9]-{7}[0-9]", ErrorMessage = "Invalid Pakistani Phone No.")]
        public String PhoneNo { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "Invalid Pakistani CNIC format")]
        public String Cnic { get; set; }

        public int Rating { get; set; }

        //if previously null then his first rating will be overall rating
        // and this rating is done by function
        public double Paymentbalance { get; set; }

        public double FineAmount { get; set; }

        [Required]
        public int YearsOfExperience { get; set; }

    }
}