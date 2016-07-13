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
    public partial class TodaySales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        [WebMethod]
        public static JsonObject getSales(string dl, string xl)
        {
            string sql="";

            if (dl == "所有")
            {
                sql = "select m.DisherName as 'name',b.snum as 'num',cast(b.ssp as numeric(9,2)) as 'price',cast(b.sdp as numeric(9,2)) as 'discount',cast(b.snp as numeric(9,2)) as 'get' from MenuDetail m,"
                + "	(select id,sum(num) snum,sum(sp) ssp,sum(dp) sdp,sum(np) snp from"
                + "		(select d.id,d.num,d.num*d.price sp,d.num*d.price*(1-d.dis) dp,d.num*d.price*d.dis np from"
                + "			(select DisherID id,DisherNum num,DisherPrice price,SalesDiscount dis from DineDetail"
                + "				     where DisherID in (select DisherId from MenuDetail )"
                + "			) d"
                + "		) a group by id "
                + "	) b where b.id=m.DisherId";
            }
            else if (xl == "所有")
            {
                sql = "select m.DisherName as 'name',b.snum as 'num',cast(b.ssp as numeric(9,2)) as 'price',cast(b.sdp as numeric(9,2)) as 'discount',cast(b.snp as numeric(9,2)) as 'get' from MenuDetail m,"
                    + "	(select id,sum(num) snum,sum(sp) ssp,sum(dp) sdp,sum(np) snp from"
                + "		(select d.id,d.num,d.num*d.price sp,d.num*d.price*(1-d.dis) dp,d.num*d.price*d.dis np from"
                + "			(select DisherID id,DisherNum num,DisherPrice price,SalesDiscount dis from DineDetail"
                + "				     where DisherID in (" +
                                           "select DisherId from MenuDetail where DisherSubClassID1 in " +
                                                   "(select SubClassId from MenuSubClass where ClassId in " +
                                                        "(select ClassId from MenuClass where ClassName='" + dl + "'))" +
                                                        ")"
                + "			) d"
                + "		) a group by id "
                + "	) b where b.id=m.DisherId";
            }
            else
            {
                 sql = "select m.DisherName as 'name',b.snum as 'num',cast(b.ssp as numeric(9,2)) as 'price',cast(b.sdp as numeric(9,2)) as 'discount',cast(b.snp as numeric(9,2)) as 'get' from MenuDetail m,"
                      + "	(select id,sum(num) snum,sum(sp) ssp,sum(dp) sdp,sum(np) snp from"
                + "		(select d.id,d.num,d.num*d.price sp,d.num*d.price*(1-d.dis) dp,d.num*d.price*d.dis np from"
                + "			(select DisherID id,DisherNum num,DisherPrice price,SalesDiscount dis from DineDetail"
                + "				     where DisherID in ("
                + "                          select DisherId from MenuDetail where DisherSubClassID1 in "
                + "                                  (select SubClassId from MenuSubClass where SubClassName ='"+xl+"')"
                +" )"
                + "			) d"
                + "		) a group by id "
                + "	) b where b.id=m.DisherId";
            }
            string[] names={"name","num","price","discount","get"};
            JsonObject result=myConvert.GetJsonObj(sql,names);
            return result;
        }

    }
}