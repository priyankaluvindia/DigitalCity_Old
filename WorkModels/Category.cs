using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkModels
{
    public class Category
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> CREATEDON { get; set; }
        public string STATUS { get; set; }
        public string IMAGEURL { get; set; }
        public Nullable<int> PRODUCTS { get; set; }
        public Nullable<int> SUBCATEGORIES { get; set; }
        public string SYNONYMS{ get; set; }
    }
}
