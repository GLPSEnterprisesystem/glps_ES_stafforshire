using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace glps.Models
{
    public class asset_details
    {
        [Key]
        public int Id { get; set; }

        public string Flight { get; set; }

        public string Departure { get; set; }

        public string Arrival { get; set; }

        public string Terminal { get; set; }

        public string Aircraft { get; set; }

        public string Capacity { get; set; }

        public string Crew { get; set; }

        
         
        
              
           
              
            


    }
}