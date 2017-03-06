using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkModels
{
    public class SubCategory
    {
        public int SUBCATEGORYID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public string STATUS { get; set; }
        public string IMAGEURL { get; set; }
        public Nullable<int> PRODUCTS { get; set; }
        public string SYNONYMS { get; set; }
        public Nullable<int> CATEGORYID { get; set; }
    }
}
