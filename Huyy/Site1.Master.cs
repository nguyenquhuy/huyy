using System;

namespace Huyy
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your existing code here, if any.

            if (Session["login"] != null && Session["login"].ToString() == "1")
            {
                // Check if the user is logged in.
                string username = Session["username"] != null ? Session["username"].ToString() : "";


                string htmlCode = $@"               
                                           
                        <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
                            <ul class=""navbar-nav ml-auto"">
                                <li class=""nav-item dropdown"">
                                    <button class=""dropdown-btn"" id=""loginBtn"">
                                        {username}
                                        <i class=""fa fa-caret-down"" aria-hidden=""true""></i>
                                    </button>
                                    <div class=""dropdown-menu"" id=""dropdownMenu"" aria-labelledby=""loginBtn"">
                                        <a class=""dropdown-item"" href=""NewCourses.aspx?username={Uri.EscapeDataString(username)}"">Đăng khóa học</a>
                                        <div class=""dropdown-divider""></div>
                                        <a class=""dropdown-item"" href=""MyCourses.aspx?username={Uri.EscapeDataString(username)}"">Khóa học của tôi</a>
                                        <div class=""dropdown-divider""></div>
                                        <a class=""dropdown-item"" href=""Logout.aspx"">Đăng xuất</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    
                ";

                header_nav.InnerHtml = htmlCode;

            }

            else
            {
                // Modify the HTML code for the header-nav div when the user is not logged in.
                header_nav.InnerHtml = $@"
                
                               
                    <div class=""button"">
                        <button class=""login_btn"" onclick=""redirectToLogin()"">Login</button>
                    </div>
                
                ";
            }
        }

    }
}