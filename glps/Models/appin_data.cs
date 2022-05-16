using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace glps.Models
{
    
    public class appin_data
    {
        [Key]

        public int Id { get; set; }

        public string Flight { get; set; }

        public string Seat_Number { get; set; }

        public string Fore_Name { get; set; }

        public string Family_Name { get; set; }

        public string Passport_Number { get; set; }

        public string Country_of_Issue { get; set; }

    }
}