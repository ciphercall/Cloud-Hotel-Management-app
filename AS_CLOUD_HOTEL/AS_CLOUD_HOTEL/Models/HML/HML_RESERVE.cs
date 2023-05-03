using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_RESERVE")]
    public class HML_RESERVE
    {
        //COMPID	      	NUMBER(3),
        //RESVDT		DATE,
        //RESVYY         NUMBER(4),
        //RESVID		NUMBER(8),
        //CHECKI		DATE,
        //GHECKO		DATE,
        //ARRIVETM	TIME,
        //RESVTP         VARCHAR2(10),	--ONLINE/EMAIL/DIRECT/TELEPHONE/FAX	
        //RESVMODE       VARCHAR2(8),	--PERSONAL/COMPANY
        //CPNM		VARCHAR2(100),
        //CPTELNO	VARCHAR2(30),
        //CPEMAIL	VARCHAR2(100),
        //CPMOBNO	VARCHAR2(11),
        //GUESTNM	VARCHAR2(100),
        //ADULTQP	NUMBER(3),
        //CHILDQP	NUMBER(3),
        //CCYTP		VARCHAR2(4),	--BDT/USD
        //GRFID     	NUMBER(10),
        //RESVSTATS      VARCHAR2(7),
        //REMARKS        VARCHAR2(100),
        //..
        //PRIMARY KEY = COMPID, RESVYY, RESVID



        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RESVDT { get; set; }

        [Key, Column(Order = 2)]
        public Int64 RESVYY { get; set; }

        [Key, Column(Order = 3)]
        public Int64 RESVID { get; set; }






        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CHECKI { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GHECKO { get; set; }

        public String ARRIVETM { get; set; }

        [StringLength(10, MinimumLength = 0)]
        public String RESVTP { get; set; }              //--ONLINE/EMAIL/DIRECT/TELEPHONE/FAX	

        [StringLength(8, MinimumLength = 0)]
        public String RESVMODE { get; set; }            //--PERSONAL/COMPANY

        [StringLength(100, MinimumLength = 0)]
        public String CPNM { get; set; }

        [StringLength(30, MinimumLength = 0)]
        public String CPTELNO { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String CPEMAIL { get; set; }

        [StringLength(11, MinimumLength = 0)]
        [RegularExpression(@"^([0-9]{11})", ErrorMessage = "Insert a valid phone number like 01900000000")]
        public String CPMOBNO { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String GUESTNM { get; set; }

        public Int64 ADULTQP { get; set; }
        public Int64 CHILDQP { get; set; }

        [StringLength(4, MinimumLength = 0)]
        public String CCYTP { get; set; }

        public Int64? GRFID { get; set; }

        [StringLength(7, MinimumLength = 0)]
        public String RESVSTATS { get; set; }

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