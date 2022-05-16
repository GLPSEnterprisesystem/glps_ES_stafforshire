using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace glps.Models
{
    

    public class airline_details
    {
        [Key]
        public int Id { get; set; }

        public string Company_name { get; set; }

        public string letter_code { get; set; }

        public string Country { get; set; }

    }
}