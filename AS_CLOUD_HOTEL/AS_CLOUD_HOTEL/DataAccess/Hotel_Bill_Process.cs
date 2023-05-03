using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using AS_CLOUD_HOTEL.Models;

namespace AS_CLOUD_HOTEL.DataAccess
{
    public static class Hotel_Bill_Process
    {
        public static string process(PageModel model, Int64 compid)
        {

            //Datetime formet
            IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
            DateTime td;


            CLoudHotelDbContext db = new CLoudHotelDbContext();
            //Get Ip ADDRESS,Time & user PC Name
            string strHostName;
            IPHostEntry ipHostInfo;
            IPAddress ipAddress;

            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);

            string date = Convert.ToString(model.AGlMaster.TRANSDT);
            DateTime MyDateTime = DateTime.Parse(date);
            string converttoString = MyDateTime.ToString("dd-MMM-yyyy");
            string getYear = converttoString.Substring(9, 2);
            string getMonth = converttoString.Substring(3, 3);
            string Month_Year = getMonth + "-" + getYear;


            Int64 countProcess = 0;

            //HML_BILL
            var forRemovedata_HML_BILL = (from l in db.GlMasterDbSet
                                 where l.COMPID == compid && l.TRANSDT == model.AGlMaster.TRANSDT
                                 select l).ToList();
            foreach (var VARIABLE in forRemovedata_HML_BILL)
            {
                if (VARIABLE.TABLEID == "HML_BILL" && VARIABLE.TRANSDT == model.AGlMaster.TRANSDT)
                {
                    db.GlMasterDbSet.Remove(VARIABLE);
                }
            }
            db.SaveChanges();

            //HML_BILLDTL
            var forRemovedata_HML_BILLDTL = (from l in db.GlMasterDbSet
                                          where l.COMPID == compid && l.TRANSDT == model.AGlMaster.TRANSDT
                                          select l).ToList();
            foreach (var VARIABLE in forRemovedata_HML_BILLDTL)
            {
                if (VARIABLE.TABLEID == "HML_BILLDTL" && VARIABLE.TRANSDT == model.AGlMaster.TRANSDT)
                {
                    db.GlMasterDbSet.Remove(VARIABLE);
                }
            }
            db.SaveChanges();


            //GL Process for HML_BILLDTL Room Rent
            Int64 billid = Convert.ToInt64(compid + "01");
            var checkDate_HML_BILLDTL_RoomRent = (from n in db.HmlBillDetailsDbSet from m in db.HmlBillHpDbSet
                                      where n.COMPID == compid&& n.COMPID==m.COMPID && n.TRANSDT == model.AGlMaster.TRANSDT &&
                                      (m.BILLNM == "Room Rent" || m.BILLID== billid)  && m.BILLID==n.BILLID && n.AMOUNT > 0
                                         select n).OrderBy(x => x.TRANSNO).ToList();

            if (checkDate_HML_BILLDTL_RoomRent.Count != 0)
            {
                Int64 max_Sale = 210000;
                foreach (var get in checkDate_HML_BILLDTL_RoomRent)
                {
                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.tra;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1040001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "3010001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Room Rent-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);
                    model.AGlMaster.TRANSDRCR = "DEBIT";
                    model.AGlMaster.TABLEID = "HML_BILLDTL";

                    model.AGlMaster.DEBITAMT = get.AMOUNT;
                    model.AGlMaster.CREDITAMT = 0;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();



                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.TRANSFOR;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "3010001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1040001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Room Rent-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);

                    model.AGlMaster.TRANSDRCR = "CREDIT";
                    model.AGlMaster.TABLEID = "HML_BILLDTL";

                    model.AGlMaster.DEBITAMT = 0;
                    model.AGlMaster.CREDITAMT = get.AMOUNT;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();
                }
                countProcess++;
            }



            //GL Process for HML_BILL - SERVICE AMOUNT
            var checkDate_HML_BILL_Service = (from n in db.HmlBillDbSet
                                                 where n.COMPID == compid && n.TRANSDT == model.AGlMaster.TRANSDT && n.SCHARGE > 0
                                                 select new { n.COMPID, n.TRANSDT, n.TRANSNO, n.SCHARGE, n.ROOMNO, n.REGNID, n.REMARKS }).OrderBy(x => x.TRANSNO).ToList();

            if (checkDate_HML_BILL_Service.Count != 0)
            {
                Int64 max_Sale = 220000;
                foreach (var get in checkDate_HML_BILL_Service)
                {
                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.tra;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1040001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "3010001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Service-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);
                    model.AGlMaster.TRANSDRCR = "DEBIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = get.SCHARGE;
                    model.AGlMaster.CREDITAMT = 0;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();



                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.TRANSFOR;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "3010001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1040001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Service-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);

                    model.AGlMaster.TRANSDRCR = "CREDIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = 0;
                    model.AGlMaster.CREDITAMT = get.SCHARGE;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();
                }
                countProcess++;
            }




