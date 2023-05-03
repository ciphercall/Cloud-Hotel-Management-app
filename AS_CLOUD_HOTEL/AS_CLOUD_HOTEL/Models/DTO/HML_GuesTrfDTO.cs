using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AS_CLOUD_HOTEL.Models.DTO
{
    public class HML_GuesTrfDTO
    {
        public Int64 ID { get; set; }
        public Int64 COMPID { get; set; }
        public Int64? GRFGID { get; set; } //--LIABILITY HEAD-- NUMBER(10)
        public Int64? GRFID { get; set; } //--INSERT AS ACCOUNT HEAD-- NUMBER(10)

        [Required(ErrorMessage = "Refer Name required!")]
        [Remote("Check_ReferName", "GuesTrf", ErrorMessage = "Refer name already exists!")]
        [StringLength(100, MinimumLength = 0)]
        public string REFERNM { get; set; }

        [Required(ErrorMessage = "Address required!")]
        [StringLength(100, MinimumLength = 0)]
        public string ADDRESS { get; set; }

        [Required(ErrorMessage = "Mobile Number required!")]
        [RegularExpression(@"^([0-9]{11})", ErrorMessage = "Insert a valid phone number like 01900000000")]
        [StringLength(11, MinimumLength = 0)]
        public string MOBNO1 { get; set; }

        [RegularExpression(@"^([0-9]{11})", ErrorMessage = "Insert a valid phone number like 01900000000")]
        [StringLength(11, MinimumLength = 0)]
        public string MOBNO2 { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
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