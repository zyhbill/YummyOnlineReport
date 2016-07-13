using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace Reporter.Models
{
    public class myDbconn
    {

            static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            static SqlDataAdapter adpter;
            public static DataTable dbconn(string sql)
            {
                conn.Open();
                adpter = new SqlDataAdapter(sql, conn);
                DataTable dtSelect = new DataTable();
                adpter.Fill(dtSelect);
                conn.Close();
                return dtSelect;
            }
            public static string getName(string dl, string xl)
            {
                string all = "";
                if (dl == "所有")
                {
                    DataTable dbeginTime = dbconn("select * from MenuSubClass order by ClassId ");
                    for (int i = 0; i < dbeginTime.Rows.Count; i++)
                    {
                        if (i == 0) all += "'";
                        if (i != dbeginTime.Rows.Count - 1) all += dbeginTime.Rows[i]["SubClassName"].ToString() + "'" + "," + "'";
                        else all += dbeginTime.Rows[i]["SubClassName"].ToString() + "'";
                    }
                }
                else if (xl == "所有")
                {
                    DataTable dt2 = dbconn("select * from MenuSubClass where ClassId in (select ClassId from MenuClass where ClassName='" + dl + "')");
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        if (i == 0) all += "'";
                        if (i != dt2.Rows.Count - 1) all += dt2.Rows[i]["SubClassName"].ToString() + "'" + "," + "'";
                        else all += dt2.Rows[i]["SubClassName"].ToString() + "'";
                    }
                }
                else
                {
                    all += "'" + xl + "'";
                }
                return all;
            }

        }
}
