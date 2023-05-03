using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class HotelReportController : AppController
    {
        private CLoudHotelDbContext db = new CLoudHotelDbContext();

        //Hotel Report (Guest Refer Information -- HML_GUESTRF)
        public ActionResult Get_GuestReferInformation()
        {
            return View();
        }


        //Hotel Report (Guest Company Information -- HML_GUESTCO)
        public ActionResult Get_GuestCompanyInformation()
        {
            return View();
        }


        ////Hotel Report (Room Type Information -- HML_ROOMTP)
        //public ActionResult Get_RoomTypeInformation()
        //{
        //    return View();
        //}


        //Hotel Report (Type Wise Room Information -- HML_ROOMTP && HML_ROOM)
        public ActionResult Get_TypeWiseRoomInformation()
        {
            return View();
        }


        ////Hotel Report (Floor Particulars -- HML_FLOOR )
        //public ActionResult Get_FloorParticulars()
        //{
        //    return View();
        //}


        //Hotel Report (Floor Wise Plan Information -- HML_FLOOR && HML_FLOORPLAN)
        public ActionResult Get_FloorWisePlan()
        {
            return View();
        }



        //Hotel Report (Bill Head Information -- HML_BILLHP)
        public ActionResult Get_BillHeadInformation()
        {
            return View();
        }


        //Hotel Report (Complementary Item Information -- HML_CITEM)
        public ActionResult Get_ComplementaryItemInformation()
        {
            return View();
        }




        //Bill Page (From BillController)
        public ActionResult BillReportPage(HML_BillDTO model)
        {
            model = (HML_BillDTO)TempData["BIllReportViewModel"];
            TempData["BIllReportViewModel"] = null;

            var command = TempData["BillCommand"].ToString();
            TempData["BIllReportViewModel"] = model;
            if (command == "A4")
            {
                return RedirectToAction("Get_BillReports_BigSize");


            }
            else //if (command == "POS")
            {
                return RedirectToAction("Get_BillReports_SmallSize");

            }
        }


        public ActionResult Get_BillReports_BigSize()
        {
            var model = (HML_BillDTO)TempData["BIllReportViewModel"];

            string Date = model.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");
            ViewBag.TransDate = getDate;


            return View(model);
        }

        public ActionResult Get_BillReports_SmallSize()
        {
            var model = (HML_BillDTO)TempData["BIllReportViewModel"];

            string Date = model.TRANSDT.ToString();
            DateTime dateParse = DateTime.Parse(Date);
            string getDate = dateParse.ToString("dd-MMM-yyyy");
            ViewBag.TransDate = getDate;

            return View(model);
        }


        


        //Registration Payment-Memo Page (From RegistrationPaymentController)
        public ActionResult RegistrationPaymnet_ReportPage(HML_REGNPAY model)
        {
            model = (HML_REGNPAY)TempData["RegistrationPaymentViewModel"];
            TempData["RegistrationPaymentViewModel"] = null;

            TempData["RegistrationPaymentViewModel"] = model;
            return RedirectToAction("Get_RegistrationPaymnetReports_BigSize");

        }
        public ActionResult Get_RegistrationPaymnetReports_BigSize()
        {
            var model = (HML_REGNPAY)TempData["RegistrationPaymentViewModel"];
            return View(model);
        }





        //Reserve Payment-Memo Page (From ReservePaymentController)
        public ActionResult ReservePayment_ReportPage(HML_RESVPAY model)
        {
            model = (HML_RESVPAY)TempData["ReservePaymentViewModel"];
            TempData["ReservePaymentViewModel"] = null;

            TempData["ReservePaymentViewModel"] = model;
            return RedirectToAction("Get_ReservePaymentReports_BigSize");

        }
        public ActionResult Get_ReservePaymentReports_BigSize()
        {
            var model = (HML_RESVPAY)TempData["ReservePaymentViewModel"];
            return View(model);
        }





        //Hotel Report (RESERVATION STATEMENT)
        public ActionResult ReservationStatement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReservationStatement(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetReservationStatement");
        }

        public ActionResult GetReservationStatement()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }




        //Hotel Report (MONEY RECEIVE - RESERVATION)
        public ActionResult MoneyReceive_Reservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoneyReceive_Reservation(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetMoneyReceive_Reservation");
        }

        public ActionResult GetMoneyReceive_Reservation()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }





        //Hotel Report (SERVICE STATEMENT)
        public ActionResult ServiceStatement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServiceStatement(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetServiceStatement");
        }

        public ActionResult GetServiceStatement()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }





        //Hotel Report (MONEY RECEIVE - REGISTRATION)
        public ActionResult MoneyReceive_Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoneyReceive_Registration(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetMoneyReceive_Registration");
        }

        public ActionResult GetMoneyReceive_Registration()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }





        //Hotel Report ( GUEST DETAILS)
        public ActionResult Guest_Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guest_Details(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetGuest_Details");
        }

        public ActionResult GetGuest_Details()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }





        //Hotel Report ( BILL STATUS)
        public ActionResult Bill_Status()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bill_Status(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetBill_Status");
        }

        public ActionResult GetBill_Status()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }



        //Hotel Report (RESERVATION - TODAY)
        public ActionResult Reservation_Today()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reservation_Today(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetReservation_Today");
        }

        public ActionResult GetReservation_Today()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }





        //Hotel Report (IN HOUSE GUEST STATUS)
        public ActionResult InhouseGuestStatus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InhouseGuestStatus(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetInhouseGuestStatus");
        }

        public ActionResult GetInhouseGuestStatus()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }





        //Hotel Report (FOREIGN NATIONALS STAYING)
        public ActionResult ForeignNationalsStaying()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForeignNationalsStaying(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetForeignNationalsStaying");
        }

        public ActionResult GetForeignNationalsStaying()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }




        //Hotel Report (DUE UNDERTAKING)
        public ActionResult Due_Undertaking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Due_Undertaking(PageModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("GetDue_Undertaking");
        }

        public ActionResult GetDue_Undertaking()
        {
            var model = (PageModel)TempData["model"];
            return View(model);
        }




        //GraphViewPage Page (From GraphViewController)
        public ActionResult Get_Rough_Bill_Reports(HML_BillDTO model)
        {
            model = (HML_BillDTO)TempData["Rough_BillReportViewModel"];
            TempData["Rough_BillReportViewModel"] = null;
            
            return View(model);
        }

        //GraphViewPage Page (From GraphViewController)
        public ActionResult Get_Rough_Bill_Reports_Empty(HML_BillDTO model)
        {
            return View();
        }




    }
}
