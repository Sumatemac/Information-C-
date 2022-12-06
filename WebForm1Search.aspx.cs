using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Test.Models;

namespace App_Test
{
    public partial class WebForm1Search : System.Web.UI.Page
    {
        TGSGDatabaseEntities db = new TGSGDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Search();
            }
        }   

        protected void Search()
        {
            var dt = db.TGSG_TestSearch(txtSearch.Text).ToList();
            gvSearch.DataSource = dt;
            gvSearch.DataBind();


            DroupDownList1.DataSource = dt;
            DroupDownList1.DataTextField = "AName";
            DroupDownList1.DataValueField = "id";
            DroupDownList1.DataBind();


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void linkSelect_Click(object sender, EventArgs e)
        {
            GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;

            LinkButton linkSelect = row.FindControl("linkSelect") as LinkButton;
            Label lblid = row.FindControl("lblid") as Label;

            Response.Redirect("WebForm1Input.aspx?IDName=" + lblid.Text);
        }

    }
}