using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace Huyy
{
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["dangky"] != null)
            {
                string username = Request.Form["username"];
                string pass = Request.Form["password"];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Use a parameterized query to prevent SQL injection
                    string insertQuery = "INSERT INTO userinfo (username, password) VALUES (@username, @password)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", pass);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            Response.Redirect("Login.aspx");
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception (log, display an error message, etc.)
                            // For simplicity, we'll just display a generic error message here
                            Response.Write("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
        }

    }
}