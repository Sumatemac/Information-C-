 using Microsoft.Reporting.WebForms;
using ReportAttach.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Test.Models;

namespace App_Test
{
    public partial class WebForm1PrintPDF : System.Web.UI.Page
    {
        string Search;
        protected void Page_Load(object sender, EventArgs e)
        {
            Search = Request.QueryString["Search"];
            if (!IsPostBack)
            {

                CreatePDF("TestPDF");
            }
        }

        private void CreatePDF(string fileName)
        {
            ReportViewer reportViewer = new ReportViewer();
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            reportViewer.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport = reportViewer.ServerReport;
            IReportServerCredentials reportCredentials = new RsCredentials("administrator", "GreenWorld55", "rama3");
            reportViewer.ServerReport.ReportServerCredentials = reportCredentials;
            serverReport.ReportServerUrl =
                new Uri("http://192.168.87.9/reportserver");


            serverReport.ReportPath = "/TGSGACCPAC Reports/Report1TestPDF";

            //Report Parameter
            List<ReportParameter> Srreport = new List<ReportParameter>();
            Srreport.Add(new ReportParameter("Search", Search));

            reportViewer.ServerReport.SetParameters(Srreport);

            // Setup the report viewer object and get the array of bytes
            byte[] bytes = reportViewer.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            //Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "inline; filename=" + fileName + "." + extension);
            Response.BinaryWrite(bytes); // create the file
            Response.Flush();
            Response.End(); // send it to th
        }
      }
    }