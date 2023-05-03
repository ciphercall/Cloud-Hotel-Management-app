using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_GUESTRF")]
    public class HML_GUESTRF
    {
        //COMPID      	NUMBER(3),
        //GRFGID    	NUMBER(10),	--LIABILITY HEAD
        //GRFID     	NUMBER(10),	--INSERT AS ACCOUNT HEAD
        //REFERNM     	VARCHAR2(100), 
        //ADDRESS     	VARCHAR2(100), 
        //MOBNO1      	VARCHAR2(11),     
        //MOBNO2      	VARCHAR2(11),     
        //EMAILID     	VARCHAR2(50),  
        //ORGNM       	VARCHAR2(100), 
        //POSTNM      	VARCHAR2(100), 
        //ORGCNO      	VARCHAR2(50),  
        //RFPCNT      	NUMBER(8,2),
        //REMARKS     	VARCHAR2(100), 
        //..
        //PRIMARY KEY =  COMPID, GRFID

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        public Int64 GRFGID { get; set; } 

        [Key, Column(Order = 2)]
        public Int64 GRFID { get; set; } 

        [StringLength(100, MinimumLength = 0)]
        public string REFERNM { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string ADDRESS { get; set; }

        [StringLength(11, MinimumLength = 0)]
        public string MOBNO1 { get; set; }

        [StringLength(11, MinimumLength = 0)]
        public string MOBNO2 { get; set; }
        
        [StringLength(50, MinimumLength = 0)]
        public string EMAILID { get; set; }
        
        [StringLength(100, MinimumLength = 0)]
        public string ORGNM { get; set; }
        
        [StringLength(100, MinimumLength = 0)]
        public string POSTNM { get; set; }
        
        [StringLength(50, MinimumLength = 0)]
        public string ORGCNO { get; set; }

        public decimal? RFPCNT { get; set; }
        
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