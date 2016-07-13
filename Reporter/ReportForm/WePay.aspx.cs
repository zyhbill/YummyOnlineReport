using Jayrock.Json;
using Reporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reporter.ReportForm
{
    public partial class WePay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }
        [WebMethod]
        public static JsonObject getData(string beginTime, string endTime, string hotel,string pay,string Name)
        {
            beginTime += " 00:00:00.000";
            endTime += " 23:59:59.999";
            string sql = "";
            if (hotel == "1")
            {
                sql = "select ROW_NUMBER() over(order by convert(int,P.hotelId),p.Id) as 'num',p.Id as 'id',h.HotelName as 'name',p.PayKind as 'paykind',cast(p.Price as numeric(9,2))as 'price'"
                + ",p.Time as 'time' from (select * from PayStatus where Time between '" + beginTime + "' and '" + endTime + "' and PayKind='" + pay + "') p ,(select * from HotelInfo) h where p.Status=1 and h.HotelCode=p.HotelID";
            }
            else
            {
                sql = "select ROW_NUMBER() over(order by convert(int,P.hotelId),p.Id) as 'num',p.Id as 'id',h.HotelName as 'name',p.PayKind as 'paykind',cast(p.Price as numeric(9,2))as 'price'"
               + ",p.Time as 'time' from (select * from PayStatus where Time between '" + beginTime + "' and '" + endTime + "' and PayKind='" + pay + "') p ,(select * from HotelInfo where HotelName='" + Name + "') h where p.Status=1 and h.HotelCode=p.HotelID";
            }
            string[] names = { "num", "id", "name", "paykind", "price", "time" };
            JsonObject result = myConvert.PGetJsonObj(sql, names);
            return result;
        }
    }
}