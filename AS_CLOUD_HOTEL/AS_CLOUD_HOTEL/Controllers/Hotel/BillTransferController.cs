using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class BillTransferController : AppController
    {
        private CLoudHotelDbContext db = new CLoudHotelDbContext();

        //Datetime formet
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;

        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;

        public BillTransferController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ActionResult Index()
        {
            return View();
        }




        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_roomID(String changedText, String compid, String registrationDate)
        {
            Int64 companyID = Convert.ToInt64(compid);
            Int64 roomNo = Convert.ToInt64(changedText);
            DateTime dt = Convert.ToDateTime(registrationDate);

            Int64 regnid = 0;
            var getData = (from m in db.HmlRegistrationDbSet
                        where m.COMPID == companyID && m.CHECKI <= dt && dt <= m.GHECKO
                        select new
                        {
                            m.ROOMNO,
                            m.REGNID,
                        }
                      ).ToList();
            foreach (var get in getData)
            {
                var findRegID = (from n in db.HmlRegistrationDbSet where n.COMPID == companyID && n.ROOMNO == roomNo && n.REGNID == get.REGNID select new {n.REGNID}).ToList();
                if(findRegID.Count == 1) {
                    regnid = get.REGNID;
                }
               
            }

            String guestName = "";
            var getGuestName = (from m in db.HmlRegistrationGuestsDbSet
                                where m.COMPID == companyID && m.REGNID == regnid
                                select new { m.GUESTNM }).ToList();
            foreach (var get in getGuestName)
            {
                guestName = get.GUESTNM;
                break;
            }

            var result = new
            {
                REGNID = regnid,
                GUESTNM = guestName
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
