using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.DTO
{
    public class HML_FloorPlanDTO
    {
        public Int64 ID { get; set; }
        public Int64 COMPID { get; set; }
        public Int64 FLOORID { get; set; }
        public Int64 RTPID { get; set; }
        public Int64 ROOMNO { get; set; }
        public string REMARKS { get; set; }
        
        public string RTPNM { get; set; }







        public string USERPC { get; set; }
        public Int64 INSUSERID { get; set; }

        //[Display(Name = "Insert Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? INSTIME { get; set; }
        public string INSIPNO { get; set; }
        public string INSLTUDE { get; set; }
        public Int64 UPDUSERID { get; set; }

        //[Display(Name = "Update Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UPDTIME { get; set; }
        public string UPDIPNO { get; set; }
        public string UPDLTUDE { get; set; }

        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }


        public Int64 count { get; set; }
        public bool ValidationError { get; set; }
    }
}