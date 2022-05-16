using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace glps.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        //public int RegistrationID AS('AS' + RIGHT(('000000000' + CAST(idfield AS varchar(9))), 9) + 'FAK'){ get; set; }

       

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is required")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [Remote("IsAlreadySigned", "User", HttpMethod = "POST", ErrorMessage = "EmailId already exists in database.")]

        public string EmailID { get; set; }

      
        

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwoords do not match")]

        public string Password { get; set; }
    }
}