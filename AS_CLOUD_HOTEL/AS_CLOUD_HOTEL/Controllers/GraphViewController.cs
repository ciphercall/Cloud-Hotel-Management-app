using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.DataAccess;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;

namespace AS_CLOUD_HOTEL.Controllers
{
    public class GraphViewController : AppController
    {
        public HttpCookie userCookie;
        public Int64 loggedcompid;
        private CLoudHotelDbContext db = new CLoudHotelDbContext();
        public GraphViewController()
        {
            //if (System.Web.HttpContext.Current.Request.Cookies["user"] != null)
            //{
            //    userCookie = System.Web.HttpContext.Current.Request.Cookies["user"];
            //    loggedcompid = Convert.ToInt64(userCookie.Values["loggedCompID"]);
            //}
            //HttpCookie decodedCookie1 = CookieSecurityProvider.Decrypt(System.Web.HttpContext.Current.Request.Cookies["CI"]);
            //HttpCookie decodedCookie2 = CookieSecurityProvider.Decrypt(System.Web.HttpContext.Current.Request.Cookies["UI"]);
            //HttpCookie decodedCookie3 = CookieSecurityProvider.Decrypt(System.Web.HttpContext.Current.Request.Cookies["UT"]);
            //HttpCookie decodedCookie4 = CookieSecurityProvider.Decrypt(System.Web.HttpContext.Current.Request.Cookies["UN"]);
            //HttpCookie decodedCookie5 = CookieSecurityProvider.Decrypt(System.Web.HttpContext.Current.Request.Cookies["US"]);
            //HttpCookie decodedCookie6 = CookieSecurityProvider.Decrypt(System.Web.HttpContext.Current.Request.Cookies["CS"]);

            if (System.Web.HttpContext.Current.Session["loggedCompID"] != null)
            {
                loggedcompid = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());
            }
            else
            {
                Index();
            }

            ViewData["HighLight_Menu_DashBoard"] = "High Light DashBoard";

        }

        TimeZoneInfo timeZoneInfo;


        // ROOM STATUS 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPost(String value,Int64 roomNO, Int64 regID)
        {
            HML_BillDTO model = new HML_BillDTO();
            model.COMPID = loggedcompid;
            model.ROOMNO = roomNO;
            model.REGNID = regID;
           
            if (value == "R")
            {
                TempData["Rough_BillReportViewModel"] = model;
                return RedirectToAction("Get_Rough_Bill_Reports", "HotelReport");
            }
            else //if (value == "B")
            {
                var findBillDetails = (from m in db.HmlBillDetailsDbSet where m.COMPID == model.COMPID && m.ROOMNO == model.ROOMNO && m.REGNID == model.REGNID
                    select new {m.TRANSDT, m.TRANSNO, m.TRANSMY}).ToList();
                if (findBillDetails.Count != 0)
                {
                    foreach (var bill in findBillDetails)
                    {
                        model.TRANSDT = Convert.ToString(bill.TRANSDT);
                        model.TRANSNO = bill.TRANSNO;
                        model.TRANSMY = bill.TRANSMY;
                        break;
                    }

                    TempData["BIllReportViewModel"] = model;
                    return RedirectToAction("Get_BillReports_BigSize", "HotelReport");
                }
                else
                {
                    return RedirectToAction("Get_Rough_Bill_Reports_Empty", "HotelReport");
                }
            }
        }

        //BOOKING STATUS
        public ActionResult BookingStatus()
        {
            return View();
        }

        //CLEANING STATUS 
        public ActionResult CleaningStatus()
        {
            return View();
        }


        public ActionResult Today()
        {
            return View();
        }

        public ActionResult LastOneDay()
        {
            return View();
        }
        public ActionResult Last7Day()
        {
            return View();
        }
        public ActionResult LastOneMonth()
        {
            return View();
        }

        public ActionResult LastOneYear()
        {
            return View();
        }



        public JsonResult Topcategories(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }



            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TopcategoriesListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }





        public JsonResult TopItemsByQty(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }
            
            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TopItemsByQtyListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }








        public JsonResult TopItemsByValue(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }


            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TopItemsByValueListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }








        public JsonResult CollectionData(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }


            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.CollectionDataListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }









        public JsonResult TimeWiseSellData(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }

            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TimeWiseSellDataListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }








        //Hotel
        public JsonResult TopServiceByValue(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }


            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TopServiceByValueListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }








        //Hotel
        public JsonResult TopRoomsByQty(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }

            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TopRoomsByQtyListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }








        //Hotel
        public JsonResult TopRoomCategories(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }



            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.TopRoomCategoriesListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }






        //Hotel
        public JsonResult Reserve_Reggistration_CollectionData(string d)
        {
            Int64 n = Convert.ToInt64(d);
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime dt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            string frdate = dt.ToString("yyyy-MM-dd");
            string todate = "";

            if (n == 364)
            {
                int year = DateTime.Now.Year;
                DateTime firstDay = new DateTime(year, 1, 1);
                todate = firstDay.ToString("yyyy-MM-dd");
            }
            else
            {
                DateTime dt2 = TimeZoneInfo.ConvertTime(DateTime.Today.AddDays(-n), timeZoneInfo);
                todate = dt2.ToString("yyyy-MM-dd");
            }


            mydataservice objMD = new mydataservice();
            var chartsdata = objMD.Reserve_Reggistration_CollectionDataListdata(loggedcompid, todate, frdate); // calling method Listdata
            return Json(chartsdata, JsonRequestBehavior.AllowGet); // returning list from here.
        }
    }
}
