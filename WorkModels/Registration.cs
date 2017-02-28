using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkModels
{
    public class Registration
    {
        public int USERID { get; set; }
        public String USERNAME { get; set; }
        public String PASSWORD { get; set; }
        public String EMAILID { get; set; }
        public int CONTACTNUMBER { get; set; }
        public int OTP { get; set; }
        public String STATUS { get; set; }
        public DateTime JOINEDON { get; set; }
        public String AREA { get; set; }
        public String CITY { get; set; }
    }
}
