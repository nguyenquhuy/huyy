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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
            string id = Request.QueryString["i"];

            if (!IsPostBack) // Check if it's not a postback to avoid overwriting user input
            {
                if (id != null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string delete = "Delete from courses where CoursesId = @id";
                        using (SqlCommand command = new SqlCommand(delete, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);                            
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Response.Redirect("MyCourses.aspx?username=" + Session["username"]);
                            }
                            else
                            {
                                // Handle the case where the update didn't succeed
                                string script = "alert('Delete failed. Please try again.');";
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                            }
                        }
                        connection.Close();
                        
                    }
                }
            }
        }
    }
}