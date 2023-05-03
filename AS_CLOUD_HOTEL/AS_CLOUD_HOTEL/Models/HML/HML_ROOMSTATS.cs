using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_ROOMSTATS")]
    public class HML_ROOMSTATS
    {
        //COMPID	      	NUMBER(3),
        //ROOMNO         NUMBER(3),	
        //RSTATS	 VARCHAR2(10),	--AVAILABLE/OCCUPIED
        //CSTATS	 VARCHAR2(10),	--CLEANED/CLEANIP (C-IN-PROGRESS)
        //CLASTDT	DATETIME,	--DATE SELECTION WITH DEFAULT 	10:00AM
        //CNEXTDT	DATETIME,	--DATE SELECTION WITH TIME LIKE 02:57PM	
        //REMARKS	VARCHAR2(100),
        //..
        //PRIMARY KEY =  COMPID, ROOMNO

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [Key, Column(Order = 3)]
        public Int64 ROOMNO { get; set; }

        [StringLength(10, MinimumLength = 0)]
        public String RSTATS { get; set; }

        [StringLength(10, MinimumLength = 0)]
        public String CSTATS { get; set; }

        public String CLASTDT { get; set; }
        public String CNEXTDT { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string REMARKS { get; set; }




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