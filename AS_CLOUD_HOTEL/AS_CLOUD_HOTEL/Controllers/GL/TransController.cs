﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.Controllers
{
    public class TransController : AppController
    {

        public TransController()
        {
            ViewData["HighLight_Menu_AccountReports"] = "High Light Menu";
        }



        // GET: /PosTrans/
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(PageModel model)
        {
            //var pdf = new PdfResult(aCnfJobModel, "GetJOBRegister_JobTypeReport");
            //return pdf;

            TempData["POS_Ledger"] = model;
            return RedirectToAction("TransReport");
        }
        public ActionResult TransReport()
        {
            PageModel model = (PageModel)TempData["POS_Ledger"];
            return View(model);
        }

    }
}
