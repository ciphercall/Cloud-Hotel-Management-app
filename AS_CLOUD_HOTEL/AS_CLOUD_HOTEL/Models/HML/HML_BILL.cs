using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_BILL")]
    public class HML_BILL
    {

        //COMPID	      	NUMBER(3),
        //TRANSDT 	DATE,
        //TRANSMY	VARCHAR2(6),	
        //TRANSNO	NUMBER(8),
        //ROOMNO		NUMBER(3),
        //REGNID		NUMBER(8),
        //TOTAMT      	NUMBER(15,2) DEFAULT 0,
        //SCHARGE     	NUMBER(15,2) DEFAULT 0, 
        //VATAMT        	NUMBER(15,2) DEFAULT 0,
        //GROSSAMT    	NUMBER(15,2) DEFAULT 0,
        //ADVAMT      	NUMBER(15,2) DEFAULT 0,
        //DISCOUNT    	NUMBER(15,2) DEFAULT 0,
        //NETAMT      	NUMBER(15,2) DEFAULT 0,
        //PAIDAMT     	NUMBER(15,2) DEFAULT 0,
        //BALAMT      	NUMBER(15,2) DEFAULT 0,  
        //DUEHID         NUMBER(10)
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

        public Int64 ROOMNO { get; set; }
        public Int64 REGNID { get; set; }
        public Decimal? TOTAMT { get; set; }
        public Decimal? SCHARGE { get; set; }
        public Decimal? VATAMT { get; set; }
        public Decimal? GROSSAMT { get; set; }
        public Decimal? ADVAMT { get; set; }
        public Decimal? DISCOUNT { get; set; }
        public Decimal? NETAMT { get; set; }
        public Decimal? PAIDAMT { get; set; }
        public Decimal? BALAMT { get; set; }
        public Int64? DUEHID { get; set; }

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