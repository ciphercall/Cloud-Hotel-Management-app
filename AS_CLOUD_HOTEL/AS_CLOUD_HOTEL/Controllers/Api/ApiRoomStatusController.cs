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
    public class ApiRoomStatusController : ApiController
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

        public ApiRoomStatusController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }




        [System.Web.Http.HttpGet]
        public IEnumerable<HML_RoomStatusDTO> GetData(string Compid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            var find_GridData = (from t1 in db.HmlRoomStatusDbSet
                                 where t1.COMPID == compid
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.ROOMNO,
                                     t1.RSTATS,
                                     t1.CSTATS,
                                     t1.CLASTDT,
                                     t1.CNEXTDT,
                                     t1.REMARKS,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.ROOMNO).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_RoomStatusDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                var countsRow = 0;
                foreach (var s in find_GridData)
                {
                    countsRow++;
                    yield return new HML_RoomStatusDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        ROOMNO = Convert.ToInt64(s.ROOMNO),
                        RSTATS = s.RSTATS,
                        CSTATS = s.CSTATS,
                        CLASTDT = s.CLASTDT,
                        CNEXTDT = s.CNEXTDT,
                        REMARKS = Convert.ToString(s.REMARKS),
                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,

                        countsRow = countsRow,
                    };
                }
            }
        }









        [HttpPost]
        public HttpResponseMessage AddData(HML_RoomStatusDTO model)
        {
            if (ModelState.IsValid)
            {
                HML_ROOMSTATS roomStatus = new HML_ROOMSTATS();

                var check_data = (from n in db.HmlRoomStatusDbSet where n.COMPID == model.COMPID && n.ROOMNO == model.ROOMNO select n).ToList();
                if (check_data.Count == 0)
                {
                    roomStatus.COMPID = model.COMPID;
                    roomStatus.ROOMNO = model.ROOMNO;
                    roomStatus.RSTATS = model.RSTATS;
                    roomStatus.CSTATS = model.CSTATS;
                    roomStatus.CLASTDT = model.CLASTDT;
                    roomStatus.CNEXTDT = model.CNEXTDT;
                    roomStatus.REMARKS = model.REMARKS;
                    roomStatus.USERPC = strHostName;
                    roomStatus.INSIPNO = ipAddress.ToString();
                    roomStatus.INSTIME = Convert.ToDateTime(td);
                    roomStatus.INSUSERID = model.INSUSERID;
                    roomStatus.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlRoomStatusDbSet.Add(roomStatus);
                    db.SaveChanges();

                    model.ID = roomStatus.ID;
                    model.COMPID = roomStatus.COMPID;
                    model.ROOMNO = Convert.ToInt64(roomStatus.ROOMNO);
                    model.RSTATS = roomStatus.RSTATS;
                    model.CSTATS = roomStatus.CSTATS;
                    model.CLASTDT = roomStatus.CLASTDT;
                    model.CNEXTDT = roomStatus.CNEXTDT;
                    model.REMARKS = roomStatus.REMARKS;
                    model.USERPC = roomStatus.USERPC;
                    model.INSIPNO = roomStatus.INSIPNO;
                    model.INSTIME = roomStatus.INSTIME;
                    model.INSUSERID = roomStatus.INSUSERID;
                    model.INSLTUDE = Convert.ToString(roomStatus.INSLTUDE);

                    //Log data save from HML_ROOMSTATS Tabel
                    RoomStatusController controller = new RoomStatusController();
                    controller.Insert_HML_ROOMSTATS_LogData(model);

                    HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response1;
                }
                else
                {
                    model.ROOMNO = 0;
                    HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response2;
                }
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;
        }





        [HttpPost]
        public HttpResponseMessage UpdateData(HML_RoomStatusDTO model)
        {
           
            if (model.CLASTDT != null || model.CLASTDT != "")
            {
                DateTime a = Convert.ToDateTime(model.CLASTDT);
                model.CLASTDT = a.ToString("dd-MMM-yyyy hh:mm tt");
            }


            if (model.CNEXTDT != null || model.CNEXTDT != "")
            {
                DateTime b = Convert.ToDateTime(model.CNEXTDT);
                model.CNEXTDT = b.ToString("dd-MMM-yyyy hh:mm tt");
            }

            var data_find = (from n in db.HmlRoomStatusDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.ROOMNO == model.ROOMNO select n).ToList();
            foreach (var item in data_find)
            {
                item.RSTATS = Convert.ToString(model.RSTATS);
                item.CSTATS = Convert.ToString(model.CSTATS);
                item.CLASTDT = Convert.ToString(model.CLASTDT);
                item.CNEXTDT = Convert.ToString(model.CNEXTDT);
                item.REMARKS = model.REMARKS;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_ROOMSTATS Tabel
            RoomStatusController controller = new RoomStatusController();
            controller.Update_HML_ROOMSTATS_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }









        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_RoomStatusDTO model)
        {
            HML_ROOMSTATS deleteModel = new HML_ROOMSTATS();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.ROOMNO = Convert.ToInt64(model.ROOMNO);

            HML_RoomStatusDTO floorObj = new HML_RoomStatusDTO();

            deleteModel = db.HmlRoomStatusDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.ROOMNO);
            db.HmlRoomStatusDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_ROOMSTATS Tabel
            RoomStatusController controller = new RoomStatusController();
            controller.Delete_HML_ROOMSTATS_LogData(model);
            controller.Delete_HML_ROOMSTATS_LogDelete(model);

            return Request.CreateResponse(HttpStatusCode.OK, floorObj);
        }
    }
}
