using System;

namespace Huyy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["dangnhap"] != null)
            {
                string username = Request.Form["username"];
                string pass = Request.Form["password"];

                // Store the username in Session
                Session["login"] = 1;
                Session["username"] = username;

                Response.Redirect("Index.aspx");
            }
        }

    }
}