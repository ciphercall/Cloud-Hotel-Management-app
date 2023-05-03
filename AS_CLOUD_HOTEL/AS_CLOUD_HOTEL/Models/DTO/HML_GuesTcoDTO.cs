using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AS_CLOUD_HOTEL.Models.DTO
{
    public class HML_GuesTcoDTO
    {
        public Int64 ID { get; set; }
        public Int64 COMPID { get; set; }
        public Int64? GCOGID { get; set; } //--LIABILITY HEAD-- NUMBER(10)
        public Int64? GCOID { get; set; } //--INSERT AS ACCOUNT HEAD-- NUMBER(10)

        [Required(ErrorMessage = "Company Name required!")]
        [Remote("Check_CompanyName", "GuesTco", ErrorMessage = "Refer name already exists!")]
        [StringLength(100, MinimumLength = 0)]
        public string GCONM { get; set; }
        
        [Required(ErrorMessage = "Address required!")]
        [StringLength(100, MinimumLength = 0)]
        public string ADDRESS { get; set; }
        
        [StringLength(50, MinimumLength = 0)]
        public string ORGCNO { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
        [StringLength(50, MinimumLength = 0)]
        public string EMAILID { get; set; }

        [StringLength(100, MinimumLength = 0)]
        public string CPNM { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public string CPPOST { get; set; }

        [Required(ErrorMessage = "Mobile Number required!")]
        [RegularExpression(@"^([0-9]{11})", ErrorMessage = "Insert a valid phone number like 01900000000")]
        [StringLength(11, MinimumLength = 0)]
        public string MOBNO1 { get; set; }

        [RegularExpression(@"^([0-9]{11})", ErrorMessage = "Insert a valid phone number like 01900000000")]
        [StringLength(11, MinimumLength = 0)]
        public string MOBNO2 { get; set; }

        public decimal? DISCRT { get; set; }

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