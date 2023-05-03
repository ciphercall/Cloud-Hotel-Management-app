﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AS_CLOUD_HOTEL.Models.DTO
{
    public class HML_ReserveRoomDTO
    {
        public Int64 ID { get; set; }
        public Int64 COMPID { get; set; }
        public Int64 RESVID { get; set; }
        public Int64 RTPID { get; set; }
        public Decimal ROOMRTO { get; set; }
        public String DISCTP { get; set; }
        public Decimal DISCRT { get; set; }
        public Decimal ROOMRTS { get; set; }
        public Int64 ROOMQTY { get; set; }
        public String REMARKS { get; set; }


        public String RTPNM { get; set; }
        public String RESVDT { get; set; }



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
        public bool ValidationError { get; set; }
    }
}