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

                // Modify the HTML code for the header-nav div when the user is logged in.
                header_nav.InnerHtml = $@"
                <nav>
                    <div class=""container"">
                        <h2>Site name</h2>
                        <div class=""search-bar"">
                            <i class=""uil uil-search""></i>
                            <input type=""search"" placeholder=""Search here"">
                        </div>
                        <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
                            <ul class=""navbar-nav ml-auto"">
                                <li class=""nav-item dropdown"">
                                    <button class=""dropdown-btn"" id=""loginBtn"">
                                        {username}
                                        <i class=""fa fa-caret-down"" aria-hidden=""true""></i> <!-- Moved the icon inside the button -->
                                    </button>
                                    <div class=""dropdown-menu"" id=""dropdownMenu"" aria-labelledby=""loginBtn""> <!-- Updated aria-labelledby -->
                                        <a class=""dropdown-item"" href=""#"">Dang khoa hoc</a>
                                        <div class=""dropdown-divider""></div>
                                        <a class=""dropdown-item"" href=""#"">Khóa học của tôi</a>
                                        <div class=""dropdown-divider""></div>
                                        <a class=""dropdown-item"" href=""Logout.aspx"">Đăng xuất</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>";

            }
            else
            {
                // Modify the HTML code for the header-nav div when the user is not logged in.
                header_nav.InnerHtml = $@"
                <nav>
                <div class=""container"">
                <h2>Site name</h2>
                <div class=""search-bar"">
                    <i class=""uil uil-search""></i>
                    <input type=""search"" placeholder=""Search here"">
                </div>
                <div class=""button"">
                    <button class=""login_btn"">Login</button>
                </div>
                </div>
                </nav>";
            }
        }


    }
}