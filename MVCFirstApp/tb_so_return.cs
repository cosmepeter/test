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
    
    public partial class tb_so_return
    {
        public decimal so_id { get; set; }
        public byte return_line { get; set; }
        public byte return_type { get; set; }
        public string reason { get; set; }
        public byte return_status { get; set; }
        public System.DateTime return_date { get; set; }
        public Nullable<System.DateTime> nav_posting_date { get; set; }
        public string nav_wr_num { get; set; }
    }
}
