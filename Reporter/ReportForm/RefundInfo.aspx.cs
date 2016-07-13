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
    public partial class RefundInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static JsonObject getRefund(string beginTime,string endTime)
        {
            beginTime += " 00:00:00.000";
            endTime += " 23:59:59.999";
            string sql = "select a.CheckID as 'id',a.CheckDate as 'time',b.DisherName as 'name',a.DisherPrice as 'price'"
            + ",a.DisherNum as 'num',a.subtotal as 'sPrice',a.disPrice as 'disPrice'"
            + " from (select CheckID,CheckDate,DisherID,DisherNum,DisherPrice,DisherNum*DisherPrice subtotal,DisherNum*DisherPrice*SalesDiscount disPrice from DineDetailHistory "
            + " where CheckID in (select CheckID from DineInfoHistory where CheckDate between '"+beginTime+"' and '"+endTime+"' and IsRefund=1))a,"
            + " (select DisherId,DisherName from MenuDetail)b where b.DisherId=a.DisherID";
            string[] names = { "id", "time", "name", "price", "num", "sPrice", "disPrice" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }
    }
}