using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AS_CLOUD_HOTEL.Controllers.Hotel;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Api
{
    public class ApiBillController : ApiController
    {
        CLoudHotelDbContext db = new CLoudHotelDbContext();

        //Datetime formet
        IFormatProvider dateformat = new System.Globalization.CultureInfo("fr-FR", true);
        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Asia Standard Time");
        public DateTime td;

        //Get Ip ADDRESS,Time & user PC Name
        public string strHostName;
        public IPHostEntry ipHostInfo;
        public IPAddress ipAddress;

        public ApiBillController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }


        //Grid level data
        [System.Web.Http.HttpGet]
        public IEnumerable<HML_BillDTO> GetItemList(string cid, string myear, string memoNo)
        {
            Int64 compid = Convert.ToInt64(cid);
            string monthYear = Convert.ToString(myear);
            Int64 transNo = Convert.ToInt64(memoNo);

            var findGridData = (from billDetails in db.HmlBillDetailsDbSet
                                join billname in db.HmlBillHpDbSet on billDetails.COMPID equals billname.COMPID
                                where billDetails.COMPID == compid && billDetails.TRANSMY == monthYear && billDetails.TRANSNO == transNo && billDetails.BILLID == billname.BILLID
                                select new
                                {
                                    billDetails.ID,
                                    billDetails.COMPID,
                                    billDetails.TRANSDT,
                                    billDetails.TRANSMY,
                                    billDetails.TRANSNO,

                                    billDetails.ROOMNO,
                                    billDetails.REGNID,
                                    billDetails.BILLID,
                                    billname.BILLNM,
                                    billDetails.AMOUNT,
                                    billDetails.REMARKS,

                                    billDetails.INSIPNO,
                                    billDetails.INSLTUDE,
                                    billDetails.INSTIME,
                                    billDetails.INSUSERID,
                                }).OrderBy(e => e.ID).ToList();

            if (findGridData.Count == 0)
            {
                yield return new HML_BillDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in findGridData)
                {
                    yield return new HML_BillDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        TRANSMY = s.TRANSMY,
                        TRANSNO = Convert.ToInt64(s.TRANSNO),

                        ROOMNO = Convert.ToInt64(s.ROOMNO),
                        REGNID = Convert.ToInt64(s.REGNID),
                        BILLID = Convert.ToInt64(s.BILLID),
                        BILLNM = Convert.ToString(s.BILLNM),
                        AMOUNT = Convert.ToDecimal(s.AMOUNT),
                        REMARKS_BillDetails = s.REMARKS,

                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }



        [HttpGet]
        public IEnumerable<HML_BillDTO> AddChildData(string Compid, string insertUserID, string insltude, string transMonthyear, string transDate, string transno, string roomNo, string registrationID)
        {

            HML_BillDTO model = new HML_BillDTO();
            model.COMPID = Convert.ToInt64(Compid);
            model.INSUSERID = Convert.ToInt64(insertUserID);
            model.INSLTUDE = Convert.ToString(insltude);
            model.TRANSMY = Convert.ToString(transMonthyear);
            model.TRANSDT = Convert.ToString(transDate);
            model.TRANSNO = Convert.ToInt64(transno);
            model.ROOMNO = Convert.ToInt64(roomNo);
            model.REGNID = Convert.ToInt64(registrationID);
            Int64 memoNumber = 0;
            String transactionDate = "";

            var checkBillDetailsData = (from m in db.HmlBillDetailsDbSet
                                        where m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY && m.REGNID == model.REGNID
                                        select m).ToList();
            if (checkBillDetailsData.Count != 0)
            {
                foreach (var getData in checkBillDetailsData)
                {
                    model.TRANSNO = Convert.ToInt64(getData.TRANSNO);
                    DateTime date = Convert.ToDateTime(getData.TRANSDT);
                    model.TRANSDT = date.ToString("dd-MMM-yyyy");
                    break;
                }
            }



            var checkMemoNo = (from n in db.HmlBillDetailsDbSet
                               where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO && n.INSUSERID == model.INSUSERID
                               select new { n.TRANSNO }).ToList();

            if (checkMemoNo.Count == 0 && checkBillDetailsData.Count == 0)
            {
                string memoNo = "", currentMonth = "", getYear = "";
                string date = Convert.ToString(model.TRANSDT);
                DateTime MyDateTime = DateTime.Parse(date);
                currentMonth = MyDateTime.ToString("MM");
                getYear = MyDateTime.ToString("yy");

                var findTransNo = (from m in db.HmlBillDetailsDbSet
                                   where m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY
                                   select m).ToList();

                if (findTransNo.Count == 0)
                {
                    memoNo = getYear + currentMonth + "0001";
                }
                else
                {
                    Int64 max_TransNO =
                        Convert.ToInt64(
                            (from m in db.HmlBillDetailsDbSet
                             where m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY
                             select m.TRANSNO).Max());
                    Int64 R = Convert.ToInt64(getYear + currentMonth + "9999");
                    if (max_TransNO <= R)
                    {
                        memoNo = Convert.ToString(max_TransNO + 1);
                    }
                    else
                    {
                        memoNo = "0";
                    }
                }
                model.TRANSNO = Convert.ToInt64(memoNo);
            }


            //Bill Transer attribute
            Int64 roomNol = 0, regidl = 0;


            // Bill Details Entry
            Int64 count = 0;
            String BillID = Convert.ToString(Compid + "01");

            var findRoomRents_Day = (from n in db.HmlRegistrationDbSet
                                     where n.COMPID == model.COMPID && n.ROOMNO == model.ROOMNO && n.REGNID == model.REGNID
                                     select n).ToList();
            if (checkBillDetailsData.Count == 0)
            {
                foreach (var get in findRoomRents_Day)
                {
                    DateTime d1 = Convert.ToDateTime(get.CHECKI);
                    DateTime d2 = Convert.ToDateTime(get.GHECKO);

                    TimeSpan t = d2 - d1;
                    Decimal NrOfDays = Convert.ToDecimal(t.TotalDays);
                    if (NrOfDays < 1)
                    {
                        NrOfDays = 1;
                    }
                    Decimal rent_days = Convert.ToDecimal(get.ROOMRTS * NrOfDays);


                    // From Bill Transfer Entry
                    var findBillTransfer_RoomRents_Day = (from n in db.HmlRegistrationDbSet
                                                          where n.COMPID == model.COMPID && n.ROOMNOL == model.ROOMNO && n.REGNIDL == model.REGNID
                                                          select n).ToList();
                    foreach (var get2 in findBillTransfer_RoomRents_Day)
                    {
                        DateTime date1_get2 = Convert.ToDateTime(get2.CHECKI);
                        DateTime date2_get2 = Convert.ToDateTime(get2.GHECKO);

                        TimeSpan t2 = date2_get2 - date1_get2;
                        Decimal NrOfDays_2 = Convert.ToDecimal(t2.TotalDays);
                        if (NrOfDays_2 < 1)
                        {
                            NrOfDays_2 = 1;
                        }
                        rent_days += Convert.ToDecimal(get2.ROOMRTS * NrOfDays_2);

                    }



                    HML_BILLDTL billDetails_RoomRent = new HML_BILLDTL();
                    billDetails_RoomRent.COMPID = model.COMPID;
                    billDetails_RoomRent.TRANSDT = Convert.ToDateTime(model.TRANSDT);
                    billDetails_RoomRent.TRANSMY = model.TRANSMY;
                    billDetails_RoomRent.TRANSNO = model.TRANSNO;
                    billDetails_RoomRent.ROOMNO = model.ROOMNO;
                    billDetails_RoomRent.REGNID = model.REGNID;
                    billDetails_RoomRent.BILLID = Convert.ToInt64(BillID);
                    billDetails_RoomRent.AMOUNT = rent_days;
                    billDetails_RoomRent.REMARKS = get.REMARKS;

                    billDetails_RoomRent.USERPC = strHostName;
                    billDetails_RoomRent.INSIPNO = ipAddress.ToString();
                    billDetails_RoomRent.INSTIME = Convert.ToDateTime(td);
                    billDetails_RoomRent.INSUSERID = model.INSUSERID;
                    billDetails_RoomRent.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlBillDetailsDbSet.Add(billDetails_RoomRent);
                    db.SaveChanges();
                    count++;

                    break;
                }
            }



            var checkServiceData = (from n in db.HmlServicesDbSet
                                    where n.COMPID == model.COMPID && n.ROOMNO == model.ROOMNO && n.REGNID == model.REGNID
                                    select n).ToList();
            if (checkServiceData.Count != 0)
            {
                foreach (var data in checkServiceData)
                {
                    var findBillDetails = (from m in db.HmlBillDetailsDbSet
                                           where m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY && m.TRANSNO == model.TRANSNO && m.BILLID == data.BILLID
                                           select m).ToList();
                    if (findBillDetails.Count != 0)
                    {
                        foreach (var getBillDetailsData in findBillDetails)
                        {
                            getBillDetailsData.AMOUNT = data.AMOUNT + getBillDetailsData.AMOUNT;
                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        HML_BILLDTL billDetails = new HML_BILLDTL();
                        billDetails.COMPID = model.COMPID;
                        billDetails.TRANSDT = Convert.ToDateTime(model.TRANSDT);
                        billDetails.TRANSMY = model.TRANSMY;
                        billDetails.TRANSNO = model.TRANSNO;
                        billDetails.ROOMNO = model.ROOMNO;
                        billDetails.REGNID = model.REGNID;
                        billDetails.BILLID = data.BILLID;
                        billDetails.AMOUNT = data.AMOUNT;
                        billDetails.REMARKS = data.REMARKS;

                        billDetails.USERPC = strHostName;
                        billDetails.INSIPNO = ipAddress.ToString();
                        billDetails.INSTIME = Convert.ToDateTime(td);
                        billDetails.INSUSERID = model.INSUSERID;
                        billDetails.INSLTUDE = Convert.ToString(model.INSLTUDE);
                        db.HmlBillDetailsDbSet.Add(billDetails);
                        db.SaveChanges();
                        count++;
                    }

                   
                }
            }


            // From Bill Transfer Entry

            var findBillTransfer_Data = (from n in db.HmlRegistrationDbSet
                                         where n.COMPID == model.COMPID && n.ROOMNOL == model.ROOMNO && n.REGNIDL == model.REGNID
                                         select n).ToList();
            if (findBillTransfer_Data.Count != 0)
            {
                foreach (var fromBillTransfer in findBillTransfer_Data)
                {
                    var findBillTransfer_checkServiceData = (from n in db.HmlServicesDbSet
                                                             where n.COMPID == model.COMPID && n.ROOMNO == fromBillTransfer.ROOMNO &&
                                                                 n.REGNID == fromBillTransfer.REGNID
                                                             select n).ToList();
                    foreach (var billTransfer_data in findBillTransfer_checkServiceData)
                    {
                        Decimal amount = 0;

                        var findBillDetails = (from m in db.HmlBillDetailsDbSet
                                               where m.COMPID == model.COMPID && m.TRANSMY == model.TRANSMY && m.TRANSNO == model.TRANSNO && m.BILLID == billTransfer_data.BILLID
                                               select m).ToList();
                        if (findBillDetails.Count == 1)
                        {
                            foreach (var orginaldata in findBillDetails)
                            {
                                amount = Convert.ToDecimal(billTransfer_data.AMOUNT + orginaldata.AMOUNT);
                                orginaldata.AMOUNT = amount;
                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            amount = Convert.ToDecimal(billTransfer_data.AMOUNT);

                            HML_BILLDTL billDetails_billTransfer = new HML_BILLDTL();
                            billDetails_billTransfer.COMPID = model.COMPID;
                            billDetails_billTransfer.TRANSDT = Convert.ToDateTime(model.TRANSDT);
                            billDetails_billTransfer.TRANSMY = model.TRANSMY;
                            billDetails_billTransfer.TRANSNO = model.TRANSNO;
                            billDetails_billTransfer.ROOMNO = model.ROOMNO;
                            billDetails_billTransfer.REGNID = model.REGNID;
                            billDetails_billTransfer.BILLID = billTransfer_data.BILLID;
                            billDetails_billTransfer.AMOUNT = amount;
                            billDetails_billTransfer.REMARKS = billTransfer_data.REMARKS;

                            billDetails_billTransfer.USERPC = strHostName;
                            billDetails_billTransfer.INSIPNO = ipAddress.ToString();
                            billDetails_billTransfer.INSTIME = Convert.ToDateTime(td);
                            billDetails_billTransfer.INSUSERID = model.INSUSERID;
                            billDetails_billTransfer.INSLTUDE = Convert.ToString(model.INSLTUDE);

                            db.HmlBillDetailsDbSet.Add(billDetails_billTransfer);
                            db.SaveChanges();
                            count++;
                        }

                    }
                }
            }



            //Log data save from Bill details Tabel
            model.count = count;
            BillController controller = new BillController();
            controller.Insert_BillDetails_LogData_Submit(model);


            //Advanced amount - Current RoomNo and Registration ID
            Decimal advanceAmount = 0;
            var find_AdvanceAmount_RegistrationPayment = (from m in db.HmlRegistrationPaymentDbSet
                                      where m.COMPID == model.COMPID && m.TRFOR == "ADVANCE" && m.REGNID == model.REGNID && (m.AMOUNT != null || m.AMOUNT != 0)
                                      select new { m.AMOUNT }).ToList();
            if (find_AdvanceAmount_RegistrationPayment.Count != 0)
            {
                foreach (var get in find_AdvanceAmount_RegistrationPayment)
                {
                    advanceAmount += Convert.ToDecimal(get.AMOUNT);
                }
            }

            Int64 reservID = 0;
            var findReservationID = (from n in db.HmlRegistrationDbSet
                                     where n.COMPID == model.COMPID && n.ROOMNO == model.ROOMNO && n.REGNID == model.REGNID
                                     select new {n.RESVID}).ToList();
            if (findReservationID.Count == 1)
            {
                foreach (var reservation in findReservationID)
                {
                    reservID = Convert.ToInt64(reservation.RESVID);
                }
            }

            var find_AdvanceAmount_ReservationPayment = (from m in db.HmlReservePayDbSet
                                                          where m.COMPID == model.COMPID  && m.RESVID == reservID && (m.AMOUNT != null || m.AMOUNT != 0)
                                                         select new { m.AMOUNT }).ToList();
            if (find_AdvanceAmount_ReservationPayment.Count != 0)
            {
                foreach (var get in find_AdvanceAmount_ReservationPayment)
                {
                    advanceAmount += Convert.ToDecimal(get.AMOUNT);
                }
            }




            //Advanced amount - Bill Transfer RoomNo and Registration ID
            var findBillTransfer_RegistrationPayment = (from n in db.HmlRegistrationDbSet
                                         where n.COMPID == model.COMPID && n.ROOMNOL == model.ROOMNO && n.REGNIDL == model.REGNID
                                         select n).ToList();
            if (findBillTransfer_RegistrationPayment.Count != 0)
            {
                foreach (var fromBillTransfer in findBillTransfer_RegistrationPayment)
                {
                    var find_AdvanceAmount_BillTransfer = (from m in db.HmlRegistrationPaymentDbSet
                                                                  where m.COMPID == model.COMPID && m.TRFOR == "ADVANCE" && m.REGNID == fromBillTransfer.REGNID && (m.AMOUNT != null || m.AMOUNT != 0)
                                                                  select new { m.AMOUNT }).ToList();
                    if (find_AdvanceAmount_BillTransfer.Count != 0)
                    {
                        foreach (var get in find_AdvanceAmount_BillTransfer)
                        {
                            advanceAmount += Convert.ToDecimal(get.AMOUNT);
                        }
                    }


                    Int64 reservID_billTransfer = 0;
                    var findReservationID2 = (from n in db.HmlRegistrationDbSet
                                             where n.COMPID == model.COMPID && n.ROOMNO == fromBillTransfer.ROOMNO && n.REGNID == fromBillTransfer.REGNID
                                             select new { n.RESVID }).ToList();
                    if (findReservationID2.Count == 1)
                    {
                        foreach (var reservation in findReservationID2)
                        {
                            reservID_billTransfer = Convert.ToInt64(reservation.RESVID);
                        }
                    }

                    var find_AdvanceAmount_ReservationPayment_BillTransfer = (from m in db.HmlReservePayDbSet
                                                                 where m.COMPID == model.COMPID && m.RESVID == reservID_billTransfer && (m.AMOUNT != null || m.AMOUNT != 0)
                                                                 select new { m.AMOUNT }).ToList();
                    if (find_AdvanceAmount_ReservationPayment_BillTransfer.Count != 0)
                    {
                        foreach (var get in find_AdvanceAmount_ReservationPayment_BillTransfer)
                        {
                            advanceAmount += Convert.ToDecimal(get.AMOUNT);
                        }
                    }

                }
            }


            memoNumber = Convert.ToInt64(model.TRANSNO);
            DateTime x = Convert.ToDateTime(model.TRANSDT);
            transactionDate = x.ToString("dd-MMM-yyyy");

            yield return new HML_BillDTO
            {
                TRANSNO = memoNumber,
                TRANSDT = transactionDate,
                ADVAMT = advanceAmount
            };
        }







        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Addrow(HML_BillDTO model)
        {
            HML_BILLDTL billDetails = new HML_BILLDTL();

            var checkData = (from n in db.HmlBillDetailsDbSet
                             where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO && n.BILLID == model.BILLID
                             select n).ToList();

            if (checkData.Count == 0)
            {
                billDetails.COMPID = model.COMPID;
                billDetails.TRANSDT = Convert.ToDateTime(model.TRANSDT);
                billDetails.TRANSMY = model.TRANSMY;
                billDetails.TRANSNO = model.TRANSNO;
                billDetails.ROOMNO = model.ROOMNO;
                billDetails.REGNID = model.REGNID;
                billDetails.BILLID = Convert.ToInt64(model.BILLID);
                billDetails.AMOUNT = model.AMOUNT;
                billDetails.REMARKS = model.REMARKS_BillDetails;

                billDetails.USERPC = strHostName;
                billDetails.INSIPNO = ipAddress.ToString();
                billDetails.INSTIME = Convert.ToDateTime(td);
                billDetails.INSUSERID = model.INSUSERID;
                billDetails.INSLTUDE = Convert.ToString(model.INSLTUDE);

                db.HmlBillDetailsDbSet.Add(billDetails);
                db.SaveChanges();

                //Log data save from Bill details Tabel
                BillController controller = new BillController();
                controller.Insert_BillDetails_LogData(model);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
            else
            {
                model.BILLID = 0;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
        }







        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage UpdateData(HML_BillDTO model)
        {
            var check_data = (from n in db.HmlBillDetailsDbSet
                              where n.ID == model.ID && n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY
                                  && n.TRANSNO == model.TRANSNO && n.BILLID == model.BILLID
                              select n).ToList();
            if (check_data.Count == 1)
            {
                foreach (var item in check_data)
                {
                    item.AMOUNT = model.AMOUNT;
                    item.REMARKS = model.REMARKS_BillDetails;

                    item.USERPC = strHostName;
                    item.UPDIPNO = ipAddress.ToString();
                    item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                    item.UPDTIME = Convert.ToDateTime(td);
                    item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

                }
                db.SaveChanges();

                //Log data save from Pharmacy Tabel
                BillController controller = new BillController();
                controller.update_BillDetails_LogData(model);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
            else
            {
                model.BILLID = 0;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
        }












        [HttpPost]
        public HttpResponseMessage DeleteData(HML_BillDTO model)
        {
            HML_BILLDTL deleteModel = new HML_BILLDTL();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.TRANSMY = Convert.ToString(model.TRANSMY);
            deleteModel.TRANSNO = model.TRANSNO;
            deleteModel.BILLID = Convert.ToInt64(model.BILLID);

            deleteModel = db.HmlBillDetailsDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.TRANSMY, deleteModel.TRANSNO, deleteModel.BILLID);
            db.HmlBillDetailsDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from Bill Details Tabel
            BillController controller = new BillController();
            controller.Delete_BillDetails_LogData(model);
            controller.Delete_BillDetails_LogDelete(model);

            //Update Page if Master data exists
            var findBillDetailsDataNull = (from n in db.HmlBillDetailsDbSet
                                           where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                           select n).ToList();
            var findBillMasterInfo = (from n in db.HmlBillDbSet
                                      where n.COMPID == model.COMPID && n.TRANSMY == model.TRANSMY && n.TRANSNO == model.TRANSNO
                                      select n).ToList();
            if (findBillDetailsDataNull.Count == 0 && findBillMasterInfo.Count == 1)
            {
                foreach (var a in findBillMasterInfo)
                {
                    db.HmlBillDbSet.Remove(a);
                    db.SaveChanges();
                    //Log data delete from Bill Details(Cart-Payment Info) Tabel
                    controller.Delete_BillMaster_LogData(model);
                    controller.Delete_BillMaster_LogDelete(model);
                }
            }
            HML_BillDTO obj = new HML_BillDTO();
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }
    }
}
