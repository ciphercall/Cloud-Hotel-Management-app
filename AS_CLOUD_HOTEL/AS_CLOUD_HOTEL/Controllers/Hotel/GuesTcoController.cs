using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class GuesTcoController : AppController
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


        public GuesTcoController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_GuesTco_LogData(HML_GUESTCO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }


            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.INSUSERID;
            aslLog.LOGTYPE = "INSERT";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = model.INSIPNO;
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_GUESTCO";

            aslLog.LOGDATA = Convert.ToString("Company Creation Page.Company Name: " + model.GCONM + ",\nAddress" + model.ADDRESS + ",\nORGCNO: " + model.ORGCNO + ",\nEmail: " + model.EMAILID + ",\nCPNM: " + model.CPNM + ",\nCPPOST: " + model.CPPOST + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nDiscount: " + model.DISCRT + ",\nRemarks: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_GuesTco_LogData(HML_GUESTCO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.UPDUSERID;
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = model.UPDIPNO;
            aslLog.LOGLTUDE = model.UPDLTUDE;
            aslLog.TABLEID = "HML_GUESTCO";

            aslLog.LOGDATA = Convert.ToString("Company Update Page. Company Name: " + model.GCONM + ",\nAddress" + model.ADDRESS + ",\nORGCNO: " + model.ORGCNO + ",\nEmail: " + model.EMAILID + ",\nCPNM: " + model.CPNM + ",\nCPPOST: " + model.CPPOST + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nDiscount: " + model.DISCRT + ",\nRemarks: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_GuesTco_LogData(HML_GuesTcoDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("hh:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslLogDbSet where n.COMPID == model.COMPID && n.USERID == model.UPDUSERID select n.LOGSLNO).Max());
            if (maxSerialNo == 0)
            {
                aslLog.LOGSLNO = Convert.ToInt64("1");
            }
            else
            {
                aslLog.LOGSLNO = maxSerialNo + 1;
            }

            aslLog.COMPID = Convert.ToInt64(model.COMPID);
            aslLog.USERID = model.UPDUSERID;
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = model.UPDIPNO;
            aslLog.LOGLTUDE = model.UPDLTUDE;
            aslLog.TABLEID = "HML_GUESTCO";

            aslLog.LOGDATA = Convert.ToString("Company Delete Page.Company Name: " + model.GCONM + ",\nAddress" + model.ADDRESS + ",\nORGCNO: " + model.ORGCNO + ",\nEmail: " + model.EMAILID + ",\nCPNM: " + model.CPNM + ",\nCPPOST: " + model.CPPOST + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nDiscount: " + model.DISCRT + ",\nRemarks: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_GuesTco_DELETE(HML_GuesTcoDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("HH:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == model.COMPID && n.USERID == model.UPDUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(model.COMPID);
            AslDelete.USERID = model.UPDUSERID;
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = model.UPDIPNO;
            AslDelete.DELLTUDE = model.UPDLTUDE;
            AslDelete.TABLEID = "HML_GUESTCO";

            AslDelete.DELDATA = Convert.ToString("Company Delete Page. Company Name: " + model.GCONM + ",\nAddress" + model.ADDRESS + ",\nORGCNO: " + model.ORGCNO + ",\nEmail: " + model.EMAILID + ",\nCPNM: " + model.CPNM + ",\nCPPOST: " + model.CPPOST + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nDiscount: " + model.DISCRT + ",\nRemarks: " + model.REMARKS + ".");
            AslDelete.USERPC = model.USERPC;
            db.AslDeleteDbSet.Add(AslDelete);
        }










        // GET
        public ActionResult Create()
        {
            return View();
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HML_GuesTcoDTO dtoModel)
        {
            if (ModelState.IsValid)
            {
                Int64 findMax_GCOID = 0;
                try
                {
                    findMax_GCOID = Convert.ToInt64((from m in db.HmlGuestcoDbSet
                                                     where m.COMPID == dtoModel.COMPID && m.GCOGID == dtoModel.GCOGID
                                                     select m.GCOID).Max());
                    dtoModel.GCOID = findMax_GCOID + 1;
                }
                catch
                {
                    findMax_GCOID = Convert.ToInt64(dtoModel.COMPID + "2050001");
                    dtoModel.GCOID = findMax_GCOID;
                }

                String headcd_String = dtoModel.COMPID + "205";
                Int64 headCD = Convert.ToInt64(headcd_String);
                int headType = 2;
                var check_GL_ACCHART = (from data in db.GlAcchartDbSet
                                        where data.COMPID == dtoModel.COMPID && data.HEADTP == headType && data.HEADCD == headCD &&
                                            data.ACCOUNTCD == dtoModel.GCOID
                                        select data).ToList();
                if (check_GL_ACCHART.Count != 0)
                {
                    TempData["GuesTcoCreateMessage"] = "This id-" + dtoModel.GCOID + "already matched in Account table. Please delete Account table data then create Guest company information";
                    return RedirectToAction("Create");
                }
                else
                {

                    Int64 max = Convert.ToInt64(dtoModel.COMPID + "2059999");
                    if (dtoModel.GCOID <= max)
                    {
                        HML_GUESTCO model = new HML_GUESTCO();
                        model.COMPID = dtoModel.COMPID;
                        model.GCOGID = Convert.ToInt64(dtoModel.GCOGID);
                        model.GCOID = Convert.ToInt64(dtoModel.GCOID);
                        model.GCONM = dtoModel.GCONM;
                        model.ADDRESS = dtoModel.ADDRESS;
                        model.ORGCNO = dtoModel.ORGCNO;
                        model.EMAILID = dtoModel.EMAILID;
                        model.CPNM = dtoModel.CPNM;
                        model.CPPOST = dtoModel.CPPOST;
                        model.MOBNO1 = dtoModel.MOBNO1;
                        model.MOBNO2 = dtoModel.MOBNO2;
                        model.DISCRT = dtoModel.DISCRT;
                        model.REMARKS = dtoModel.REMARKS;

                        model.USERPC = strHostName;
                        model.INSIPNO = ipAddress.ToString();
                        model.INSTIME = Convert.ToDateTime(td);
                        model.INSUSERID = dtoModel.INSUSERID;

                        Insert_GuesTco_LogData(model);
                        db.HmlGuestcoDbSet.Add(model);
                        db.SaveChanges();

                        GL_ACCHART glAcchart = new GL_ACCHART();
                        glAcchart.COMPID = dtoModel.COMPID;
                        glAcchart.HEADTP = headType;
                        glAcchart.HEADCD = headCD;
                        glAcchart.ACCOUNTCD = dtoModel.GCOID;
                        glAcchart.ACCOUNTNM = dtoModel.GCONM;

                        glAcchart.USERPC = strHostName;
                        glAcchart.INSIPNO = ipAddress.ToString();
                        glAcchart.INSTIME = Convert.ToDateTime(td);
                        glAcchart.INSUSERID = dtoModel.INSUSERID;

                        db.GlAcchartDbSet.Add(glAcchart);
                        db.SaveChanges();

                        TempData["GuesTcoCreateMessage"] = "Successfully entry ! ";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["GuesTcoCreateMessage"] = "Entry Not Possible ! ";
                        return RedirectToAction("Create");
                    }
                }


            }
            return View("Create");
        }










        //Get
        public ActionResult Update()
        {
            return View();
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(HML_GuesTcoDTO dtoModel)
        {
            if (ModelState.IsValid)
            {


                HML_GUESTCO model = new HML_GUESTCO();

                model.ID = dtoModel.ID;
                model.COMPID = dtoModel.COMPID;
                model.GCOGID = Convert.ToInt64(dtoModel.GCOGID);
                model.GCOID = Convert.ToInt64(dtoModel.GCOID);
                model.GCONM = dtoModel.GCONM;
                model.ADDRESS = dtoModel.ADDRESS;
                model.ORGCNO = dtoModel.ORGCNO;
                model.EMAILID = dtoModel.EMAILID;
                model.CPNM = dtoModel.CPNM;
                model.CPPOST = dtoModel.CPPOST;
                model.MOBNO1 = dtoModel.MOBNO1;
                model.MOBNO2 = dtoModel.MOBNO2;
                model.DISCRT = dtoModel.DISCRT;
                model.REMARKS = dtoModel.REMARKS;
                model.INSIPNO = dtoModel.INSIPNO;
                model.INSTIME = dtoModel.INSTIME;
                model.INSUSERID = dtoModel.INSUSERID;


                db.Entry(model).State = EntityState.Modified;
                model.USERPC = strHostName;
                model.UPDIPNO = ipAddress.ToString();
                model.UPDTIME = Convert.ToDateTime(td);
                model.UPDUSERID = dtoModel.UPDUSERID;

                Update_GuesTco_LogData(model);
                db.SaveChanges();

                //String headcd_String = dtoModel.COMPID + "205";
                //Int64 headCD = Convert.ToInt64(headcd_String);
                //int headType = 2;
                //var check_GL_ACCHART = (from data in db.GlAcchartDbSet
                //                        where data.COMPID == dtoModel.COMPID && data.HEADTP == headType && data.HEADCD == headCD &&
                //                            data.ACCOUNTCD == dtoModel.GCOID
                //                        select data).ToList();

                //if (check_GL_ACCHART.Count == 1)
                //{
                //    foreach (GL_ACCHART glAcchart in check_GL_ACCHART)
                //    {
                //        glAcchart.ACCOUNTNM = dtoModel.GCONM;

                //        glAcchart.USERPC = strHostName;
                //        glAcchart.UPDIPNO = ipAddress.ToString();
                //        glAcchart.UPDTIME = Convert.ToDateTime(td);
                //        glAcchart.UPDUSERID = dtoModel.UPDUSERID;
                //    }
                //    db.SaveChanges();
                //}

                TempData["GuesTcoUpdateMessage"] = "Successfully updated!";
                return RedirectToAction("Update");

            }
            return View("Update");

        }







        //Get
        public ActionResult Delete()
        {
            return View();
        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HML_GuesTcoDTO dtoModel)
        {
            if (ModelState.IsValid)
            {
                var check_GL_MASTER = (from data in db.GlMasterDbSet
                                        where data.COMPID == dtoModel.COMPID && data.DEBITCD == dtoModel.GCOID 
                                        select data).ToList();
                if (check_GL_MASTER.Count == 0)
                {
                    var checkData =
                        (from m in db.HmlGuestcoDbSet
                            where m.COMPID == dtoModel.COMPID && m.GCOID == dtoModel.GCOID
                            select m).ToList();
                    if (checkData.Count == 1)
                    {
                        HML_GUESTCO deleteModel = db.HmlGuestcoDbSet.Find(dtoModel.ID, dtoModel.COMPID, dtoModel.GCOID);

                        dtoModel.USERPC = strHostName;
                        dtoModel.UPDIPNO = ipAddress.ToString();
                        dtoModel.UPDTIME = Convert.ToDateTime(td);
                        dtoModel.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                        dtoModel.UPDLTUDE = dtoModel.UPDLTUDE;

                        Delete_GuesTco_DELETE(dtoModel);
                        Delete_GuesTco_LogData(dtoModel);
                        db.SaveChanges();

                        db.HmlGuestcoDbSet.Remove(deleteModel);
                        db.SaveChanges();

                        TempData["GuesTcoDeleteMessage"] = "Successfully deleted!";
                        return RedirectToAction("Delete");
                    }
                }
                else
                {
                    TempData["GuesTcoDeleteMessage"] = "This Data already exists!";
                    return RedirectToAction("Delete");
                }

            }
            return View();
        }






        public JsonResult TagSearch_Update_Delete(string character, string gcogid, string compid)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);
            Int64 gcogID = Convert.ToInt64(gcogid);

            var findReferName =
                (from m in db.HmlGuestcoDbSet
                 where m.COMPID == companyID && m.GCOGID == gcogID
                 select new { m.GCONM }).ToList();
            foreach (var a in findReferName)
            {
                result.Add(a.GCONM.ToString());
            }
            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_Update_Delete(string changedText, string gcogid, string compid)
        {
            var companyID = Convert.ToInt16(compid);
            String itemId = "";
            Int64 gcogID = Convert.ToInt64(gcogid);


            List<string> list = new List<string>();


            var findReferName = (from m in db.HmlGuestcoDbSet where m.COMPID == companyID && m.GCOGID == gcogID select new { m.GCONM }).ToList();
            foreach (var a in findReferName)
            {
                list.Add(a.GCONM.ToString());
            }

            var rt = list.Where(t => t.StartsWith(changedText)).ToList();

            int lenChangedtxt = changedText.Length;

            Int64 cont = rt.Count();
            Int64 k = 0;
            string status = "";
            if (changedText != "" && cont != 0)
            {
                while (status != "no")
                {
                    k = 0;
                    foreach (var n in rt)
                    {
                        string ss = Convert.ToString(n);
                        string subss = "";
                        if (ss.Length >= lenChangedtxt)
                        {
                            subss = ss.Substring(0, lenChangedtxt);
                            subss = subss.ToUpper();
                        }
                        else
                        {
                            subss = "";
                        }


                        if (subss == changedText.ToUpper())
                        {
                            k++;
                        }
                        if (k == cont)
                        {
                            status = "yes";
                            lenChangedtxt++;
                            if (ss.Length > lenChangedtxt - 1)
                            {
                                changedText = changedText + ss[lenChangedtxt - 1];
                            }

                        }
                        else
                        {
                            status = "no";
                            //lenChangedtxt--;
                        }

                    }

                }
                if (lenChangedtxt == 1)
                {
                    itemId = changedText.Substring(0, lenChangedtxt);
                }

                else
                {
                    itemId = changedText.Substring(0, lenChangedtxt - 1);
                }
            }
            else
            {
                itemId = changedText;
            }

            string companyName = "", address = "", mobNo1 = "", mobNo2 = "", email = "", cpName = "", cpPost = "", orgCNO = "", remarks = "", discount = "";
            Int64 insertUserId = 0, id = 0;
            String inserttime = "", insertIpno = "", insltude = "";

            var getData = (from m in db.HmlGuestcoDbSet where m.COMPID == companyID && m.GCONM == itemId && m.GCOGID == gcogID select m).ToList();

            foreach (var get in getData)
            {
                id = get.ID;
                gcogID = Convert.ToInt64(get.GCOID);
                companyName = get.GCONM;
                address = get.ADDRESS;
                orgCNO = get.ORGCNO;
                email = get.EMAILID;
                cpName = get.CPNM;
                cpPost = get.CPPOST;
                mobNo1 = get.MOBNO1;
                mobNo2 = get.MOBNO2;
                discount = Convert.ToString(get.DISCRT);
                remarks = get.REMARKS;

                insertUserId = get.INSUSERID;
                inserttime = Convert.ToString(get.INSTIME);
                insertIpno = Convert.ToString(get.INSIPNO);
                insltude = Convert.ToString(get.INSLTUDE);
            }

            var result = new
            {
                ID = id,
                GCOID = gcogID,
                GCONM = companyName,
                ADDRESS = address,
                ORGCNO = orgCNO,
                EMAILID = email,
                CPNM = cpName,
                CPPOST = cpPost,
                MOBNO1 = mobNo1,
                MOBNO2 = mobNo2,
                DISCRT = discount,
                REMARKS = remarks,

                INSUSERID = insertUserId,
                INSTIME = inserttime,
                INSIPNO = insertIpno,
                INSLTUDE = insltude
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public JsonResult Check_CompanyName(string gconm)
        {
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());
            var result = db.HmlGuestcoDbSet.Count(d => d.GCONM == gconm && d.COMPID == compid) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
