using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.ASL
{
    public class ASL_CALENDAR
    {
        [Key]
        //id, text, start_date and end_date properties are mandatory
        public Int64 id { get; set; }
        public Int64? USERID { get; set; }
        public string text { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
    }
}