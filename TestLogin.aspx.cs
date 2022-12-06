using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tgsg;

namespace Login
{
    public partial class TestLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //SessionLogin login = new Authorized().GetPermissionAccess(txtUsername.Text);
            //if (login != null)
            //{
            //    Session["login"] = login;
            //    Response.Redirect("Default.aspx");

            //}
            //else
            //{
            //    Response.Redirect("noRightToAccess.aspx");
            //}
            Response.Redirect("chkAuthorized.aspx?ValidUser=" + txtUsername.Text);
            //Response.Redirect("chkAuthorized.aspx?ValidUser=" + txtUsername.Text + "&page=ImportTax");
        }
    }
}