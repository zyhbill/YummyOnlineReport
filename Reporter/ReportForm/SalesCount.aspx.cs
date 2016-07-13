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
    public partial class SalesCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }
        [WebMethod]
        public static JsonObject getData(string beginTime, string endTime, string dl, string xl)
        {

            beginTime += " 00:00:00.000";
            endTime += " 23:59:59.999";
            string menuStr = myDbconn.getName(dl, xl);

            string sql = "select c.DisherId as 'id',c.DisherName as 'name'"
            + " ,c.DisherSize as 'unit',cast(c.DisherPrice as numeric(9,2)) as 'price' "
            + " ,cast(b.sn as numeric(9,0)) as 'num',cast(b.sm as numeric (9,2)) as 'sPrice',cast(b.em as numeric(9,2)) as 'discount',cast (b.sd as numeric (9,2)) as 'dPrice'"
            + " ,cast(b.sn*1.0/e.ssn*100 as numeric(9,2)) as 'p_num'"
            + " ,cast(b.sm*1.0/e.ssm*100 as numeric(9,2)) as 'p_sPrice'"
            + " ,cast(b.sd*1.0/e.ssd*100 as numeric(9,2)) as 'p_discount'"
            + " ,cast(b.em*1.0/e.sss*100 as numeric(9,2)) as 'p_dPrice'"
            + " from (select * from MenuDetail where DisherSubclassID1 in (select SubClassId from MenuSubClass where SubClassName in (" + menuStr + ")))c"
            + " ,(select a.DisherID,a.sn,a.sp sm,a.sp*a.sd sd,a.sp*(1-a.sd) em "
            + " from (select DisherId,SUM(DisherNum) sn,SUM(DisherPrice*DisherNum) sp,(SUM(SalesDiscount*DisherNum)*1.0/SUM(DisherNum)) sd from DineDetailHistory where CONVERT(char(10),CheckDate,121)"
            + " between '" + beginTime + "' and '" + endTime + "' and DisherID in(select DisherId from MenuDetail"
            + " where DisherSubclassID1 in (select SubClassId from MenuSubClass where SubClassName in (" + menuStr + ")))group by DisherID) a) b"
            + " , (select sum(d.sn) ssn,sum(d.sm) ssm,SUM(d.ss) ssd,sum(d.em) sss from (select a.DisherID,a.sn,a.sp sm,a.sp*(1-a.sd) em,a.ss"
            + " from (select DisherId,SUM(DisherNum) sn,SUM(DisherPrice*DisherNum) sp,SUM(DisherPrice*DisherNum*SalesDiscount) ss"
            + " ,SUM(SalesDiscount*DisherNum)*1.0/SUM(DisherNum) sd from DineDetailHistory where CONVERT(char(10),CheckDate,121)"
            + " between '" + beginTime + "' and '" + endTime + "' and DisherID in(select DisherId from MenuDetail"
            + " where DisherSubclassID1 in (select SubClassId from MenuSubClass where SubClassName in (" + menuStr + ")))group by DisherID) a) d) e where c.DisherId=b.DisherID order by convert(int,c.DisherID)"; 
            
            string[] names={"id","name","unit","price","num","sPrice","discount","dPrice","p_num","p_sPrice","p_discount","p_dPrice"};

            JsonObject result = myConvert.GetJsonObj(sql, names);


            return result;
        }
    }
}