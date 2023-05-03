using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AS_CLOUD_HOTEL.Controllers.Hotel;
using AS_CLOUD_HOTEL.DataAccess;
using AS_CLOUD_HOTEL.Models;
using AS_CLOUD_HOTEL.Models.DTO;
using AS_CLOUD_HOTEL.Models.HML;

namespace AS_CLOUD_HOTEL.Controllers.Api
{
    public class ApiRoomController : ApiController
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

        public ApiRoomController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }





        //[System.Web.Http.Route("api/ApiRoomController/GetMediMasterInfo")]
        [System.Web.Http.HttpGet]
        public IEnumerable<HML_RoomTpDTO> GetRoomTypeInfo(string Compid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            var find_GridData = (from t1 in db.HmlRoomTpDbSet
                                 where t1.COMPID == compid
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.RTPID,
                                     t1.RTPNM,
                                     t1.RATEBDT,
                                     t1.RATEUSD,
                                     t1.STATUS,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.RTPNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_RoomTpDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    String rateBDT = "",rateUSD="";
                    Decimal rateBDT_D = 0, rateUSD_D = 0;
                    if (s.RATEBDT < 0)//Determine negative number
                    {
                        rateBDT_D = Convert.ToDecimal(s.RATEBDT * (-1));// make that positive
                        string convertcredit = Convert.ToString(rateBDT_D);
                        rateBDT = CommainAmount.AmountwithComma(convertcredit);
                    }
                    else
                    {
                        string convertcredit = Convert.ToString(s.RATEBDT);
                        rateBDT = CommainAmount.AmountwithComma(convertcredit);
                    }

                    if (s.RATEUSD < 0)//Determine negative number
                    {
                        rateUSD_D = Convert.ToDecimal(s.RATEUSD * (-1));// make that positive
                        string convertcredit = Convert.ToString(rateUSD_D);
                        rateUSD = CommainAmount.AmountwithComma(convertcredit);
                    }
                    else
                    {
                        string convertcredit = Convert.ToString(s.RATEUSD);
                        rateUSD = CommainAmount.AmountwithComma(convertcredit);
                    }

                    String status = "";
                    if (s.STATUS == "A")
                    {
                        status = "ACTIVE";
                    }
                    else if (s.STATUS == "I")
                    {
                        status = "INACTIVE";
                    }

                    yield return new HML_RoomTpDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        RTPID = Convert.ToInt64(s.RTPID),
                        RTPNM = s.RTPNM,
                        RATEBDT = rateBDT,
                        RATEUSD = rateUSD,
                        STATUS = status,
                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }









        //[Route("api/ApiRoomController/grid/addData")]
        [HttpPost]
        public HttpResponseMessage AddData(HML_RoomTpDTO model)
        {
            HML_ROOMTP roomType = new HML_ROOMTP();

            var check_data = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID && n.RTPNM == model.RTPNM select n).ToList();
            if (check_data.Count == 0)
            {
                var find_data = (from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID select n.RTPID).ToList();
                if (find_data.Count == 0)
                {
                    roomType.RTPID = Convert.ToInt64(Convert.ToString(model.COMPID) + "01");
                }
                else
                {
                    Int64 find_Max_RTPID = Convert.ToInt64((from n in db.HmlRoomTpDbSet where n.COMPID == model.COMPID select n.RTPID).Max());
                    roomType.RTPID = find_Max_RTPID + 1;
                }

                roomType.COMPID = model.COMPID;
                roomType.RTPNM = model.RTPNM;
                roomType.RATEBDT = Convert.ToDecimal(model.RATEBDT);
                roomType.RATEUSD = Convert.ToDecimal(model.RATEUSD);
                roomType.STATUS = model.STATUS;
                roomType.USERPC = strHostName;
                roomType.INSIPNO = ipAddress.ToString();
                roomType.INSTIME = Convert.ToDateTime(td);
                roomType.INSUSERID = model.INSUSERID;
                roomType.INSLTUDE = Convert.ToString(model.INSLTUDE);

                db.HmlRoomTpDbSet.Add(roomType);
                db.SaveChanges();

                model.ID = roomType.ID;
                model.COMPID = roomType.COMPID;
                model.RTPID = Convert.ToInt64(roomType.RTPID);
                model.RTPNM = roomType.RTPNM;
                model.RATEBDT = Convert.ToString(roomType.RATEBDT);
                model.RATEUSD = Convert.ToString(roomType.RATEUSD);
                model.STATUS = roomType.STATUS;
                model.USERPC = roomType.USERPC;
                model.INSIPNO = roomType.INSIPNO;
                model.INSTIME = roomType.INSTIME;
                model.INSUSERID = roomType.INSUSERID;
                model.INSLTUDE = Convert.ToString(roomType.INSLTUDE);

                //Log data save from HML_ROOMTP Tabel
                RoomController roomController = new RoomController();
                roomController.Insert_HML_ROOMTP_LogData(model);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
            else
            {
                model.RTPID = 0;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
                return response;
            }
        }






        //[Route("api/ApiRoomController/grid/UpdateData")]
        [HttpPost]
        public HttpResponseMessage UpdateData(HML_RoomTpDTO model)
        {
            string status = "";
            if (model.STATUS == "ACTIVE")
            {
                status = "A";
            }
            else if (model.STATUS == "INACTIVE")
            {
                status = "I";
            }

            var data_find = (from n in db.HmlRoomTpDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.RTPID == model.RTPID select n).ToList();
            foreach (var item in data_find)
            {
                item.ID = model.ID;
                item.COMPID = model.COMPID;
                item.RTPID = Convert.ToInt64(model.RTPID);
                item.RATEBDT = Convert.ToDecimal(model.RATEBDT);
                item.RATEUSD = Convert.ToDecimal(model.RATEUSD);
                item.STATUS = status;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_ROOMTP Tabel
            RoomController roomController = new RoomController();
            roomController.update_HML_ROOMTP_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }










        //[Route("api/ApiRoomController/grid/DeleteData")]
        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_RoomTpDTO model)
        {
            HML_ROOMTP deleteModel = new HML_ROOMTP();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.RTPID = Convert.ToInt64(model.RTPID);

            var findChildData = (from n in db.HmlRoomDbSet
                                 where n.RTPID == deleteModel.RTPID && n.COMPID == deleteModel.COMPID
                                 select n).ToList();

            HML_RoomTpDTO hmlROOMTpObj = new HML_RoomTpDTO();

            if (findChildData.Count != 0)
            {
                hmlROOMTpObj.GetChildDataForDeleteMasterCategory = 1; // True (child data found)
            }
            else
            {
                deleteModel = db.HmlRoomTpDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.RTPID);
                db.HmlRoomTpDbSet.Remove(deleteModel);
                db.SaveChanges();

                //Log data save from HML_ROOMTP Tabel
                RoomController roomController = new RoomController();
                roomController.Delete_HML_ROOMTP_LogData(model);
                roomController.Delete_HML_ROOMTP_LogDelete(model);
            }
            return Request.CreateResponse(HttpStatusCode.OK, hmlROOMTpObj);
        }
    }
}