            //GL Process for HML_BILL - VAT AMOUNT
            var checkDate_HML_BILL_Vat = (from n in db.HmlBillDbSet
                                              where n.COMPID == compid && n.TRANSDT == model.AGlMaster.TRANSDT && n.VATAMT > 0
                                              select new { n.COMPID, n.TRANSDT, n.TRANSNO, n.VATAMT, n.ROOMNO, n.REGNID, n.REMARKS }).OrderBy(x => x.TRANSNO).ToList();

            if (checkDate_HML_BILL_Vat.Count != 0)
            {
                Int64 max_Sale = 230000;
                foreach (var get in checkDate_HML_BILL_Vat)
                {
                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.tra;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1040001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "2070001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Vat-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);
                    model.AGlMaster.TRANSDRCR = "DEBIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = get.VATAMT;
                    model.AGlMaster.CREDITAMT = 0;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();



                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.TRANSFOR;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "2070001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1040001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Vat-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);

                    model.AGlMaster.TRANSDRCR = "CREDIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = 0;
                    model.AGlMaster.CREDITAMT = get.VATAMT;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();
                }
                countProcess++;
            }



            //GL Process for HML_BILL - DISCOUNT AMOUNT
            var checkDate_HML_BILL_Discount = (from n in db.HmlBillDbSet
                                          where n.COMPID == compid && n.TRANSDT == model.AGlMaster.TRANSDT && n.DISCOUNT > 0
                                          select new { n.COMPID, n.TRANSDT, n.TRANSNO, n.DISCOUNT, n.ROOMNO, n.REGNID, n.REMARKS }).OrderBy(x => x.TRANSNO).ToList();

            if (checkDate_HML_BILL_Discount.Count != 0)
            {
                Int64 max_Sale = 240000;
                foreach (var get in checkDate_HML_BILL_Discount)
                {
                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.tra;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "4010002");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1040001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Discount-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);
                    model.AGlMaster.TRANSDRCR = "DEBIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = get.DISCOUNT;
                    model.AGlMaster.CREDITAMT = 0;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();



                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "JOUR";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.TRANSFOR;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1040001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "4010002");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Discount-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);

                    model.AGlMaster.TRANSDRCR = "CREDIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = 0;
                    model.AGlMaster.CREDITAMT = get.DISCOUNT;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();
                }
                countProcess++;
            }



            //GL Process for HML_BILL - PAID AMOUNT
            var checkDate_HML_BILL_PaidAmount = (from n in db.HmlBillDbSet
                                         where n.COMPID == compid  && n.TRANSDT == model.AGlMaster.TRANSDT && n.PAIDAMT > 0
                                         select new {n.COMPID,n.TRANSDT,n.TRANSNO,n.PAIDAMT,n.ROOMNO,n.REGNID,n.REMARKS}).OrderBy(x => x.TRANSNO).ToList();

            if (checkDate_HML_BILL_PaidAmount.Count != 0)
            {
                Int64 max_Sale = 250000;
                foreach (var get in checkDate_HML_BILL_PaidAmount)
                {
                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "MREC";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.tra;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1010001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1040001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Amount Receive-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);
                    model.AGlMaster.TRANSDRCR = "DEBIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = get.PAIDAMT;
                    model.AGlMaster.CREDITAMT = 0;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();



                    max_Sale = max_Sale + 1;
                    model.AGlMaster.TRANSSL = max_Sale;
                    model.AGlMaster.TRANSDT = get.TRANSDT;
                    model.AGlMaster.COMPID = get.COMPID;
                    model.AGlMaster.TRANSTP = "MREC";
                    model.AGlMaster.TRANSMY = Month_Year;
                    model.AGlMaster.TRANSNO = get.TRANSNO;
                    //model.AGlMaster.TRANSFOR = stk_Trans.TRANSFOR;
                    //model.AGlMaster.TRANSMODE = get.TRMODE;
                    //model.AGlMaster.COSTPID = stk_Trans.COSTPID;
                    model.AGlMaster.DEBITCD = Convert.ToInt64(compid + "1040001");
                    model.AGlMaster.CREDITCD = Convert.ToInt64(compid + "1010001");
                    //model.AGlMaster.CHEQUENO = stk_Trans.CHEQUENO;
                    //model.AGlMaster.CHEQUEDT = stk_Trans.CHEQUEDT;
                    model.AGlMaster.REMARKS = Convert.ToString("Amount Receive-Room No-" + get.ROOMNO + "-Registration id-" + get.REGNID + "-" + get.REMARKS);

                    model.AGlMaster.TRANSDRCR = "CREDIT";
                    model.AGlMaster.TABLEID = "HML_BILL";

                    model.AGlMaster.DEBITAMT = 0;
                    model.AGlMaster.CREDITAMT = get.PAIDAMT;

                    model.AGlMaster.USERPC = strHostName;
                    model.AGlMaster.INSIPNO = ipAddress.ToString();
                    model.AGlMaster.INSTIME = Convert.ToDateTime(td);
                    model.AGlMaster.INSUSERID = Convert.ToInt64(System.Web.HttpContext.Current.Session["loggedUserID"]);
                    model.AGlMaster.INSLTUDE = model.AGlMaster.INSLTUDE;

                    db.GlMasterDbSet.Add(model.AGlMaster);
                    db.SaveChanges();
                }
                countProcess++;
            }


            if (countProcess != 0)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }
    }
}