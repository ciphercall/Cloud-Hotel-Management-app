using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_BILLHP")]
    public class HML_BILLHP
    {

        //COMPID	     NUMBER(3),
        //BILLID         NUMBER(5),
        //BILLNM         VARCHAR2(100),
        //BILLRT		 NUMBER(10,2),
        //REMARKS        VARCHAR2(100),
        //..
        //PRIMARY KEY =  COMPID, BILLID

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [Key, Column(Order = 2)]
        public Int64 BILLID { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String BILLNM { get; set; }

        public Decimal? BILLRT { get; set; }

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