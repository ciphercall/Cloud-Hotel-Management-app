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
    public class ApiCItemController : ApiController
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

        public ApiCItemController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }





        //[System.Web.Http.Route("api/ApiRoomController/GetMediMasterInfo")]
        [System.Web.Http.HttpGet]
        public IEnumerable<HML_CItemDTO> GetData(string Compid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            var find_GridData = (from t1 in db.HmlCitemDbSet
                                 where t1.COMPID == compid
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.CITEMID,
                                     t1.CITEMNM,
                                     t1.DEFYN,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.CITEMNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_CItemDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_CItemDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        CITEMID = Convert.ToInt64(s.CITEMID),
                        CITEMNM = s.CITEMNM,
                        DEFYN = s.DEFYN,
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
        public HttpResponseMessage AddData(HML_CItemDTO model)
        {
            if (ModelState.IsValid)
            {
                HML_CITEM cItem = new HML_CITEM();

                var check_data = (from n in db.HmlCitemDbSet where n.COMPID == model.COMPID && n.CITEMNM == model.CITEMNM select n).ToList();
                if (check_data.Count == 0)
                {
                    var find_data = (from n in db.HmlCitemDbSet where n.COMPID == model.COMPID select n.CITEMID).ToList();
                    if (find_data.Count == 0)
                    {
                        cItem.CITEMID = Convert.ToInt64(Convert.ToString(model.COMPID) + "01");
                    }
                    else
                    {
                        Int64 find_Max_CITEMID = Convert.ToInt64((from n in db.HmlCitemDbSet where n.COMPID == model.COMPID select n.CITEMID).Max());
                        cItem.CITEMID = find_Max_CITEMID + 1;
                    }

                    Int64 max = Convert.ToInt64(model.COMPID + "99");
                    if (cItem.CITEMID > max)
                    {
                        model.ValidationError = true;
                        HttpResponseMessage response4 = Request.CreateResponse(HttpStatusCode.Created, model);
                        return response4;
                    }


                    cItem.COMPID = model.COMPID;
                    cItem.CITEMNM = model.CITEMNM;
                    cItem.DEFYN = model.DEFYN;
                    cItem.USERPC = strHostName;
                    cItem.INSIPNO = ipAddress.ToString();
                    cItem.INSTIME = Convert.ToDateTime(td);
                    cItem.INSUSERID = model.INSUSERID;
                    cItem.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlCitemDbSet.Add(cItem);
                    db.SaveChanges();

                    model.ID = cItem.ID;
                    model.COMPID = cItem.COMPID;
                    model.CITEMID = Convert.ToInt64(cItem.CITEMID);
                    model.CITEMNM = cItem.CITEMNM;
                    model.DEFYN = cItem.DEFYN;
                    model.USERPC = cItem.USERPC;
                    model.INSIPNO = cItem.INSIPNO;
                    model.INSTIME = cItem.INSTIME;
                    model.INSUSERID = cItem.INSUSERID;
                    model.INSLTUDE = Convert.ToString(cItem.INSLTUDE);

                    //Log data save from HML_ROOMTP Tabel
                    CItemController controller = new CItemController();
                    controller.Insert_HML_CITEM_LogData(model);

                    HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response1;
                }
                else
                {
                    model.CITEMID = 0;
                    HttpResponseMessage response2 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response2;
                }
            }
            model.ValidationError = true;
            HttpResponseMessage response3 = Request.CreateResponse(HttpStatusCode.Created, model);
            return response3;
        }






        //[Route("api/ApiRoomController/grid/UpdateData")]
        [HttpPost]
        public HttpResponseMessage UpdateData(HML_CItemDTO model)
        {
            var data_find = (from n in db.HmlCitemDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.CITEMID == model.CITEMID select n).ToList();
            foreach (var item in data_find)
            {
                item.DEFYN = model.DEFYN;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_ROOMTP Tabel
            CItemController controller = new CItemController();
            controller.update_HML_CITEM_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }










        //[Route("api/ApiRoomController/grid/DeleteData")]
        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_CItemDTO model)
        {
            HML_CITEM deleteModel = new HML_CITEM();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.CITEMID = Convert.ToInt64(model.CITEMID);

            deleteModel = db.HmlCitemDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.CITEMID);
            db.HmlCitemDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_ROOMTP Tabel
            CItemController controller = new CItemController();
            controller.Delete_HML_CITEM_LogData(model);
            controller.Delete_HML_CITEM_LogDelete(model);

            HML_CItemDTO obj = new HML_CItemDTO();
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }

    }
}
