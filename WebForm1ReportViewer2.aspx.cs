using Microsoft.Reporting.WebForms;
using ReportAttach.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Test
{
    public partial class WebForm1ReportViewer2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnViewerReport_Click(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport = ReportViewer1.ServerReport;
            IReportServerCredentials reportCredentials = new RsCredentials("administrator", "GreenWorld55", "rama3");
            ReportViewer1.ServerReport.ReportServerCredentials = reportCredentials;
            serverReport.ReportServerUrl =
                new Uri("http://192.168.87.9/reportserver");


            serverReport.ReportPath = "/TGSGACCPAC Reports/Report1TestPDF";

            //Report Parameter
            List<ReportParameter> Srreport = new List<ReportParameter>();
            Srreport.Add(new ReportParameter("Search", txtParameter.Text ));

            ReportViewer1.ServerReport.SetParameters(Srreport);
        }
    }
}