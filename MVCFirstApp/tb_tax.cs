//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCFirstApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_tax
    {
        public string country_id { get; set; }
        public string tax_name { get; set; }
        public bool is_gross { get; set; }
        public decimal rate { get; set; }
        public string curr_id { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
    }
}
