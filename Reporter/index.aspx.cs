using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jayrock.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Reporter.Models;

namespace Reporter
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod]
        public static string logout()
        {
            FormsAuthentication.SignOut();
            return "";
        }

        [WebMethod]
        public static JsonObject GetMenuClass()
        {
            //conn.Open();
            string sql = "select * from MenuClass";
            /*SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
             * 
            conn.Close();
            string jsonStr = myConvert.DataTableToJson(ds.Tables[0], names);*/

            string[] names = { "ClassName" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }


        [WebMethod]

        public static JsonObject GetMenuSubClass(string dl)
        {
            string sql = "select * from MenuSubClass where ClassId in(select ClassId from MenuClass where ClassName ='" + dl + "')";
            string[] names = { "SubClassName" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }

        [WebMethod]
        public static JsonObject GetDeskInfo()
        {
            string sql = "select distinct RoomId, RoomName from RoomInfo";
            string[] names = { "RoomName" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }
        [WebMethod]
        public static JsonObject GetHotelInfo(string hotelCode)
        {
            string sql = "";
            if (hotelCode == "1")
            {
                sql = "select HotelCode,HotelName from HotelInfo";
            }
            else
            {
                sql = "select HotelCode,HotelName from HotelInfo where HotelCode='"+hotelCode+"'";
            }
            string[] names = { "HotelCode", "HotelName" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }
        [WebMethod]
        public static JsonObject GetPayKind()
        {
            string sql = "select Kind,PayName from PayKind";
            string[] names = { "Kind", "PayName" };
            JsonObject result = myConvert.GetJsonObj(sql, names);
            return result;
        }
    }
}