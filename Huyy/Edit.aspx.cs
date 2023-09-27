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
    public partial class Edit : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["i"];

            if (!IsPostBack) // Check if it's not a postback to avoid overwriting user input
            {
                if (id != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT * FROM courses WHERE Coursesid = @id";                        
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    name.Text = reader.GetString(1);
                                    description.Text = reader.GetString(2);
                                    source.Text = reader.GetString(3);
                                    slug.Text = reader.GetString(4);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["i"];

            if (id != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string update = "UPDATE courses SET name = @name, description = @description, sources = @source, slug = @slug WHERE CoursesId = @id";

                    using (SqlCommand cmd = new SqlCommand(update, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name.Text);
                        cmd.Parameters.AddWithValue("@description", description.Text);
                        cmd.Parameters.AddWithValue("@source", source.Text);
                        cmd.Parameters.AddWithValue("@slug", slug.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Redirect("MyCourses.aspx?username=" + Session["username"]);
                        }
                        else
                        {
                            // Handle the case where the update didn't succeed
                            string script = "alert('Update failed. Please try again.');";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                        }
                    }

                    connection.Close();
                }
            }
        }

    }
}