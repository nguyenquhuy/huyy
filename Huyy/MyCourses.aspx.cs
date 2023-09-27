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
    public partial class MyCourses : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string user = Request.QueryString["username"];
                string query = "SELECT * FROM courses where owner = @user";

                string owner1 = Session["username"].ToString();
                int stt = 1;
                if (user != null)
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user", user); // Use parameterized query to prevent SQL injection
                        using (SqlDataReader reader = command.ExecuteReader())
                        {                            
                            if (reader.HasRows)
                            {
                                string tablehead =
                                "<tr>" +
                                    "<td> STT </td>" +
                                    "<td> Tên khóa học </td>" +
                                    "<td> Mô tả </td>" +
                                "</tr>";
                                tableHead.InnerHtml += tablehead;
                                while (reader.Read())
                                {
                                    string id = reader.GetGuid(0).ToString();
                                    string cname = reader.GetString(1);
                                    string des = reader.GetString(2);
                                    string owner = reader.GetString(5);
                                    string encodedId = Uri.EscapeDataString(id);
                                    string encodedCname = Uri.EscapeDataString(cname);
                                    string coursesLink = $"<a href='CoursesDetail.aspx?i={encodedId}&name={encodedCname}'>{cname}</a>";

                                    if (owner1 == user)
                                    {
                                            my_label.Text = "Khóa học của tôi";

                                            // Encode the username for the URL
                                            

                                        // Create the Edit link with the correct query parameter
                                            
                                            string editLink = "<a href='Edit.aspx?i=" + encodedId + "'>Edit</a>";
                                            string deleteLink = "<a href='javascript:void(0);' onclick='confirmDelete(\"" + encodedId + "\")'>Delete</a>";


                                            // Create the table row with the data and links
                                            string tableRow = "<tr>" +
                                                "<td>" + stt + "</td>" +
                                                "<td>" + coursesLink + "</td>" +
                                                "<td>" + des + "</td>" +
                                                "<td>" + editLink + "</td>" +
                                                "<td>" + deleteLink + "</td>" +
                                                "</tr>";

                                            // Add the table row to the table body
                                            // Make sure you initialize the tableBody.InnerHtml before the loop
                                            tableBody.InnerHtml += tableRow;
                                                                                
                                    }
                                    
                                    else
                                    {
                                        my_label.Text = "Khóa học của " + owner;
                                        string tableRow = "<tr>" +
                                                      "<td>" + stt + "</td>" +
                                                      "<td>" + coursesLink + "</td>" +
                                                      "<td>" + des + "</td>" +
                                                      "</td></tr>";

                                        // Add the table row to the table body
                                        // Make sure you initialize the tableBody.InnerHtml before the loop
                                        tableBody.InnerHtml += tableRow;
                                    }
                                    // Add the data to the table row
                                    stt++;
                                }
                            }
                            //Ok phan nay
                            else
                            {
                                if (owner1 != null && owner1 == user)
                                {
                                    my_label.Text = "Bạn chưa có khóa học nào. " + "<a href='NewCourses.aspx?username=" + user + "'>Đăng ngay</a>";

                                }
                                else
                                {
                                    my_label.Text = "Người dùng này không có khóa học nào";
                                }
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
}
