using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Huyy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            if (Request.Form["dangnhap"] != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string username = Request.Form["username"];
                    string pass = Request.Form["password"];
                    string qry = "select * from userinfo where username='" + username + "' and password='" + pass + "'";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        Session["login"] = 1;
                        Session["username"] = username;
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Response.Write("Invalid User");
                    }

                    connection.Close();

                }
            }
        }

    }
}