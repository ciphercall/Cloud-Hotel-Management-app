using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Hotel
{
    public class BillController : AppController
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

        public BillController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            ViewData["HighLight_Menu_HotelForm"] = "Heigh Light Menu";
        }




        public ASL_LOG aslLog = new ASL_LOG();


        public void Insert_BillMaster_LogData(HML_BillDTO model)
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
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Create Bill master Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nTotal Amount: " + model.TOTAMT + "'\nService-Charge Rate: " + model.SCHARGE_RT + "%" + "'\nService-Charge: " + model.SCHARGE + ",\nVate Rate: " + model.VATAMT_RT + "%" + ",\nVate Amount: " + model.VATAMT + ",\nGrossAmount: " + model.GROSSAMT + ",\nAdvance Amount: " + model.ADVAMT + ",\nDiscount: " + model.DISCOUNT + ",\nNet Amount: " + model.NETAMT + ",\nPaid Amount: " + model.PAIDAMT + ",\nBalance Amount: " + model.BALAMT + ",\nRemarks: " + model.REMARKS_TotalBill + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }



        public void Update_BillMaster_LogData(HML_BillDTO model,String crudOperation)
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
            aslLog.LOGTYPE = crudOperation;
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Update Bill master Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nTotal Amount: " + model.TOTAMT + "'\nService-Charge Rate: " + model.SCHARGE_RT + "%" + "'\nService-Charge: " + model.SCHARGE + ",\nVate Rate: " + model.VATAMT_RT + "%" + ",\nVate Amount: " + model.VATAMT + ",\nGrossAmount: " + model.GROSSAMT + ",\nAdvance Amount: " + model.ADVAMT + ",\nDiscount: " + model.DISCOUNT + ",\nNet Amount: " + model.NETAMT + ",\nPaid Amount: " + model.PAIDAMT + ",\nBalance Amount: " + model.BALAMT + ",\nRemarks: " + model.REMARKS_TotalBill + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }


        public void Delete_BillMaster_LogData(HML_BillDTO model)
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
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Delete Bill master Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nTotal Amount: " + model.TOTAMT + "'\nService-Charge Rate: " + model.SCHARGE_RT + "%" + "'\nService-Charge: " + model.SCHARGE + ",\nVate Rate: " + model.VATAMT_RT + "%" + ",\nVate Amount: " + model.VATAMT + ",\nGrossAmount: " + model.GROSSAMT + ",\nAdvance Amount: " + model.ADVAMT + ",\nDiscount: " + model.DISCOUNT + ",\nNet Amount: " + model.NETAMT + ",\nPaid Amount: " + model.PAIDAMT + ",\nBalance Amount: " + model.BALAMT + ",\nRemarks: " + model.REMARKS_TotalBill + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }



        public void Insert_BillDetails_LogData_Submit(HML_BillDTO model)
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
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILLDTL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Create Bill details Information (Submit Type).Total Bill Details: " + model.count + " Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }



        public void Insert_BillDetails_LogData(HML_BillDTO model)
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
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILLDTL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Create Bill details Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill Name: " + model.BILLNM + ",\nAmount: " + model.AMOUNT + ",\nRemarks: " + model.REMARKS_BillDetails + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }



        public void update_BillDetails_LogData(HML_BillDTO model)
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
            aslLog.LOGTYPE = "UPDATE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILLDTL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Update Bill details Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill Name: " + model.BILLNM + ",\nAmount: " + model.AMOUNT +",\nRemarks: " + model.REMARKS_BillDetails + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }



        public void Delete_BillDetails_LogData(HML_BillDTO model)
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
            aslLog.LOGTYPE = "DELETE";
            aslLog.LOGSLNO = aslLog.LOGSLNO;
            aslLog.LOGDATE = Convert.ToDateTime(date);
            aslLog.LOGTIME = Convert.ToString(time);
            aslLog.LOGIPNO = ipAddress.ToString();
            aslLog.LOGLTUDE = model.INSLTUDE;
            aslLog.TABLEID = "HML_BILLDTL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            aslLog.LOGDATA = Convert.ToString("Delete Bill details Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill Name: " + model.BILLNM + ",\nAmount: " + model.AMOUNT +",\nRemarks: " + model.REMARKS_BillDetails + ".");
            aslLog.USERPC = strHostName;

            db.AslLogDbSet.Add(aslLog);
            db.SaveChanges();
        }






        public ASL_DELETE AslDelete = new ASL_DELETE();

        public void Delete_BillMaster_LogDelete(HML_BillDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("HH:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(model.COMPID);
            AslDelete.USERID = model.INSUSERID;
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = ipAddress.ToString();
            AslDelete.DELLTUDE = model.INSLTUDE;
            AslDelete.TABLEID = "HML_BILL";

            DateTime date1 = Convert.ToDateTime(model.TRANSDT);
            string transDate = date1.ToString("dd-MMM-yyyy");
            AslDelete.DELDATA = Convert.ToString("Delete Bill master Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nTotal Amount: " + model.TOTAMT + "'\nService-Charge Rate: " + model.SCHARGE_RT + "%" + "'\nService-Charge: " + model.SCHARGE + ",\nVate Rate: " + model.VATAMT_RT + "%" + ",\nVate Amount: " + model.VATAMT + ",\nGrossAmount: " + model.GROSSAMT + ",\nAdvance Amount: " + model.ADVAMT + ",\nDiscount: " + model.DISCOUNT + ",\nNet Amount: " + model.NETAMT + ",\nPaid Amount: " + model.PAIDAMT + ",\nBalance Amount: " + model.BALAMT + ",\nRemarks: " + model.REMARKS_TotalBill + ".");
            AslDelete.USERPC = strHostName;
            db.AslDeleteDbSet.Add(AslDelete);
        }

        public void Delete_BillDetails_LogDelete(HML_BillDTO model)
        {
            TimeZoneInfo timeZoneInfo;
            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime PrintDate = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var date = Convert.ToString(PrintDate.ToString("dd-MMM-yyyy"));
            var time = Convert.ToString(PrintDate.ToString("HH:mm:ss tt"));

            Int64 maxSerialNo = Convert.ToInt64((from n in db.AslDeleteDbSet where n.COMPID == model.COMPID && n.USERID == model.INSUSERID select n.DELSLNO).Max());
            if (maxSerialNo == 0)
            {
                AslDelete.DELSLNO = Convert.ToInt64("1");
            }
            else
            {
                AslDelete.DELSLNO = maxSerialNo + 1;
            }

            AslDelete.COMPID = Convert.ToInt64(model.COMPID);
            AslDelete.USERID = model.INSUSERID;
            AslDelete.DELSLNO = AslDelete.DELSLNO;
            AslDelete.DELDATE = Convert.ToString(date);
            AslDelete.DELTIME = Convert.ToString(time);
            AslDelete.DELIPNO = ipAddress.ToString();
            AslDelete.DELLTUDE = model.INSLTUDE;
            AslDelete.TABLEID = "HML_BILLDTL";

            DateTime x = Convert.ToDateTime(model.TRANSDT);
            String transDate = x.ToString("dd-MMM-yyyy");
            AslDelete.DELDATA = Convert.ToString("Delete Bill details Information. Trasaction Date: " + transDate + ",\nMemo No: " + model.TRANSNO + ",\nMonth-Year: " + model.TRANSMY + ",\nRoomNo: " + model.ROOMNO + ",\nRegistration-ID: " + model.REGNID + ",\nBill Name: " + model.BILLNM + ",\nAmount: " + model.AMOUNT + ",\nRemarks: " + model.REMARKS_BillDetails + ".");
            AslDelete.USERPC = strHostName;
            db.AslDeleteDbSet.Add(AslDelete);
        }







        // GET: /Bill/
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        [ActionName("Create")]
        public ActionResult CreatePost(HML_BillDTO model, string command)
        {
            if (command == "Save" || command == "A4" || command == "POS")
            {
                var checkPharmacy = (from n in db.HmlBillDetailsDbSet
                                     where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                     select n).ToList();
                if (checkPharmacy.Count == 0)
                {
                    TempData["Bill-Create"] = "Please input valid data !";
                    return RedirectToAction("Create");
                }

                HML_BILL billMaster = new HML_BILL();
                var checkBillMaster = (from n in db.HmlBillDbSet
                                       where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                       select n).ToList();
                if (checkBillMaster.Count == 0)
                {
                    billMaster.COMPID = model.COMPID;
                    billMaster.TRANSDT = Convert.ToDateTime(model.TRANSDT);
                    billMaster.TRANSMY = model.TRANSMY;
                    billMaster.TRANSNO = model.TRANSNO;
                    billMaster.ROOMNO = model.ROOMNO;
                    billMaster.REGNID = model.REGNID;

                    billMaster.TOTAMT = model.TOTAMT;
                    billMaster.SCHARGE = model.SCHARGE;
                    billMaster.VATAMT = model.VATAMT;
                    billMaster.GROSSAMT = model.GROSSAMT;
                    billMaster.ADVAMT = model.ADVAMT;
                    billMaster.DISCOUNT = model.DISCOUNT;
                    billMaster.NETAMT = model.NETAMT;
                    billMaster.PAIDAMT = model.PAIDAMT;
                    billMaster.BALAMT = model.BALAMT;
                    if (billMaster.BALAMT > 0)
                    {
                        billMaster.DUEHID = model.DUEHID;
                    }
                    billMaster.REMARKS = model.REMARKS_TotalBill;

                    billMaster.USERPC = strHostName;
                    billMaster.INSIPNO = ipAddress.ToString();
                    billMaster.INSTIME = Convert.ToDateTime(td);
                    billMaster.INSUSERID = model.INSUSERID;
                    billMaster.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlBillDbSet.Add(billMaster);
                    db.SaveChanges();

                    Insert_BillMaster_LogData(model);

                    TempData["Bill-Create"] = "Create successfully.";

                    if (command == "A4" || command == "POS")
                    {
                        TempData["BillCommand"] = command;
                        TempData["BIllReportViewModel"] = model;
                        return RedirectToAction("BillReportPage", "HotelReport");
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }

                }
            }
            else if (command == "Refresh")
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("Create");
        }








        // GET: /Bill/
        public ActionResult Update()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        [ActionName("Update")]
        public ActionResult UpdatePost(HML_BillDTO model, string command)
        {
            if (command == "Save" || command == "A4" || command == "POS")
            {
                var checkBillMaster = (from n in db.HmlBillDbSet
                                       where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                       select n).ToList();
                if (checkBillMaster.Count == 1)
                {
                    foreach (var item in checkBillMaster)
                    {
                        item.ROOMNO = model.ROOMNO;
                        item.TOTAMT = model.TOTAMT;
                        item.SCHARGE = model.SCHARGE;
                        item.VATAMT = model.VATAMT;
                        item.GROSSAMT = model.GROSSAMT;
                        item.ADVAMT = model.ADVAMT;
                        item.DISCOUNT = model.DISCOUNT;
                        item.NETAMT = model.NETAMT;
                        item.PAIDAMT = model.PAIDAMT;
                        item.BALAMT = model.BALAMT;
                        if (model.BALAMT > 0)
                        {
                            item.DUEHID = model.DUEHID;
                        }
                        else
                        {
                            item.DUEHID = null;
                        }
                        item.REMARKS = model.REMARKS_TotalBill;

                        item.USERPC = strHostName;
                        item.UPDIPNO = ipAddress.ToString();
                        item.UPDTIME = Convert.ToDateTime(td);
                        item.UPDUSERID = model.INSUSERID;
                        item.UPDLTUDE = Convert.ToString(model.INSLTUDE);

                    }
                    db.SaveChanges();

                    String crudOperation = "UPDATE";
                    Update_BillMaster_LogData(model, crudOperation);
                }
                else // if (checkPharmacyMaster.Count == 0)
                {
                    HML_BILL billMaster = new HML_BILL();
                    billMaster.COMPID = model.COMPID;
                    billMaster.TRANSDT = Convert.ToDateTime(model.TRANSDT);
                    billMaster.TRANSMY = model.TRANSMY;
                    billMaster.TRANSNO = model.TRANSNO;
                    billMaster.ROOMNO = model.ROOMNO;
                    billMaster.REGNID = model.REGNID;

                    billMaster.TOTAMT = model.TOTAMT;
                    billMaster.SCHARGE = model.SCHARGE;
                    billMaster.VATAMT = model.VATAMT;
                    billMaster.GROSSAMT = model.GROSSAMT;
                    billMaster.ADVAMT = model.ADVAMT;
                    billMaster.DISCOUNT = model.DISCOUNT;
                    billMaster.NETAMT = model.NETAMT;
                    billMaster.PAIDAMT = model.PAIDAMT;
                    billMaster.BALAMT = model.BALAMT;
                    if (billMaster.BALAMT > 0)
                    {
                        billMaster.DUEHID = model.DUEHID;
                    }
                    billMaster.REMARKS = model.REMARKS_TotalBill;

                    billMaster.USERPC = strHostName;
                    billMaster.INSIPNO = ipAddress.ToString();
                    billMaster.INSTIME = Convert.ToDateTime(td);
                    billMaster.INSUSERID = model.INSUSERID;
                    billMaster.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlBillDbSet.Add(billMaster);
                    db.SaveChanges();

                    String crudOperation = "CREATE";
                    Update_BillMaster_LogData(model, crudOperation);

                }
                TempData["Bill-Update"] = "Update successfully.";

                if (command == "A4" || command == "POS")
                {
                    TempData["BillCommand"] = command;
                    TempData["BIllReportViewModel"] = model;
                    return RedirectToAction("BillReportPage", "HotelReport");
                }
                else
                {
                    return RedirectToAction("Update");
                }
            }
            else if (command == "Refresh")
            {
                return RedirectToAction("Update");
            }
            return RedirectToAction("Update");
        }








        // GET: /Bill/
        public ActionResult Delete()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        [ActionName("Delete")]
        public ActionResult DeletePost(HML_BillDTO model, string command)
        {
            if (command == "Delete")
            {
                var findBillDetailsDataNull = (from n in db.HmlBillDetailsDbSet
                                               where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                               select n).OrderBy(e => e.BILLID).ToList();
                if (findBillDetailsDataNull.Count != 0)
                {
                    foreach (var item in findBillDetailsDataNull)
                    {
                        db.HmlBillDetailsDbSet.Remove(item);
                        db.SaveChanges();

                        var find_BillID = (from m in db.HmlBillHpDbSet where m.COMPID == model.COMPID && m.BILLID==item.BILLID select new { m.BILLNM }).ToList();
                        foreach (var variable in find_BillID)
                        {
                            model.BILLNM = variable.BILLNM;
                        }
                        model.AMOUNT = item.AMOUNT;
                        model.REMARKS_BillDetails = item.REMARKS;

                        Delete_BillDetails_LogData(model);
                        Delete_BillDetails_LogDelete(model);
                    }
                }


                var findBillMasterInfo = (from n in db.HmlBillDbSet
                                          where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                          select n).ToList();
                if (findBillMasterInfo.Count != 0)
                {
                    foreach (var item in findBillMasterInfo)
                    {
                        db.HmlBillDbSet.Remove(item);
                        db.SaveChanges();
                        
                        model.TOTAMT = item.TOTAMT;
                        model.SCHARGE = item.SCHARGE;
                        model.VATAMT = item.VATAMT;
                        model.GROSSAMT = item.GROSSAMT;
                        model.ADVAMT = item.ADVAMT;
                        model.DISCOUNT = item.DISCOUNT;
                        model.NETAMT = item.NETAMT;
                        model.PAIDAMT = item.PAIDAMT;
                        model.BALAMT = item.BALAMT;
                        if (model.BALAMT>0)
                        {
                            model.DUEHID = item.DUEHID;
                        }
                        model.REMARKS_TotalBill = item.REMARKS;
                        
                        Delete_BillMaster_LogData(model);
                        Delete_BillMaster_LogDelete(model);
                    }
                }
                TempData["Bill-Delete"] = "Delete successfully.";
                return RedirectToAction("Delete");
            }
            else if (command == "Refresh")
            {
                return RedirectToAction("Delete");
            }
            return RedirectToAction("Delete");
        }







        //(Create Page)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetMonthYear_MemoNO(string changedText, string compid)
        {
            Int64 comapnyid = Convert.ToInt64(compid);

            string converttoString = Convert.ToString(changedText);
            string getYear = converttoString.Substring(9, 2);
            string getMonth = converttoString.Substring(3, 3).ToUpper();
            string monthYear = getMonth + "-" + getYear;//DEC-15 (Example)

            DateTime getDate = Convert.ToDateTime(changedText);
            string currentMonth = getDate.ToString("MM"), memoNo = "";
            var findTransNo = (from m in db.HmlBillDetailsDbSet
                               where m.COMPID == comapnyid && m.TRANSMY == monthYear
                               select m).ToList();
            if (findTransNo.Count == 0)
            {
                memoNo = getYear + currentMonth + "0001";
            }
            else
            {
                Int64 max_TransNO = Convert.ToInt64((from m in db.HmlBillDetailsDbSet where m.COMPID == comapnyid && m.TRANSMY == monthYear select m.TRANSNO).Max());
                Int64 R = Convert.ToInt64(getYear + currentMonth + "9999");
                if (max_TransNO <= R)
                {
                    memoNo = Convert.ToString(max_TransNO + 1);
                }
                else
                {
                    memoNo = "Not access!!!";
                }
            }

            var result = new { TRANSMY = monthYear, TRANSNO = memoNo };
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RoomNoLoad(string theDate, string companyid)
        {
            Int64 comid = Convert.ToInt64(companyid);
            DateTime dt = Convert.ToDateTime(theDate);

            String year = dt.ToString("yyyy");
            Int64 reserveYear = Convert.ToInt64(year);

            List<SelectListItem> registrationList = new List<SelectListItem>();
            var list = (from m in db.HmlRegistrationDbSet
                        where m.COMPID == comid && m.CHECKI <= dt && dt <= m.GHECKO && m.ROOMNOL == null
                        select new
                        {
                            m.ROOMNO,
                            m.COMPID,
                            m.CHECKI,
                            m.GHECKO
                        }
                        ).ToList();



            if (list.Count != 0)
            {
                foreach (var f in list)
                {

                    var findBillDetails_RoomNo_existsORNot = (from m in db.HmlBillDetailsDbSet
                                                              where m.COMPID == f.COMPID && f.CHECKI <= m.TRANSDT && m.TRANSDT <= f.GHECKO &&
                                                                  m.ROOMNO == f.ROOMNO
                                                              select new {m.ROOMNO}).ToList();
                    if (findBillDetails_RoomNo_existsORNot.Count == 0)
                    {
                        registrationList.Add(new SelectListItem { Text = f.ROOMNO.ToString(), Value = f.ROOMNO.ToString() });
                    }
                }
            }
            else
            {
                registrationList.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(registrationList, "Value", "Text"));
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_roomID(String changedText, String compid, String transDate)
        {
            var companyID = Convert.ToInt16(compid);
            Int64 roomNo = Convert.ToInt64(changedText);
            DateTime transactionDate = Convert.ToDateTime(transDate);


            String regnid = "";
            var getData = (from m in db.HmlRegistrationDbSet
                           where m.COMPID == companyID && m.CHECKI <= transactionDate && transactionDate <= m.GHECKO && m.ROOMNO == roomNo
                           select new { m.REGNID }).ToList();
            foreach (var get in getData)
            {
                regnid = get.REGNID.ToString();
            }



            var result = new
            {
                REGNID = regnid,
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult keyword_roomID_UD(String changedText, String compid, String transDate, String monthYear)
        {
            var companyID = Convert.ToInt16(compid);
            Int64 roomNo = Convert.ToInt64(changedText);
            DateTime transactionDate = Convert.ToDateTime(transDate);


            String regnid = "", memoNo = "";
            var getData = (from m in db.HmlBillDetailsDbSet
                           where m.COMPID == companyID && m.TRANSDT == transactionDate && m.TRANSMY == monthYear && m.ROOMNO == roomNo
                           select new { m.REGNID, m.TRANSNO }).ToList();
            foreach (var get in getData)
            {
                regnid = get.REGNID.ToString();
                memoNo = get.TRANSNO.ToString();
                break;
            }



            var result = new
            {
                REGNID = regnid,
                TRANSNO = memoNo,
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RoomNoLoad_UD(string theDate, string companyid)
        {
            Int64 comid = Convert.ToInt64(companyid);
            DateTime dt = Convert.ToDateTime(theDate);
            
            List<SelectListItem> registrationList = new List<SelectListItem>();
            var list = (from m in db.HmlBillDetailsDbSet where m.COMPID == comid && m.TRANSDT == dt select new
                        {
                            m.ROOMNO,
                        }
                        ).Distinct().ToList();



            if (list.Count != 0)
            {
                foreach (var f in list)
                {
                    registrationList.Add(new SelectListItem { Text = f.ROOMNO.ToString(), Value = f.ROOMNO.ToString() });
                }
            }
            else
            {
                registrationList.Add(new SelectListItem { Text = null, Value = null });
            }
            return Json(new SelectList(registrationList, "Value", "Text"));
        }





        //(Update Page)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetMonthYear(string changedText)
        {
            string getYear = changedText.Substring(9, 2);
            string getMonth = changedText.Substring(3, 3).ToUpper();
            string monthYear = getMonth + "-" + getYear;//DEC-15 (Example)

            var result = new { TRANSMY = monthYear };
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        //(Update Page)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetPaymentInfo(Int64 companyid, Int64 transNo, String transMonthYear, Int64 registrationID)
        {
            var findPaymentInfo = db.HmlBillDbSet.Where(n => n.COMPID == companyid && n.TRANSNO == transNo && n.TRANSMY == transMonthYear).Select(n => new
            {
                n.TOTAMT,
                n.SCHARGE,
                n.VATAMT,
                n.GROSSAMT,
                n.ADVAMT,
                n.DISCOUNT,
                n.NETAMT,
                n.PAIDAMT,
                n.BALAMT,
                n.DUEHID,
                n.REMARKS
            }).ToList();

            string totalAmount = "", scharge = "", vatAmount = "", grossAmt = "", advanceAmount = "", Discount = "", NetAmount = "", paidamount = "", balance = "",duehid="", remarks = "";
            if (findPaymentInfo.Count == 1)
            {
                foreach (var a in findPaymentInfo)
                {
                    totalAmount = Convert.ToString(a.TOTAMT);
                    scharge = Convert.ToString(a.SCHARGE);
                    vatAmount = Convert.ToString(a.VATAMT);
                    grossAmt = Convert.ToString(a.GROSSAMT);
                    advanceAmount = Convert.ToString(a.ADVAMT);
                    Discount = Convert.ToString(a.DISCOUNT);
                    NetAmount = Convert.ToString(a.NETAMT);
                    paidamount = Convert.ToString(a.PAIDAMT);
                    balance = Convert.ToString(a.BALAMT);
                    if (a.DUEHID != null)
                    {
                        duehid = Convert.ToString(a.DUEHID);
                    }
                    if (a.REMARKS != null)
                    {
                        remarks = a.REMARKS;
                    }
                    else
                    {
                        remarks = "";
                    }

                }
            }
            else
            {
                var findChildData = db.HmlBillDetailsDbSet.Where(n => n.COMPID == companyid && n.TRANSNO == transNo && n.TRANSMY == transMonthYear).Select(n => new
                {
                    n.AMOUNT,
                }).ToList();
                Decimal amount = 0;
                foreach (var b in findChildData)
                {
                    amount += Convert.ToDecimal(b.AMOUNT);
                }
                totalAmount = Convert.ToString(amount);
                vatAmount = Convert.ToString(0);
                scharge = Convert.ToString(0);
                grossAmt = Convert.ToString(amount);
                Discount = Convert.ToString(0);
                NetAmount = Convert.ToString(amount);
                paidamount = Convert.ToString(0);
                balance = Convert.ToString(amount);

                Decimal advAmount = 0;
                var find_AdvanceAmount = (from m in db.HmlRegistrationPaymentDbSet
                                          where m.COMPID == companyid && m.TRFOR == "ADVANCE" && m.REGNID == registrationID && m.AMOUNT != null
                                          select new { m.AMOUNT }).ToList();
                if (find_AdvanceAmount.Count != 0)
                {
                    foreach (var get in find_AdvanceAmount)
                    {
                        advAmount += Convert.ToDecimal(get.AMOUNT);
                    }
                }
                advanceAmount = Convert.ToString(advAmount);

            }

            var result = new { TOTAMT = totalAmount, SCHARGE = scharge, VATAMT = vatAmount, GROSSAMT = grossAmt, ADVAMT = advanceAmount, DISCOUNT = Discount, NETAMT = NetAmount, PAIDAMT = paidamount, BALAMT = balance, DUEHID = duehid, REMARKS = remarks };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }




    }
}
