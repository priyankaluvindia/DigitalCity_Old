//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkData
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBCATEGORY
    {
        public int SUBCATEGORYID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public string STATUS { get; set; }
        public string IMAGEURL { get; set; }
        public Nullable<int> PRODUCTS { get; set; }
        public string SYNONYMS { get; set; }
        public Nullable<int> CATEGORYID { get; set; }
    
        public virtual CATEGORy CATEGORy { get; set; }
    }
}