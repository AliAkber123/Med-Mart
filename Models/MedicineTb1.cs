//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amar_Pharmacy1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicineTb1
    {
        public string MedCode { get; set; }
        public string MedName { get; set; }
        public int MedPrice { get; set; }
        public int MedStock { get; set; }
        public System.DateTime MedExpDate { get; set; }
        public int MedCategory { get; set; }
    
        public virtual CategoryTB1 CategoryTB1 { get; set; }
    }
}
