using System;
using System.Web;
using Jayrock.Json;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Reporter.Models
{
    public class myTime
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        public myTime() { }

        public myTime(JsonObject jobj)
        {
            //KdgPointData kpd = (KdgPointData)JsonConvert.Import(typeof(KdgPointData), jsonObject.ToString());
            /*
            myTime timer = new myTime();
            JsonTextReader reader = new JsonTextReader(new StringReader(jobj.ToString()));
            timer = (myTime)Jayrock.Json.Conversion.JsonConvert.Import(typeof(myTime), reader);
            */
            myTime timer = (myTime)Jayrock.Json.Conversion.JsonConvert.Import(typeof(myTime), jobj.ToString());
            this.beginTime = timer.beginTime;
            this.endTime = timer.endTime;

        }
        public string beginTime { get; set; }
        public string endTime { get; set; }
    }

    public class myConvert
    {
        static SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
        static SqlConnection Pconn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBPayConnectionString"].ConnectionString);
        //不同的名字序号的数据库连接
        public static SqlConnection GetConnName(string HotelId)
        {
            SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"+HotelId].ConnectionString);
            return conn;
        }

        //json字符串序列化
        public static string DataTableToJson(DataTable dt, string[] options)
        {
            string jsonData = "{'rows':'" + dt.Rows.Count + "','data':[";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    jsonData += "{";
                    for (int i = 0; i < options.Length; i++)
                        jsonData += "'" + options[i] + "':'" + row[options[i]] + "',";
                    jsonData = jsonData.Substring(0, jsonData.Length - 1);
                    jsonData += "},";
                }
                jsonData = jsonData.Substring(0, jsonData.Length - 1);
            }
            jsonData += "]}";
            return jsonData;
        }
        //获取一般格式的json数据
        public static JsonObject GetJsonObj(string str, string[] names)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(str,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();

            string jsonStr = DataTableToJson(ds.Tables[0], names);
            JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
            JsonObject jobj = new JsonObject();
            jobj.Import(reader);
            return jobj;
        }
        //不同数据库连接获取json数据方式
        public static JsonObject GetJsonObjModel(string str,string[] names,SqlConnection Mconn)
        {
            Mconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(str,Mconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Mconn.Close();

            string jsonStr = DataTableToJson(ds.Tables[0], names);
            JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
            JsonObject jobj = new JsonObject();
            jobj.Import(reader);
            return jobj;
        }

        //获取对账信息的数据格式
        public static JsonObject PGetJsonObj(string str, string[] names)
        {
            Pconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(str, Pconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Pconn.Close();

            Pconn.Open();
            String Sum_sql = "select sum(x.price) as sum2 from (" + str + ") x";

            SqlCommand cmd_sum = new SqlCommand(Sum_sql, Pconn);
            SqlDataReader sdr_sum = cmd_sum.ExecuteReader();
            sdr_sum.Read();
            double sum2 = 0;
            if (sdr_sum["sum2"].ToString() != "")
            {
                sum2 = Double.Parse(sdr_sum["sum2"].ToString().Trim());
                DataRow dr = ds.Tables[0].NewRow();
                object[] objs = { null, "总计", null, "", sum2, null };
                dr.ItemArray = objs;
                ds.Tables[0].Rows.Add(dr);
            }
            Pconn.Close();
            string jsonStr = DataTableToJson(ds.Tables[0], names);
            JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
            JsonObject jobj = new JsonObject();
            jobj.Import(reader);
            return jobj;
        }
        //通过房间号找名字
        public static string findIdByName(string name)
        {
            string roomId = "";
            conn.Open();
            string conString = "select distinct RoomId from RoomInfo where RoomName='" + name + "'";
            SqlCommand cmd_2 = new SqlCommand(conString, conn);
            SqlDataReader sdr = cmd_2.ExecuteReader();
            sdr.Read();
            roomId = sdr["RoomId"].ToString().Trim();
            conn.Close();
            return roomId;
        }
    }
}
