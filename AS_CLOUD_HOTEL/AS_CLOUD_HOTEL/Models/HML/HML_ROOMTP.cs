using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_ROOMTP")]
    public class HML_ROOMTP
    {
        //COMPID	      	NUMBER(3),
        //RTPID		NUMBER(5),	
        //RTPNM		VARCHAR2(100),   
        //RATEBDT	NUMBER(10,2),	
        //RATEUSD	NUMBER(10,2),	
        //STATUS         CHAR(1),
        //..
        //PRIMARY KEY =  COMPID, RTPID


        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [Key, Column(Order = 2)]
        public Int64 RTPID { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string RTPNM { get; set; }

        public Decimal? RATEBDT { get; set; }
        public Decimal? RATEUSD { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string STATUS { get; set; }





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