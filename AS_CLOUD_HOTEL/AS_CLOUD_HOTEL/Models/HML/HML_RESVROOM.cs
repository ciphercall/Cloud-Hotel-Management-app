using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_RESVROOM")]
    public class HML_RESVROOM
    {
        //COMPID	      	NUMBER(3),
        //RESVID		NUMBER(8),
        //RTPID		NUMBER(5),
        //ROOMRTO        NUMBER(10,2), 
        //DISCTP		VARCHAR2(10),
        //DISCRT		NUMBER(8,2), 
        //ROOMRTS	NUMBER(10,2), 
        //ROOMQTY	NUMBER(10), 
        //REMARKS        VARCHAR2(100),
        //..
        //PRIMARY KEY = COMPID, RESVID, RTPID



        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [Key, Column(Order = 2)]
        public Int64 RESVID { get; set; }

        [Key, Column(Order = 3)]
        public Int64 RTPID { get; set; }

        public Decimal ROOMRTO { get; set; }

        [StringLength(10, MinimumLength = 0)]
        public String DISCTP { get; set; }

        public Decimal DISCRT { get; set; }
        public Decimal ROOMRTS { get; set; }
        public Int64 ROOMQTY { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String REMARKS { get; set; }









        public String USERPC { get; set; }
        public Int64 INSUSERID { get; set; }

        //[Display(Name = "Insert Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? INSTIME { get; set; }
        public String INSIPNO { get; set; }
        public String INSLTUDE { get; set; }
        public Int64 UPDUSERID { get; set; }
        //[Display(Name = "Update Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UPDTIME { get; set; }
        public String UPDIPNO { get; set; }
        public String UPDLTUDE { get; set; }
    }
}