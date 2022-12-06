using Microsoft.Reporting.WebForms;
using ReportAttach.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Test
{
    public partial class WebForm1ReportViewer : System.Web.UI.Page
    {
        string Type;

        public string Path { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Type = Request.QueryString["Type"];
            if(!IsPostBack)
            {
                ReportViewer();
            }
        }

        public void ReportViewer()
        {

            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport = ReportViewer1.ServerReport;
            IReportServerCredentials reportCredentials = new RsCredentials("administrator", "GreenWorld55", "rama3");
            ReportViewer1.ServerReport.ReportServerCredentials = reportCredentials;
            serverReport.ReportServerUrl =
                new Uri("http://192.168.87.9/reportserver");

            if (Type == "Sampleglass_Report")
                Path = "/TGSG Reports/AppReports/Samplesglass_Report";
            else if (Type == "Sampleglass_Report3")
                Path = "/TGSG Reports/AppReports/Samplesglass_Report3";
            else 
                Path = "/TGSG Reports/AppReports/Samplesglass_Report2";
                
            List<ReportParameter> tgsg = new List<ReportParameter>();
            //tgsg.Add(new ReportParameter("IDCUST", CustID));
            //tgsg.Add(new ReportParameter("DATEBTCHFr", DateFr));
            //tgsg.Add(new ReportParameter("IDCUST", DateTo)); 
            serverReport.ReportPath = Path;
            serverReport.ReportPath = "/TGSGACCPAC Reports/Report1TestPDF";

            //Report Parameter
            List<ReportParameter> Srreport = new List<ReportParameter>();
            //Srreport.Add(new ReportParameter("Search", Search ));

            ReportViewer1.ServerReport.SetParameters(Srreport);
        }
    }
}