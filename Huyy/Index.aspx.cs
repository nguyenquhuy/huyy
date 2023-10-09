﻿using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Huyy
{
    public partial class Index : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM courses ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Initialize an empty string to hold the HTML for all records
                        string html = "";                        

                        while (reader.Read())
                        {
                            string id = reader.GetGuid(0).ToString();
                            string name = reader.GetString(1);
                            string src = reader.GetString(3);
                            string des = reader.GetString(2);
                            string encodedId = Uri.EscapeDataString(id);
                            string encodedCname = Uri.EscapeDataString(name);
                            

                            // Append the HTML for the current record to the html string
                            html += $@"
                            <div class =""column"">
                                <div class=""card"">
                                    <a href='CoursesDetail.aspx?i={encodedId}&name={encodedCname}'><img class=""card-img-top"" src=""img/hinh-anh-thien-nhien.jpg"" alt = ""{name}""></a>
                                    
                                <div class= ""card-body"" >
                                    <a href='CoursesDetail.aspx?i={encodedId}&name={encodedCname}'><h5 class= ""card-title"">{name}</h5></a>                                    
                                    <p class= ""card-text"" >{des}</p>
                                    <a href = ""#"" class= ""btn btn-primary"" > Go somewhere </a>
                                </div>                        
                            </div>
                            </div>";
                            
                        }

                        // Set the inner HTML of the 'home' container to the accumulated HTML for all records
                        home.InnerHtml = $@"<div class=""row"">{html}</div>";
                    }

                }
                connection.Close();

            }
        }
    }
}