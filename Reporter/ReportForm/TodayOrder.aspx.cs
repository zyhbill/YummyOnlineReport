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
    public partial class TodayOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        [WebMethod]
        public static JsonObject getOrder()
        {
            string sql = "select a.CheckID as '订单编号'"
            + " ,a.DeskID as '桌号'"
            + " ,a.Roomid as '房间号',c.ClerkName as '收银员'"
            + " ,w.name as '服务员',a.ClientID as '顾客编号'"
            + " ,a.ClientNum as '顾客数量',a.BeginTime as '开始时间'"
            + " ,a.status as '状态',a.PayKind as '支付类型'"
            + " ,cast(a.Subtotal as numeric(9,0)) as '数量'"
            + " ,a.PaidAccount as '支付账户'"
            + " from (select * from DineInfo) a,ClerkInfo c,Waiter w where a.ClerkID=c.ClerkID and a.WaiterID=w.ID";

            string[] names = { "id", "desk", "room", "wiater", "clerk", "client", "c_num", "time", "status", "type", "price", "account" };

            JsonObject result = myConvert.GetJsonObj(sql,names);
            return result;
        }
    }
}