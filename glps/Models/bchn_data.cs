using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace glps.Models
{
    public class bchn_data
    {
        [Key ]
        public int Id { get; set; }

        public string Fore_Nane { get; set; }

        public string Family_Name { get; set; }

        public string Gender { get; set; }

        public string DOB { get; set; }

        public string Nationality { get; set; }

        public string Passport_number { get; set; }

        public string Terrorism { get; set; }

        public string Narcotics { get; set; }

        public string Smuggling { get; set; }

        public string Illegal_Immigration { get; set; }


        public string Revenue { get; set; }

    }
}