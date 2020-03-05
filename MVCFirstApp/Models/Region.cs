using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFirstApp.Models
{
    
    public class Region
    {
        public string cityId { get; set; }
        public string name { get; set; }
  
        public Region(string _id, string _name)
        {
            cityId = _id;
            name = _name;
        }

    }
}