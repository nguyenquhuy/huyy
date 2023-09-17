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
            if (Request.Form["add"] != null && Session["login"] == "1")
            {
                string name = Request.Form["name"];
                string description = Request.Form["description"];
                string id = Request.Form["id"];
                string source = Request.Form["source"];
                string slug = Request.Form["slug"];

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Use a parameterized query to prevent SQL injection
                    string insertQuery = "INSERT INTO courses (name, description, id, sources, slug) VALUES (@name, @description, @id, @source, @slug)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@source", source);
                        cmd.Parameters.AddWithValue("@slug", slug);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            Response.Redirect("MyCourses.aspx");
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
                Response.Redirect("Index.aspx");
            }


        }
    }
}