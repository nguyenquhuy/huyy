using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Huyy
{
    public partial class CoursesDetail : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["i"];

            if (!IsPostBack && id != null)
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
                                string name = reader.GetString(1);
                                string owner = reader.GetString(5);
                                string src = reader.GetString(3);
                                string des = reader.GetString(2);

                                detail.InnerHtml = $@"
                                    <div class=""heading"">
                                        <h1>Được đăng bởi <a href=""MyCourses.aspx?username={owner}"">{owner}</a></h1>
                                    </div>
                                    <div class=""content"">
                                        <h1>{name}</h1>                                        
                                        <iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/qK6b-dbufJI?si=-UrUst3fkda8ouop"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"" allowfullscreen></iframe>
                                        <p>{des}</p>
                                    </div>";
                                    
                            }
                            else
                            {
                                detail.InnerHtml = "<p>Course not found.</p>";
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }
    }
}
