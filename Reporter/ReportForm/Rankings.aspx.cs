using Jayrock.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reporter.Models;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Reporter.ReportForm
{
    public partial class Rankings : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        [WebMethod]
        public static JsonObject getData(string beginTime, string endTime)
        {
            /*
             String json1 = "{data:[{name:'Wallace'},{name:'Grommit'}]}";  
                JSONObject jsonObjSplit = JSONObject.fromObject(json1);  
                JSONArray ja = jsonObjSplit.getJSONArray("data");  
                for (int i = 0; i < ja.size(); i++) {  
                    JSONObject jo = (JSONObject) ja.get(i);  
                     System.out.println(jo.get("name"));  
                }
             */
            //string str=json.ToString();

            /*
           string str = @"{'name':'1','value':'2'}";
           JsonReader reader = new JsonTextReader(new StringReader(str));
           JsonObject jsonObj = new JsonObject();
           jsonObj.Import(reader);
            * 
            * */
            beginTime += " 00:00:00.000";
            endTime += " 23:59:59.999";
            //myTime timer=new myTime(json);
            string sql = "select ROW_NUMBER() over(order by d.rn desc) as 'id',m.DisherName as 'name'"
                +",cast(m.DisherPrice as numeric(9,2)) as 'price',d.rn as 'num',cast(m.DisherPrice*d.rn as numeric(9,2)) as 'sale' "
                +"from MenuDetail m,(select DisherID,sum(DisherNum) rn from DineDetailHistory where  convert(char(10),checkdate,121)"
                +"between '" + beginTime + "' and '" + endTime + "' group by DisherID ) d where m.DisherId=d.DisherID";
            /*SqlDataAdapter sda=new SqlDataAdapter(sql,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();*/
            /*string jsonObj=myConvert.DataTableToJson(ds.Tables[0],names);

            
            JsonReader reader = new JsonTextReader(new StringReader(jsonObj));
            JsonObject result = new JsonObject();
            result.Import(reader);*/
            string[] names = { "id", "name", "price", "num", "sale" };

            JsonObject result = myConvert.GetJsonObj(sql, names);

            return result;
        }
    }
}