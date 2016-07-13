using Jayrock.Json;
using Reporter.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Reporter
{
    public partial class Login : System.Web.UI.Page
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string signin(string username, string password)
        {
            int i = -1;
            SqlCommand cmd;
            try
            {
                conn.Open();
                cmd = new SqlCommand("select count(*) from HotelUser where LoginName='" + username + "' and LoginPassword='" + password + "'", conn);
                i = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (i > 0)
                {
                    string htid=" ";
                    conn.Open();
                    FormsAuthentication.SetAuthCookie(username, false);
                    string sql="select hotelcode as 'id' from HotelUser where LoginName='"+username+"'";
                    string[] names = { "id" };
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        foreach(DataRow dr in ds.Tables[0].Rows)
                        {
                            htid = dr["id"]+"";
                        }
                    }
                    return "index.aspx&"+htid;
                }
                else
                {
                    return "false";
                }
            }
            catch (System.Data.SqlClient.SqlException e2)
            {
                // Label3.Text = e2.ToString();
                return e2.Message.ToString();
                //MessageBox.Show("系统与数据库连接不成功，请点击”设置数据库连接“按钮设置连接参数！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}