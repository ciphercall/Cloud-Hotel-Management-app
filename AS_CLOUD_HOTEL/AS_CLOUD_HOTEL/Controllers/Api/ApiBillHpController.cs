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
    public class ApiBillHpController : ApiController
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

        public ApiBillHpController()
        {
            strHostName = System.Net.Dns.GetHostName();
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            td = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        }





        //[System.Web.Http.Route("api/ApiRoomController/GetMediMasterInfo")]
        [System.Web.Http.HttpGet]
        public IEnumerable<HML_BillHpDTO> GetData(string Compid)
        {
            Int64 compid = Convert.ToInt64(Compid);
            var find_GridData = (from t1 in db.HmlBillHpDbSet
                                 where t1.COMPID == compid
                                 select new
                                 {
                                     t1.ID,
                                     t1.COMPID,
                                     t1.BILLID,
                                     t1.BILLNM,
                                     t1.BILLRT,
                                     t1.REMARKS,

                                     t1.INSIPNO,
                                     t1.INSLTUDE,
                                     t1.INSTIME,
                                     t1.INSUSERID,
                                 }).OrderBy(e => e.BILLNM).ToList();

            if (find_GridData.Count == 0)
            {
                yield return new HML_BillHpDTO
                {
                    count = 1, //no data found
                };
            }
            else
            {
                foreach (var s in find_GridData)
                {
                    yield return new HML_BillHpDTO
                    {
                        ID = s.ID,
                        COMPID = Convert.ToInt64(s.COMPID),
                        BILLID = Convert.ToInt64(s.BILLID),
                        BILLNM = s.BILLNM,
                        BILLRT = Convert.ToDecimal(s.BILLRT),
                        REMARKS = s.REMARKS,
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
        public HttpResponseMessage AddData(HML_BillHpDTO model)
        {
            if (ModelState.IsValid)
            {
                HML_BILLHP billhp = new HML_BILLHP();

                var check_data = (from n in db.HmlBillHpDbSet where n.COMPID == model.COMPID && n.BILLNM == model.BILLNM select n).ToList();
                if (check_data.Count == 0)
                {
                    var find_data = (from n in db.HmlBillHpDbSet where n.COMPID == model.COMPID select n.BILLID).ToList();
                    if (find_data.Count == 0)
                    {
                        billhp.BILLID = Convert.ToInt64(Convert.ToString(model.COMPID) + "01");
                    }
                    else
                    {
                        Int64 find_Max_BILLID = Convert.ToInt64((from n in db.HmlBillHpDbSet where n.COMPID == model.COMPID select n.BILLID).Max());
                        billhp.BILLID = find_Max_BILLID + 1;
                    }

                    Int64 max = Convert.ToInt64(model.COMPID + "99");
                    if (billhp.BILLID > max)
                    {
                        model.ValidationError = true;
                        HttpResponseMessage response4 = Request.CreateResponse(HttpStatusCode.Created, model);
                        return response4;
                    }


                    billhp.COMPID = model.COMPID;
                    billhp.BILLNM = model.BILLNM;
                    billhp.BILLRT = Convert.ToDecimal(model.BILLRT);
                    billhp.REMARKS = model.REMARKS;
                    billhp.USERPC = strHostName;
                    billhp.INSIPNO = ipAddress.ToString();
                    billhp.INSTIME = Convert.ToDateTime(td);
                    billhp.INSUSERID = model.INSUSERID;
                    billhp.INSLTUDE = Convert.ToString(model.INSLTUDE);

                    db.HmlBillHpDbSet.Add(billhp);
                    db.SaveChanges();

                    model.ID = billhp.ID;
                    model.COMPID = billhp.COMPID;
                    model.BILLID = Convert.ToInt64(billhp.BILLID);
                    model.BILLNM = billhp.BILLNM;
                    model.BILLRT = Convert.ToDecimal(billhp.BILLRT);
                    model.REMARKS = billhp.REMARKS;
                    model.USERPC = billhp.USERPC;
                    model.INSIPNO = billhp.INSIPNO;
                    model.INSTIME = billhp.INSTIME;
                    model.INSUSERID = billhp.INSUSERID;
                    model.INSLTUDE = Convert.ToString(billhp.INSLTUDE);

                    //Log data save from HML_ROOMTP Tabel
                    BillHpController controller = new BillHpController();
                    controller.Insert_HML_BILLHP_LogData(model);

                    HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.Created, model);
                    return response1;
                }
                else
                {
                    model.BILLID = 0;
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
        public HttpResponseMessage UpdateData(HML_BillHpDTO model)
        {
            var data_find = (from n in db.HmlBillHpDbSet where n.ID == model.ID && n.COMPID == model.COMPID && n.BILLID == model.BILLID select n).ToList();
            foreach (var item in data_find)
            {
                item.BILLRT = Convert.ToDecimal(model.BILLRT);
                item.REMARKS = model.REMARKS;

                item.USERPC = strHostName;
                item.UPDIPNO = ipAddress.ToString();
                item.UPDLTUDE = Convert.ToString(model.INSLTUDE);
                item.UPDTIME = Convert.ToDateTime(td);
                item.UPDUSERID = Convert.ToInt16(model.INSUSERID);

            }
            db.SaveChanges();

            //Log data save from HML_ROOMTP Tabel
            BillHpController controller = new BillHpController();
            controller.update_HML_BILLHP_LogData(model);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;

        }










        //[Route("api/ApiRoomController/grid/DeleteData")]
        [HttpPost]
        // DELETE api/<controller>/5
        public HttpResponseMessage DeleteData(HML_BillHpDTO model)
        {
            HML_BILLHP deleteModel = new HML_BILLHP();
            deleteModel.ID = model.ID;
            deleteModel.COMPID = model.COMPID;
            deleteModel.BILLID = Convert.ToInt64(model.BILLID);

            deleteModel = db.HmlBillHpDbSet.Find(deleteModel.ID, deleteModel.COMPID, deleteModel.BILLID);
            db.HmlBillHpDbSet.Remove(deleteModel);
            db.SaveChanges();

            //Log data save from HML_ROOMTP Tabel
            BillHpController controller = new BillHpController();
            controller.Delete_HML_BILLHP_LogData(model);
            controller.Delete_HML_BILLHP_LogDelete(model);

            HML_BillHpDTO hmlROOMTpObj = new HML_BillHpDTO();
            return Request.CreateResponse(HttpStatusCode.OK, hmlROOMTpObj);
        }
    }
}
