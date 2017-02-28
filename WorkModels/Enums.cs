using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorkModels
{
    public static class Enums
    {
        [DataContract]
        public enum RepoResponse
        {
            /// <summary>
            /// Bad Request
            /// </summary>
            [EnumMember]
            [Display(Name = "Bad Request")]
            BREQ = 1,
            /// <summary>
            /// Success Request
            /// </summary>
            [EnumMember]
            [Display(Name = "Success")]
            BSUCC = 2,
            /// <summary>
            /// Error
            /// </summary>
            [EnumMember]
            [Display(Name = "Error")]
            RERR = 3,
        }
    }
}
