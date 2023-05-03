using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_ROOM")]
    public class HML_ROOM
    {
        //COMPID	      	NUMBER(3),
        //RTPID		NUMBER(5),	
        //ROOMNO         NUMBER(3),	
        //REMARKS        VARCHAR2(100),
        //..
        //PRIMARY KEY =  COMPID, RTPID, ROOMNO


        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [Key, Column(Order = 2)]
        public Int64 RTPID { get; set; }

        [Key, Column(Order = 3)]
        public Int64 ROOMNO { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string REMARKS { get; set; }





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
    }
}