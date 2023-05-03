using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Controllers;
using AS_CLOUD_HOTEL.Models;
using RazorPDF;

namespace AS_CLOUD_HOTEL.Controllers
{
    public class ListReportController : AppController
    {
        private CLoudHotelDbContext db = new CLoudHotelDbContext();

       

        //public ActionResult GetListOfParty()
        //{
        //    //var pdf = new PdfResult(null, "GetListOfParty");
        //    //return pdf;
        //    return View();
        //}


        //public ActionResult GetExpensesList()
        //{
        //    //var pdf = new PdfResult(null, "GetExpensesList");
        //    //return pdf;
        //    return View();
        //}

        public ActionResult Get_HeadOfAccounts_List()
        {
            //var pdf = new PdfResult(null, "Get_HeadOfAccounts_List");
            //return pdf;
            return View();
        }

        public ActionResult Get_ListofCostPool()
        {
            return View();
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
