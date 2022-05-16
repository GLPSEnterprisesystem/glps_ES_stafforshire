using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace glps.Models
{

 
    public class airport_data
    {

        [Key]
        public int Id { get; set; }

        public string IATA_code { get; set; }

        public string ISO_Alpha_Code { get; set; }

        public string Long_Name { get; set; }

        public string Location { get; set; }

    }
}