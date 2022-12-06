using CrystalDecisions.CrystalReports.Engine;
using CrystalReportMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppTest
{
    public partial class WebForm1CrystalReport : System.Web.UI.Page

    {
        public ReportDocument reportMgn
        {
            get
            {
                return Session["reportMgn"] as ReportDocument;
            }
            set
            {
                Session["reportMgn"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reportMgn = new ReportManagement().RptPath("PO_tgsg4_new.rpt");
                reportMgn.SetParameterValue("PO NO.", "22/E008");
                CrystalReportViewer1.ReportSource = reportMgn;
            }
        }
    }
}

