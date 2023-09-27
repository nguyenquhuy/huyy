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
    public partial class NewCourses : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Request.QueryString["username"];
            // Check if the "add" form parameter exists and the user is logged in.
            if (user != null && Session["login"].ToString() == "1")
            {
                string name = Request.Form["name"];
                string description = Request.Form["description"];
                string owner = Session["username"].ToString();
                string source = Request.Form["source"];
                string slug = Request.Form["slug"];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Use a parameterized query to prevent SQL injection
                    string insertQuery = "INSERT INTO courses (name, description, sources, slug, owner) VALUES (@name, @description, @source, @slug, @owner)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@source", source);
                        cmd.Parameters.AddWithValue("@slug", slug);
                        cmd.Parameters.AddWithValue("@owner", owner);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            // Redirect to the page where the new course is listed
                            Response.Redirect("MyCourses.aspx?username=" + Session["username"]);
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
            else
            {
                // If "add" form parameter is not present or the user is not logged in, redirect to the index page.
                Response.Redirect("Index.aspx");
            }
        }

    }
}