using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using App_Test.Models;


namespace App_Test
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        TGSGDatabaseEntities ctx = new TGSGDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                var login = ctx.Tgsg_usp_AppRama3Login(Request.Cookies["myCookieTest"]["EmpID"], "appTest").FirstOrDefault();
                if (login != null)
                {
                    lblidUser.Text = login.UserName;
                }
            }
        }

        protected void Rep1_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType()
                 , "new/window", "window.open ('ViewReport.aspx?Type=" + "Sampleglass_Report1" + "');", true);
        }

        protected void Rep3_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType()
                 , "new/window", "window.open ('ViewReport.aspx?Type=" + "Sampleglass_Report3" + "');", true);
        }

        protected void Rep2_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType()
                 , "new/window", "window.open ('ViewReport.aspx?Type=" + "Sampleglass_Report2" + "');", true);
        }
    }

   
}

 


 
    

