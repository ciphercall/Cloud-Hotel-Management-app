﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AS_CLOUD_HOTEL.Models.DTO
{
    public class HML_BillHpDTO
    {
        public Int64 ID { get; set; }
        public Int64 COMPID { get; set; }
        public Int64 BILLID { get; set; }

        [Required(ErrorMessage = "Bill Name required!")]
        [StringLength(100, MinimumLength = 0)]
        public string BILLNM { get; set; }

        public Decimal? BILLRT { get; set; }

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


        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }

        public bool ValidationError { set; get; }
        public Int64 count { get; set; }
        public Int64 GetChildDataForDeleteMasterCategory { get; set; } // its used for Delete Test Master(category) data before check this category child data is hold or not.

    }
}