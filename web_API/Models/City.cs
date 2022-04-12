using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_API.Models
{


    
        public class City
        {

            public int Id { get; set; }
            public string district { get; set; }
            public string name { get; set; }
            public int population { get; set; }
            public string subject { get; set; }
            public Coords coords { get; set; }
        }
    

}
