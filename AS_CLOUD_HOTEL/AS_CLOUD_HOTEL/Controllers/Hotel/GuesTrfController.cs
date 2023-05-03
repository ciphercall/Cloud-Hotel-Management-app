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
    public class GuesTrfController : AppController
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


        public GuesTrfController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            //td = DateTime.Now;
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ASL_LOG aslLog = new ASL_LOG();

        public void Insert_GuesTrf_LogData(HML_GUESTRF model)
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
            aslLog.TABLEID = "HML_GUESTRF";

            aslLog.LOGDATA = Convert.ToString("Refer Creation Page. Refer Name: " + model.REFERNM + ",\nAddress" + model.ADDRESS + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nEmail: " + model.EMAILID + ",\nORGNM: " + model.ORGNM + ",\nPOSTNM: " + model.POSTNM + ",\nORGCNO: " + model.ORGCNO + ",\nRefer (%): " + model.RFPCNT + ",\nRemarks: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }




        public void Update_GuesTrf_LogData(HML_GUESTRF model)
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
            aslLog.TABLEID = "HML_GUESTRF";

            aslLog.LOGDATA = Convert.ToString("Refer Update Page. Refer Name: " + model.REFERNM + ",\nAddress" + model.ADDRESS + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nEmail: " + model.EMAILID + ",\nORGNM: " + model.ORGNM + ",\nPOSTNM: " + model.POSTNM + ",\nORGCNO: " + model.ORGCNO + ",\nRefer (%): " + model.RFPCNT + ",\nRemarks: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }



        public void Delete_GuesTrf_LogData(HML_GuesTrfDTO model)
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
            aslLog.TABLEID = "HML_GUESTRF";

            aslLog.LOGDATA = Convert.ToString("Refer Delete Page. Refer Name: " + model.REFERNM + ",\nAddress" + model.ADDRESS + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nEmail: " + model.EMAILID + ",\nORGNM: " + model.ORGNM + ",\nPOSTNM: " + model.POSTNM + ",\nORGCNO: " + model.ORGCNO + ",\nRefer (%): " + model.RFPCNT + ",\nRemarks: " + model.REMARKS + ".");
            aslLog.USERPC = model.USERPC;
            db.AslLogDbSet.Add(aslLog);
        }







        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_GuesTrf_DELETE(HML_GuesTrfDTO model)
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
            AslDelete.TABLEID = "HML_GUESTRF";

            AslDelete.DELDATA = Convert.ToString("Refer Delete Page. Refer Name: " + model.REFERNM + ",\nAddress" + model.ADDRESS + ",\nMobile No 1: " + model.MOBNO1 + ",\nMobile No 2: " + model.MOBNO2 + ",\nEmail: " + model.EMAILID + ",\nORGNM: " + model.ORGNM + ",\nPOSTNM: " + model.POSTNM + ",\nORGCNO: " + model.ORGCNO + ",\nRefer (%): " + model.RFPCNT + ",\nRemarks: " + model.REMARKS + ".");
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
        public ActionResult Create(HML_GuesTrfDTO dtoModel)
        {
            if (ModelState.IsValid)
            {
                Int64 findMax_GRFID = 0;
                try
                {
                    findMax_GRFID = Convert.ToInt64((from m in db.HmlGuestrfDbSet
                                                     where m.COMPID == dtoModel.COMPID && m.GRFGID == dtoModel.GRFGID
                                                     select m.GRFID).Max());
                    dtoModel.GRFID = findMax_GRFID + 1;
                }
                catch
                {
                    findMax_GRFID = Convert.ToInt64(dtoModel.COMPID + "2060001");
                    dtoModel.GRFID = findMax_GRFID;
                }

                String headcd_String = dtoModel.COMPID + "206";
                Int64 headCD = Convert.ToInt64(headcd_String);
                int headType = 2;
                var check_GL_ACCHART = (from data in db.GlAcchartDbSet
                                        where data.COMPID == dtoModel.COMPID && data.HEADTP == headType && data.HEADCD == headCD &&
                                            data.ACCOUNTCD == dtoModel.GRFID
                                        select data).ToList();
                if (check_GL_ACCHART.Count != 0)
                {
                    TempData["GuesTrfCreateMessage"] = "This id-" + dtoModel.GRFID +
                                                       "already matched in Account table.Please delete Account table data then create Guest refer information!!";
                    return RedirectToAction("Create");
                }
                else
                {
                    Int64 max = Convert.ToInt64(dtoModel.COMPID + "2069999");
                    if (dtoModel.GRFID <= max)
                    {
                        GL_ACCHART glAcchart = new GL_ACCHART();
                        glAcchart.COMPID = dtoModel.COMPID;
                        glAcchart.HEADTP = headType;
                        glAcchart.HEADCD = headCD;
                        glAcchart.ACCOUNTCD = dtoModel.GRFID;
                        glAcchart.ACCOUNTNM = dtoModel.REFERNM;

                        glAcchart.USERPC = strHostName;
                        glAcchart.INSIPNO = ipAddress.ToString();
                        glAcchart.INSTIME = Convert.ToDateTime(td);
                        glAcchart.INSUSERID = dtoModel.INSUSERID;

                        db.GlAcchartDbSet.Add(glAcchart);
                        db.SaveChanges();

                        HML_GUESTRF model = new HML_GUESTRF();
                        model.COMPID = dtoModel.COMPID;
                        model.GRFGID = Convert.ToInt64(dtoModel.GRFGID);
                        model.GRFID = Convert.ToInt64(dtoModel.GRFID);
                        model.REFERNM = dtoModel.REFERNM;
                        model.ADDRESS = dtoModel.ADDRESS;
                        model.MOBNO1 = dtoModel.MOBNO1;
                        model.MOBNO2 = dtoModel.MOBNO2;
                        model.EMAILID = dtoModel.EMAILID;
                        model.ORGNM = dtoModel.ORGNM;
                        model.POSTNM = dtoModel.POSTNM;
                        model.ORGCNO = dtoModel.ORGCNO;
                        model.RFPCNT = dtoModel.RFPCNT;
                        model.REMARKS = dtoModel.REMARKS;

                        model.USERPC = strHostName;
                        model.INSIPNO = ipAddress.ToString();
                        model.INSTIME = Convert.ToDateTime(td);
                        model.INSUSERID = dtoModel.INSUSERID;
                        
                        Insert_GuesTrf_LogData(model);
                        db.HmlGuestrfDbSet.Add(model);
                        db.SaveChanges();

                        TempData["GuesTrfCreateMessage"] = "Successfully entry ! ";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["GuesTrfCreateMessage"] = "Entry Not Possible ! ";
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
        public ActionResult Update(HML_GuesTrfDTO dtoModel)
        {
            if (ModelState.IsValid)
            {
                HML_GUESTRF model = new HML_GUESTRF();
                model.ID = dtoModel.ID;
                model.COMPID = dtoModel.COMPID;
                model.GRFGID = Convert.ToInt64(dtoModel.GRFGID);
                model.GRFID = Convert.ToInt64(dtoModel.GRFID);
                model.REFERNM = dtoModel.REFERNM;
                model.ADDRESS = dtoModel.ADDRESS;
                model.MOBNO1 = dtoModel.MOBNO1;
                model.MOBNO2 = dtoModel.MOBNO2;
                model.EMAILID = dtoModel.EMAILID;
                model.ORGNM = dtoModel.ORGNM;
                model.POSTNM = dtoModel.POSTNM;
                model.ORGCNO = dtoModel.ORGCNO;
                model.RFPCNT = dtoModel.RFPCNT;
                model.REMARKS = dtoModel.REMARKS;
                model.INSIPNO = dtoModel.INSIPNO;
                model.INSTIME = dtoModel.INSTIME;
                model.INSUSERID = dtoModel.INSUSERID;


                db.Entry(model).State = EntityState.Modified;
                model.USERPC = strHostName;
                model.UPDIPNO = ipAddress.ToString();
                model.UPDTIME = Convert.ToDateTime(td);
                model.UPDUSERID = dtoModel.UPDUSERID;

                Update_GuesTrf_LogData(model);
                db.SaveChanges();


                //String headcd_String = dtoModel.COMPID + "206";
                //Int64 headCD = Convert.ToInt64(headcd_String);
                //int headType = 2;
                //var check_GL_ACCHART = (from data in db.GlAcchartDbSet
                //                        where data.COMPID == dtoModel.COMPID && data.HEADTP == headType && data.HEADCD == headCD &&
                //                            data.ACCOUNTCD == dtoModel.GRFID
                //                        select data).ToList();

                //if (check_GL_ACCHART.Count == 1)
                //{
                //    foreach (GL_ACCHART glAcchart in check_GL_ACCHART)
                //    {
                //        glAcchart.ACCOUNTNM = dtoModel.REFERNM;

                //        glAcchart.USERPC = strHostName;
                //        glAcchart.UPDIPNO = ipAddress.ToString();
                //        glAcchart.UPDTIME = Convert.ToDateTime(td);
                //        glAcchart.UPDUSERID = dtoModel.UPDUSERID;
                //    }
                //    db.SaveChanges();
                //}



                TempData["GuesTrfUpdateMessage"] = "Successfully updated!";
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
        public ActionResult Delete(HML_GuesTrfDTO dtoModel)
        {
            if (ModelState.IsValid)
            {
                var check_GL_MASTER = (from data in db.GlMasterDbSet
                                       where data.COMPID == dtoModel.COMPID && data.DEBITCD == dtoModel.GRFID
                                       select data).ToList();
                if (check_GL_MASTER.Count == 0)
                {
                    var checkData =
                        (from m in db.HmlGuestrfDbSet
                            where m.COMPID == dtoModel.COMPID && m.GRFID == dtoModel.GRFID
                            select m).ToList();
                    if (checkData.Count == 1)
                    {
                        HML_GUESTRF deleteModel = db.HmlGuestrfDbSet.Find(dtoModel.ID, dtoModel.COMPID, dtoModel.GRFID);

                        dtoModel.USERPC = strHostName;
                        dtoModel.UPDIPNO = ipAddress.ToString();
                        dtoModel.UPDTIME = Convert.ToDateTime(td);
                        dtoModel.UPDUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                        dtoModel.UPDLTUDE = dtoModel.UPDLTUDE;

                        Delete_GuesTrf_DELETE(dtoModel);
                        Delete_GuesTrf_LogData(dtoModel);
                        db.SaveChanges();

                        db.HmlGuestrfDbSet.Remove(deleteModel);
                        db.SaveChanges();

                        TempData["GuesTrfDeleteMessage"] = "Successfully deleted!";
                        return RedirectToAction("Delete");
                    }
                }
                else
                {
                    TempData["GuesTrfDeleteMessage"] = "This Data already exists!";
                    return RedirectToAction("Delete");
                }
            }
            return View();
        }






        public JsonResult TagSearch_Update_Delete(string character, string grfgid, string compid)
        {
            List<string> result = new List<string>();
            Int64 companyID = Convert.ToInt16(compid);
            Int64 grfgID = Convert.ToInt64(grfgid);

            var findReferName =
                (from m in db.HmlGuestrfDbSet
                 where m.COMPID == companyID && m.GRFGID == grfgID
                 select new { m.REFERNM }).ToList();
            foreach (var a in findReferName)
            {
                result.Add(a.REFERNM.ToString());
            }
            return this.Json(result.Where(t => t.StartsWith(character)), JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_Update_Delete(string changedText, string grfgid, string compid)
        {
            var companyID = Convert.ToInt16(compid);
            String itemId = "";
            Int64 grfgID = Convert.ToInt64(grfgid);


            List<string> list = new List<string>();


            var findReferName = (from m in db.HmlGuestrfDbSet where m.COMPID == companyID && m.GRFGID == grfgID select new { m.REFERNM }).ToList();
            foreach (var a in findReferName)
            {
                list.Add(a.REFERNM.ToString());
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

            string refernam = "", address = "", mobNo1 = "", mobNo2 = "", email = "", orgnm = "", postName = "", orgCNO = "", remarks = "", referPercent = "";
            Int64 insertUserId = 0, id = 0, grfid = 0;
            String inserttime = "", insertIpno = "", insltude = "";

            var getData = (from m in db.HmlGuestrfDbSet where m.COMPID == companyID && m.REFERNM == itemId && m.GRFGID == grfgID select m).ToList();

            foreach (var get in getData)
            {
                id = get.ID;
                grfid = Convert.ToInt64(get.GRFID);
                refernam = get.REFERNM;
                address = get.ADDRESS;
                mobNo1 = get.MOBNO1;
                mobNo2 = get.MOBNO2;
                email = get.EMAILID;
                orgnm = get.ORGNM;
                postName = get.POSTNM;
                orgCNO = get.ORGCNO;
                referPercent = Convert.ToString(get.RFPCNT);
                remarks = get.REMARKS;

                insertUserId = get.INSUSERID;
                inserttime = Convert.ToString(get.INSTIME);
                insertIpno = Convert.ToString(get.INSIPNO);
                insltude = Convert.ToString(get.INSLTUDE);
            }

            var result = new
            {
                ID = id,
                GRFID = grfid,
                REFERNM = refernam,
                ADDRESS = address,
                MOBNO1 = mobNo1,
                MOBNO2 = mobNo2,
                EMAILID = email,
                ORGNM = orgnm,
                POSTNM = postName,
                ORGCNO = orgCNO,
                RFPCNT = referPercent,
                REMARKS = remarks,

                INSUSERID = insertUserId,
                INSTIME = inserttime,
                INSIPNO = insertIpno,
                INSLTUDE = insltude
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public JsonResult Check_ReferName(string refernm)
        {
            var compid = Convert.ToInt16(System.Web.HttpContext.Current.Session["loggedCompID"].ToString());
            var result = db.HmlGuestrfDbSet.Count(d => d.REFERNM == refernm && d.COMPID == compid) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
