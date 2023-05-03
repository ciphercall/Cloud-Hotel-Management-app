using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.DataAccess;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class BookingStatusController : Controller
    {

        //Datetime formet
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;

        CLoudHotelDbContext db = new CLoudHotelDbContext();
        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;
        Int64 loggedcompid;

        public BookingStatusController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
            loggedcompid = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());
        }




        public JsonResult GetDiaryEvents(double start, double end)
        {
            var ApptListForDate = DiaryEvent_BookingStatus.LoadAllAppointmentsInDateRange(start, end, loggedcompid);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.ID,
                                title = e.Title,
                                start = e.StartDateString,
                                end = e.EndDateString,
                                color = e.StatusColor,
                                className = e.ClassName,
                                someKey = e.SomeImportantKeyID,
                                allDay = false,

                                Checkin = e.CheckInDate,
                                CheckOut = e.CheckOutDate,
                                CPerson = e.ContactPerson,
                                mobileNo = e.MobileNo,
                                adultPerson = e.AdultPerson,
                                childPerson = e.ChildPerson,
                                roominformation = e.RoomInformation,
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }



        //public JsonResult GetDiarySummary(double start, double end)
        //{
        //    var ApptListForDate = DiaryEvent.LoadAppointmentSummaryInDateRange(start, end, loggedcompid);
        //    var eventList = from e in ApptListForDate
        //                    select new
        //                    {
        //                        id = e.ID,
        //                        title = e.Title,
        //                        start = e.StartDateString,
        //                        end = e.EndDateString,
        //                        someKey = e.SomeImportantKeyID,
        //                        allDay = false
        //                    };
        //    var rows = eventList.ToArray();
        //    return Json(rows, JsonRequestBehavior.AllowGet);
        //}
    }
}
