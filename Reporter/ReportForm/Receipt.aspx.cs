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
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        [WebMethod]
        public static JsonObject getReceipt(string beginTime, string endTime)
        {
            beginTime += " 00:00:00.000";
            endTime += " 23:59:59.999";

            string sql = "select CheckDate as 'date',CheckId as 'id',cast(Price as numeric(9,2)) as 'price', Title as 'title' "
            + " from ReceiptInfo where CheckDate between '" + beginTime + "' and '" + endTime + "'";

            string[] names = { "date", "id", "price", "title" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }
    }
}