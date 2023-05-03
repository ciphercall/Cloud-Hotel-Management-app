using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.HML
{
    [Table("HML_REGN")]
    public class HML_REGN
    {
        //COMPID	    NUMBER(3),
        //REGNDT		DATE,
        //REGNYY        NUMBER(4),
        //REGNID		NUMBER(8),
        //CHECKI		DATE,
        //GHECKO		DATE,
        //RESVYN		VARCHAR2(3),
        //RESVID        NUMBER(8),
        //GCOID       	NUMBER(10),
        //CCYTP		    VARCHAR2(4),	--BDT/USD
        //CCYCRT        NUMBER(8,3),	
        //RTPID		    NUMBER(5),
        //ROOMNO        NUMBER(3),
        //ROOMRTO       NUMBER(10,2), 
        //DISCTP		VARCHAR2(10),
        //DISCRT		NUMBER(8,2), 
        //ROOMRTS	    NUMBER(10,2),  
        //VISITPP       VARCHAR2(100),	
        //VISITPRE      VARCHAR2(3), 	--YES/NO
        //DESTFR		VARCHAR2(100),
        //DESTTO		VARCHAR2(100),
        //GRFID     	NUMBER(10),
        //ROOMNOL	    NUMBER(3),
        //REGNIDL	    NUMBER(8),
        //REMARKS	    VARCHAR2(100),
        //..
        //PRIMARY KEY =  COMPID, REGNYY, REGNID



        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        [Key, Column(Order = 1)]
        public Int64 COMPID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? REGNDT { get; set; }

        [Key, Column(Order = 2)]
        public Int64 REGNYY { get; set; }

        [Key, Column(Order = 3)]
        public Int64 REGNID { get; set; }






        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CHECKI { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GHECKO { get; set; }

        [StringLength(3, MinimumLength = 0)]
        public String RESVYN { get; set; }

        public Int64? RESVID { get; set; }
        public Int64? GCOID { get; set; }

        [StringLength(4, MinimumLength = 0)]
        public String CCYTP { get; set; }               //--BDT/USD

        public Decimal CCYCRT { get; set; }
        public Int64 RTPID { set; get; }
        public Int64 ROOMNO { set; get; }
        public Decimal ROOMRTO { set; get; }
        
        [StringLength(10, MinimumLength = 0)]
        public String DISCTP { get; set; }              

        public Decimal? DISCRT { get; set; }
        public Decimal ROOMRTS { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String VISITPP { get; set; }           

        [StringLength(3, MinimumLength = 0)]
        public String VISITPRE { get; set; }            //--YES/NO

        [StringLength(100, MinimumLength = 0)]
        public String DESTFR { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public String DESTTO { get; set; }

        public Int64? GRFID { get; set; }
        public Int64? ROOMNOL { get; set; }
        public Int64? REGNIDL { get; set; }
        
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