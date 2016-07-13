using Jayrock.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reporter.Models;

namespace Reporter.ReportForm
{
    public partial class DeskAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }
        [WebMethod]
        public static JsonObject getAnalysis(string beginTime, string endTime, string deskinfo)
        {
            beginTime += " 00:00:00.000";
            endTime += " 23:59:59.999";
            string sql = "";
            if (deskinfo == "所有")
            {
                sql = " select deskid 'id',count(checkid) 'num',avg(shp) 'average',sum(clientnum) 'preson',cast(sum(yjp) as numeric(9,2)) 'price',cast(sum(yhp) as numeric(9,2))  'discount',cast(sum(shp) as numeric(9,2))  'get',sum(shp)*100/(select sum(shp) from "
                       + " (select dishernum*disherprice*salesdiscount shp"
                       + " from ViewDeskInfo where checkdate between '" + beginTime + "' and '" + endTime + "') b"
                       + " ) 'precent'"
                       + " from (select deskid,clientnum,checkid,dishernum*disherprice yjp,dishernum*disherprice*salesdiscount shp,dishernum*disherprice*(1-salesdiscount) yhp"
                       + " from ViewDeskInfo where checkdate between '" + beginTime + "' and '" + endTime + "') a"
                       + " group by a.deskid";
            }
            else
            {
                string roomid = myConvert.findIdByName(deskinfo);
                sql = " select deskid 'id',count(checkid) 'num',avg(shp) 'average',sum(clientnum) 'preson',cast(sum(yjp) as numeric(9,2)) 'price',cast(sum(yhp) as numeric(9,2))  'discount',cast(sum(shp) as numeric(9,2))  'get',sum(shp)*100/(select sum(shp) from "
                       + " (select dishernum*disherprice*salesdiscount shp"
                       + " from ViewDeskInfo where roomid = '" + roomid + "' and checkdate between '" + beginTime + "' and '" + endTime + "') b"
                       + " ) 'precent'"
                       + " from (select deskid,clientnum,checkid,dishernum*disherprice yjp,dishernum*disherprice*salesdiscount shp,dishernum*disherprice*(1-salesdiscount) yhp"
                       + " from ViewDeskInfo where roomid = '" + roomid + "' and checkdate between '" + beginTime + "' and '" + endTime + "') a"
                       + " group by a.deskid";
            }

            string[] names = { "id", "num", "average", "preson", "price", "discount", "get", "precent"};
            JsonObject result = myConvert.GetJsonObj(sql, names);

            return  result;
        }
    }
}