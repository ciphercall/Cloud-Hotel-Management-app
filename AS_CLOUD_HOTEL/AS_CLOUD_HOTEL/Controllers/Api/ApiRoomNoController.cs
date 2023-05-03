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
    public class ApiRoomNoController : ApiController
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

        public ApiRoomNoController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }









        //[System.Web.Http.Route("api/ApiRoomNoController/GetMediCareData")]
        [System.Web.Http.HttpGet]
        public IEnumerable<HML_RoomDTO> GetRoomNoData(string Compid, string Rtpid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            Int64 RoomeTypeid = Convert.ToInt64(Rtpid);
            var find_GridData = (from room in db.HmlRoomDbSet
                                 where room.COMPID == compid && room.RTPID == RoomeTypeid
                                 select new
                                 {
                                     room.ID,
                                     room.COMPID,
                                     room.RTPID,
                                     room.ROOMNO,
                                     room.REMARKS,

                                     room.INSIPNO,
                                     room.INSLTUDE,
                                     room.INSTIME,
                                     room.INSUSERID,
                                 }).OrderBy(e => e.ROOMNO).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_RoomDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_RoomDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        RTPID = Convert.ToInt64(s.RTPID),
                        ROOMNO = Convert.ToString(s.ROOMNO),
                        REMARKS = s.REMARKS,

                        INSUSERID = s.INSUSERID,
                        INSLTUDE = s.INSLTUDE,
                        INSTIME = s.INSTIME,
                        INSIPNO = s.INSIPNO,
                    };
                }
            }
        }









        //[Route("api/ApiRoomNoController/grid/addData")]
        [HttpPost]
        public HttpResponseMessage AddData(HML_RoomDTO model)
        {
            if (ModelState.IsValid)
            {
                HML_ROOM roomNo = new HML_ROOM();

                Int64 roomNumber = Convert.ToInt64(model.ROOMNO);
                var check_data = (from n in db.HmlRoomDbSet where n.COMPID == model.COMPID && n.RTPID == model.RTPID && n.ROOMNO == roomNumber select n).ToList();
                if (check_data.Count == 0 && model.RTPID != 0)
                {
                    roomNo.COMPID = model.COMPID;
                    roomNo.RTPID = Convert.ToInt64(model.RTPID);
                    roomNo.ROOMNO = Convert.ToInt64(model.ROOMNO);
                    roomNo.REMARKS = model.REMARKS;

                    roomNo.USERPC = strHostName;
                    roomNo.INSIPNO = ipAddress.ToString();
                    roomNo.INSTIME = Convert.ToDateTime(td);
                    roomNo.INSUSERID = model.INSUSERID;
                    roomNo.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlRoomDbSet.Add(roomNo);
                    db.SaveChanges();

                    model.ID = roomNo.ID;
                    model.COMPID = roomNo.COMPID;
                    model.RTPID = Convert.ToInt64(roomNo.RTPID);
                    model.ROOMNO = Convert.ToString(roomNo.ROOMNO);
                    model.REMARKS = roomNo.REMARKS;
                    model.USERPC = roomNo.USERPC;
                    model.INSIPNO = roomNo.INSIPNO;
                    model.INSTIME = roomNo.INSTIME;
                    model.INSUSERID = roomNo.INSUSERID;
                    model.INSLTUDE = Convert.ToString(roomNo.INSLTUDE);

                    //Log data save from HML_ROOM Tabel
                    RoomController controller = new RoomController();
                    controller.Insert_HML_ROOM_LogData(model);
                    model.ValidationError = false;
                    HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response1;
                }
                else
                {
                    model.ValidationError = true;
                    model.ROOMNO = "0";
                    HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response2;
                }
            }
            model.ValidationError = true;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;
        }











        //[Route("api/ApiRoomNoController/grid/UpdateData")]
        [HttpPost]
        public HttpResponseMessage UpdateData(HML_RoomDTO model)
        {
            Int64 roomNo = Convert.ToInt64(model.ROOMNO);
            var data_find = (from n in db.HmlRoomDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.RTPID == model.RTPID && n.ROOMNO == roomNo select n).ToList();

            foreach (var item in data_find)
            {
                item.REMARKS = model.REMARKS;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_ROOM Tabel
            RoomController controller = new RoomController();
            controller.update_HML_ROOM_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }









        //[Route("api/ApiRoomNoController/grid/DeleteData")]
        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_RoomDTO model)
        {
            HML_ROOM deleteModel = new HML_ROOM();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.RTPID = Convert.ToInt64(model.RTPID);
            deleteModel.ROOMNO = Convert.ToInt64(model.ROOMNO);

            deleteModel = db.HmlRoomDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.RTPID, deleteModel.ROOMNO);
            db.HmlRoomDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_ROOM Tabel
            RoomController controller = new RoomController();
            controller.Delete_HML_ROOM_LogData(model);
            controller.Delete_HML_ROOM_LogDelete(model);


            HML_RoomDTO roomNoObj = new HML_RoomDTO();
            return Request.CreateResponse(HttpStatusCode.OK, roomNoObj);
        }
    }
}
