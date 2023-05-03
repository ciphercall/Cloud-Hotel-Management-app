using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.DTO
{
    public class HML_BillDTO
    {
        public Int64 ID { get; set; }
        public Int64 COMPID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String TRANSDT { get; set; }

        [StringLength(6, MinimumLength = 6)]
        public String TRANSMY { get; set; }
        public Int64 TRANSNO { get; set; }
      
        public Int64 ROOMNO { get; set; }
        public Int64 REGNID { get; set; }


        //........................HML_BillDTL (child)
        public Int64? BILLID { get; set; }
        public Decimal? AMOUNT { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public String REMARKS_BillDetails { get; set; }


        //...........................HML_BILL (Bill Master)
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
        public String REMARKS_TotalBill { get; set; }




        public Decimal? SCHARGE_RT { get; set; }
        public Decimal? VATAMT_RT { get; set; }
        public String BILLNM { get; set; }




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




        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }


        public Int64 count { get; set; }

    }
}