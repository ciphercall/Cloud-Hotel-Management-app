using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_SERVICES")]
    public class HML_SERVICES
    {
        //COMPID	NUMBER(3),
        //TRANSDT 	DATE,
        //TRANSMY	VARCHAR2(6),	
        //TRANSNO	NUMBER(8),
        //GUESTTP	VARCHAR2(8),	--IN-HOUSE/WALK-IN
        //ROOMNO	NUMBER(3),
        //REGNID	NUMBER(8),
        //BILLID	NUMBER(5),
        //QTY		NUMBER(15),
        //RATE		NUMBER(15,2),
        //AMOUNT	NUMBER(15,2),
        //REMARKS	VARCHAR2(100),
        //..
        //PRIMARY KEY =  COMPID, TRANSMY, TRANSNO



        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TRANSDT { get; set; }

        [Key, Column(Order = 2)]
        [StringLength(6, MinimumLength = 6)]
        public String TRANSMY { get; set; }

        [Key, Column(Order = 3)]
        public Int64 TRANSNO { get; set; }
        
        [StringLength(8, MinimumLength = 0)]
        public String GUESTTP { get; set; }   //--IN-HOUSE/WALK-IN

        public Int64 ROOMNO { get; set; }
        public Int64 REGNID { get; set; }
        public Int64 BILLID { get; set; }
        public Int64? QTY { get; set; }
        public Decimal? RATE { get; set; }
        public Decimal? AMOUNT { get; set; }

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