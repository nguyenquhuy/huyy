﻿using System;
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
                                    "<td> Tên khóa học </td>" +
                                    "<td> Mô tả </td>" +
                                "</tr>";
                                tableHead.InnerHtml += tablehead;
                                while (reader.Read())
                                {
                                    string cname = reader.GetString(1);
                                    string des = reader.GetString(2);
                                    string owner = reader.GetString(5);
                                    if (owner == user)
                                    {
                                        if (cname != null)
                                        {
                                            my_label.Text = "Khóa học của tôi";
                                            string tableRow = "<tr><td>" + cname + "</td>" +
                                                          "<td>" + des + "</td>" +
                                                          "<td>" + "<a href=#>Edit</a>" + "</td>" +
                                                          "<td>" + "<a href=#>Delete</a>" + "</td>" +
                                                          "" +
                                                          "</tr>";
                                            // Add the table row to the table body
                                            // Make sure you initialize the tableBody.InnerHtml before the loop
                                            tableBody.InnerHtml += tableRow;
                                        }
                                    }
                                    else
                                    {
                                        my_label.Text = "Khóa học của " + owner;
                                        string tableRow = "<tr><td>" + cname + "</td>" +
                                                      "<td>" + des + "</td>" +
                                                      "</td></tr>";

                                        // Add the table row to the table body
                                        // Make sure you initialize the tableBody.InnerHtml before the loop
                                        tableBody.InnerHtml += tableRow;
                                    }
                                    // Add the data to the table row                            
                                }
                            }
                            else
                            {
                                string owner1 = Session["username"].ToString();
                                if (owner1 == user)
                                {
                                    my_label.Text = "Bạn chưa có khóa học nào. " + "<a href = 'NewCourses.aspx'>Đăng ngay</a>";
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

/*
 
                                    
*/