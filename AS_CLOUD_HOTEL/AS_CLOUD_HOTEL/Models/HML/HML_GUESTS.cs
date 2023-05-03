using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_GUESTS")]
    public class HML_GUESTS
    {
        //COMPID     NUMBER(3),
        //REGNID	 NUMBER(8),
        //GUESTID	 NUMBER(10),
        //GUESTNM	 VARCHAR2(100),
        //DOB		 DATE,
        //GENDER	 VARCHAR2(6),
        //ADDRESS	VARCHAR2(100),
        //CITY		VARCHAR2(50),
        //ZIPCODE	NUMBER(8),
        //COUNTRY	VARCHAR2(60),
        //NATIONALITY	VARCHAR2(60),
        //EMAILID	VARCHAR2(100),
        //TELNO		VARCHAR2(30),
        //MOBNO		VARCHAR2(30),
        //NIDNO		VARCHAR2(20),
        //DRLICNO	VARCHAR2(20),
        //VISANO		VARCHAR2(20),
        //VISAIDT	DATE,
        //VISAEDT	DATE,
        //PPNO		VARCHAR2(20),
        //PPIPLACE	VARCHAR2(50),
        //PPIDT		DATE,
        //PPEDT		DATE,
        //REMARKS   VARCHAR2(100),
        //..
        //PRIMARY KEY = COMPID, REGNID, GUESTID


        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [Key, Column(Order = 2)]
        public Int64 REGNID { get; set; }

        [Key, Column(Order = 3)]
        public Int64 GUESTID { get; set; }




        [Required(ErrorMessage = "Guest Name can not be empty!")]
        [StringLength(100, MinimumLength = 0)]
        public String GUESTNM { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [StringLength(6, MinimumLength = 0)]
        public String GENDER { get; set; }

        [Required(ErrorMessage = "Address required!")]
        [StringLength(100, MinimumLength = 0)]
        public String ADDRESS { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public String CITY { get; set; }

        public Int64? ZIPCODE { get; set; }

        [StringLength(60, MinimumLength = 0)]
        public String COUNTRY { get; set; }

        [Required(ErrorMessage = "Nationality can not be empty!")]
        [StringLength(60, MinimumLength = 0)]
        public String NATIONALITY { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String EMAILID { get; set; }

        [StringLength(30, MinimumLength = 0)]
        public String TELNO { get; set; }

        [Required(ErrorMessage = "Mobile No required!")]
        [StringLength(30, MinimumLength = 0)]
        public String MOBNO { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public String NIDNO { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public String DRLICNO { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public String VISANO { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? VISAIDT { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? VISAEDT { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public String PPNO { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public String PPIPLACE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PPIDT { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PPEDT { get; set; }
        
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